using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Utils
{
    public interface IResponseModel<T>
    {
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        T Result { get; set; }
        int ResultCode { get; set; }
    }
}
