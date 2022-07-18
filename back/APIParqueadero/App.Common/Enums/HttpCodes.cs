using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Common.Enums
{
    public enum HttpCodes
    {
        Ok = 200,
        BadRequest = 400,
        NotFound = 404,
        ValidationError = 421,
        InternalServerError = 500,
        NotApproved = 422,
        ControlledErrorException = 455,
        WsControlledErrorException = 456,
        WsControlledErrorExceptionDate = 457,
        NotValidateType = 454
    }
}
