using App.Domain.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Base
{
    public abstract class BaseController<TDTO> : Controller where TDTO : class
    {
        private IBaseService<TDTO> _service;

        public BaseController(IBaseService<TDTO> service)
        {
            _service = service;
        }


        [HttpGet]
        [Route("getAll")]
        public virtual IActionResult GetAll()
        {
            try
            {
                var data = _service.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }







    }
}
