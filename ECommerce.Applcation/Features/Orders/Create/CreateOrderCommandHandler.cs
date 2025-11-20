using ECommerce.Domain.Enums;
using ECommerce.Domain.Repositories.Orders;
using ECommerce.Domain.Repositories.OrderTracks;

namespace ECommerce.Application.Features.Orders.Create;

public class CreateOrderCommandHandler(
    IProductQueryRepository productQueryRepository,
    IOrderQueryRepository orderQueryRepository,
    IOrderTrackCommandRepository orderTrackCommandRepository,
    IUserQueryRepository userQueryRepository,
    IOrderCommandRepository orderCommandRepository,
    IUnitOfWork unitOfWork)

    : ResponseHandler,
    IRequestHandler<CreateOrderCommand, Response<string>>
{
    public async Task<Response<string>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.BeginTransactionAsync();

        try
        {
            var existingOrder = await orderQueryRepository.GetByIdempotencyKeyAsync(request.IdempotancyKey);

            if (existingOrder is not null)
                return Created<string>(message: "Order created successfully.");

            var customer = await userQueryRepository.GetByIdAsync(request.CustomerId);

            if (customer is null)
                return BadRequest<string>("There is no customer with this id.");

            var productsIds = request.Items.Select(x => x.ProductId).ToList();

            var products = await productQueryRepository.GetByIdsAsync(productsIds);

            if (products.Count != productsIds.Count)
                return BadRequest<string>("One or more products are invalid.");

            foreach (var item in request.Items)
            {
                var product = products.First(p => p.Id == item.ProductId);

                if (item.Quantity > product.StockQuantity)

                    return BadRequest<string>($"Product with id {product.Id} does not have enough stock.");
            }

            var items = request.Items.Select(item =>
            {
                var product = products.First(p => p.Id == item.ProductId);
                return new OrderItem(product.Id, item.Quantity, product.TotalPrice);
            }).ToList();

            var order = new Order(customer, items, request.IdempotancyKey);

            await orderCommandRepository.AddAsync(order);

            var orderTrack = new OrderTrack(OrderStatus.Pending, order.Id);

            await orderTrackCommandRepository.AddAsync(orderTrack);

            foreach (var item in request.Items)
            {
                var product = products.Find(p => p.Id == item.ProductId);

                product!.ReduceStock(item.Quantity);
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);

            await unitOfWork.CommitTransactionAsync();

            return Created<string>(message: "Order created successfully.");
        }
        catch (Exception ex)
        {
            Log.Error(ex, "error while creating new order");

            await unitOfWork.RollbackTransactionAsync();

            return InternalServerError<string>();
        }
    }
}
