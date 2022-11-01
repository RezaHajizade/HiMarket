using MongoDB.Driver.Core.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class BaseDto<T>
    {
        public BaseDto(T data, List<string> message, bool isSuccess)
        {
            Data = data;
            Message = message;
            IsSuccess = isSuccess;
        }

        public T Data { get; set; }
        public List<String> Message { get;private  set; }
        public bool IsSuccess { get; private set; }
    }

    public class BaseDto
    {
        public BaseDto( List<string> message, bool isSuccess)
        {
            Message = message;
            IsSuccess = isSuccess;
        }
        public List<String> Message { get; private set; }
        public bool IsSuccess { get; private set; }
    }
}
