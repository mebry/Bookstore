using Bookstore.Domain.Enums;

namespace Bookstore.Application.Common.Interfaces.Responses
{
    public interface IBaseResponse<T>
    {
        public T Data { get; set; }

        public StatusCode StatusCode { get; set; }

        public string Description { get; set; }
    }
}
