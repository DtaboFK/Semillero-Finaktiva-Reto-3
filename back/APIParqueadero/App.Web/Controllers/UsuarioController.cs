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
                    return Ok(response);
                }
                else
                {
                    response.Header.Code = HttpCodes.NotFound;
                    return Ok(response);
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
                if (response.Data != null)
                {
                    response.Header.Code = HttpCodes.Ok;
                    response.Header.Message = "¡Cliente registrado!";
                    return Ok(response);
                }
                else
                {
                    response.Header.Code = HttpCodes.NotApproved;
                    response.Header.Message = "Algo salió mal";
                    return Ok(response);
                }
            }
            catch (ApplicationException)
            {
                response.Header.Code = HttpCodes.NotFound;
                response.Header.Message = "El usuario ya existe";
                return  Ok(response);
            }
            catch (Exception ex)
            {
                response.Header.Code = HttpCodes.NotFound;
                response.Header.Message = ex.Message;
                return NotFound(ex);
            }
        }
        #endregion

        #region Actualizar
        [HttpPut("Actualizar")]
        public IActionResult Actualizar(UsuarioDTO dto)
        {
            Response<UsuarioDTO> response = new Response<UsuarioDTO>();
            try
            {
                response.Data = service.Actualizar(dto);
                if (response.Data != null)
                {
                    response.Header.Code = HttpCodes.Ok;
                    response.Header.Message = "¡Cliente actualizado!";
                    return Ok(response);
                }
                else
                {
                    response.Header.Code = HttpCodes.NotApproved;
                    response.Header.Message = "Algo salió mal";
                    return Ok(response);
                }
            }
            catch (ApplicationException)
            {
                response.Header.Code = HttpCodes.NotFound;
                response.Header.Message = "El usuario no se actualizó";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Header.Code = HttpCodes.NotFound;
                response.Header.Message = ex.Message;
                return NotFound(ex);
            }
        }
        #endregion

    }
}
