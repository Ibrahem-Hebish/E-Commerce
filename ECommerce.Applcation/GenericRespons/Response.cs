using ECommerce.Application.GenericResponse;
using System.Net;

namespace ECommerce.Application.GenericRespons;
public class Response<T> : IResponse
{
    public T? Data { get; set; }
    public string? Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public bool IsSuccess { get; set; }
}

