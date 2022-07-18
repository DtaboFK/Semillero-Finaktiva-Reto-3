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
    public class VehiculoController : ControllerBase
    {
        private IVehiculoService service;
        public VehiculoController(IVehiculoService services)
        {
            this.service = services;
        }

        #region Listar
        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            Response<List<VehiculoDTO>> response = new Response<List<VehiculoDTO>>();
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
        public IActionResult Crear(VehiculoDTO dto)
        {
            Response<VehiculoDTO> response = new Response<VehiculoDTO>();
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
