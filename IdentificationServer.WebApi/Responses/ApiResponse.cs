using IdentificationServer.Core.CustomEntities;

namespace IdentificationServer.WebApi.Responses
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public MetaData Meta { get; set; }

        public ApiResponse(T data)
        {
            Data = data;
        }
        
    }
}
