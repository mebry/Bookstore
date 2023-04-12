using Bookstore.Domain.Enums;

namespace Bookstore.Application.Common.Models
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }

        public StatusCode StatusCode { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
