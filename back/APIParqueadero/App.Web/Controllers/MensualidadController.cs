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
    public class MensualidadController : ControllerBase
    {
        private IMensualidadService service;
        public MensualidadController(IMensualidadService services)
        {
            this.service = services;
        }

        #region Listar
        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            Response<List<MensualidadDTO>> response = new Response<List<MensualidadDTO>>();
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
        public IActionResult Crear(MensualidadDTO dto)
        {
            Response<MensualidadDTO> response = new Response<MensualidadDTO>();
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
