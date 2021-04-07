using IdentificationServer.Core.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
