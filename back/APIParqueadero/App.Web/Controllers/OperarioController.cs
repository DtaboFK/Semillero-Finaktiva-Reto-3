using App.Common.DTO;
using App.Common.Enums;
using App.Domain.Contracts;
using App.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace App.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OperarioController : ControllerBase
    {
        private IOperarioService service;
        public OperarioController(IOperarioService services)
        {
            this.service = services;
        }

        #region Listar
        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            Response<List<OperarioDTO>> response = new Response<List<OperarioDTO>>();
            try
            {
                response.Data = service.Listar();
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Header.Code = HttpCodes.NotFound;
                response.Header.Message = ex.Message;
                return NotFound(response);
            }
        }
        #endregion

        #region Crear
        [HttpPost("Crear")]
        public IActionResult Crear(OperarioDTO dto)
        {
            Response<OperarioDTO> response = new Response<OperarioDTO>();
            try
            {
                response.Data = service.Crear(dto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Header.Code = HttpCodes.NotFound;
                response.Header.Message = ex.Message;
                return NotFound(response);
            }
        }
        #endregion

    }
}
