using Bookstore.Application.Common.Interfaces.Responses;
using Bookstore.Domain.Enums;

namespace Bookstore.Application.Common.Models
{
    public class BaseResponse<T> : IBaseResponse<T> where T : class
    {
        public T Data { get; set; } = null!;

        public StatusCode StatusCode { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
