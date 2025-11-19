namespace ECommerce.Application.Features.Products.Create;

public class CreateProductCommandHandler(
    IProductCommandRepository productCommandRepository,
    IProductQueryRepository productQueryRepository,
    ICategoryQueryRepository categoryQueryRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<CreateProductCommand, Response<GetProductDto>>
{
    public async Task<Response<GetProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var product = mapper.Map<Product>(request);

            if (request.CategoryId is not null)
            {
                var category = await categoryQueryRepository.GetByIdAsync(request.CategoryId.Value);

                if (category is null)
                    return NotFound<GetProductDto>("Category not found");

                var exsistedName = await productQueryRepository.GetByCategoryIdAndName(product.CategoryId, request.Name);

                if (exsistedName is not null)
                    return BadRequest<GetProductDto>("You can not use this name as it is exsisted in the same category");

                product.SetCategory(category);
            }

            await productCommandRepository.AddAsync(product);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            var dto = mapper.Map<GetProductDto>(product);

            return Created(dto);

        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error occurred while creating product");

            return InternalServerError<GetProductDto>();

        }
    }
}
