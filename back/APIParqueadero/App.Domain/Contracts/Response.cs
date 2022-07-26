using App.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Contracts
{
    public class Response<T>
    {
        public Header Header { get; set; }

        public T Data { get; set; }

        public Response()
        {
            Header = new Header();
            Header.Code = HttpCodes.Ok;
            Header.Message = "SUCCESS";
            //Header.Code = HttpCodes.NotFound;
            //Header.Message = "NOT FOUND";
        }
    }

    public class Header
    {
        public HttpCodes Code { get; set; }
        public string Message { get; set; }
    }

   
}
