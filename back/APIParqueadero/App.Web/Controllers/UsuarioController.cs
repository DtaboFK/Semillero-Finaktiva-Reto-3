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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService service;
        public UsuarioController(IUsuarioService services)
        {
            this.service = services;
        }

        #region Listar
        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            Response<List<UsuarioDTO>> response = new Response<List<UsuarioDTO>>();
            try
            {
                response.Data = service.Listar();
                return Ok(response.Data);
            }
            catch (Exception ex)
            {
                response.Header.Code = HttpCodes.NotFound;
                response.Header.Message = ex.Message;
                return NotFound(response);
            }
        }
        #endregion

        #region Buscar
        [HttpPost("Buscar")]
        public IActionResult Buscar(UsuarioDTO dto)
        {
            Response<List<UsuarioDTO>> response = new Response<List<UsuarioDTO>>();
            try
            {
                response.Data = service.Buscar(dto);
                if (response.Data.Count == 1)
                {
                    return Ok(response.Data);
                }
                else
                {
                    response.Header.Code = HttpCodes.NotFound;
                    return NotFound(response.Header);
                }
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
        public IActionResult Crear(UsuarioDTO dto)
        {
            Response<UsuarioDTO> response = new Response<UsuarioDTO>();
            try
            {
                response.Data = service.Crear(dto);
                return Ok(response.Header);
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
