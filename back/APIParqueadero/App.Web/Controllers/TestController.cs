using App.Common.DTO;
using App.Common.Enums;
using App.Domain.Contracts;
using App.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace App.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
       private  ILogsGeneralServices service;

        public TestController(ILogsGeneralServices services)
        {
            this.service = services;
        }

        [HttpGet]
        [Route("GetUser")]
        public IActionResult GetUser()
        {
            try
            {
                var data = this.service.GetAll();
                return Ok(data);
               
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetUserSinBase")]
        public Response<List<LogsGeneralDTO>> GetUserSinBase()
        {
            Response<List<LogsGeneralDTO>> response = new Response<List<LogsGeneralDTO>>();
            try
            {
                response.Data = this.service.GetAllSinBase();
               

            }
            catch (Exception ex)
            {
                response.Header.Code = HttpCodes.BadRequest;
                response.Header.Message = ex.Message;
            }

            return response;
        }


    }
}
