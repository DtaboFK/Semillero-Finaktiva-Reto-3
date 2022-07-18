using App.Common.DTO;
using App.Domain.Base;
using App.Domain.Service;
using App.Web.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestConBaseController : BaseController<LogsGeneralDTO>
    {
        private ILogsGeneralConBaseServices  _service;

        public TestConBaseController(ILogsGeneralConBaseServices service) : base(service)
        {
            _service = service;
        }


    }
}
