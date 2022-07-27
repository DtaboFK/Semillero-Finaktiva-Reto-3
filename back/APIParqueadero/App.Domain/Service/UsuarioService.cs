using App.Common.DTO;
using App.Infrastructure.Database.Entities;
using App.Infrastructure.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Service
{
    public interface IUsuarioService
    {
        List<UsuarioDTO> Listar();
        List<UsuarioDTO> Buscar(UsuarioDTO dto);
        UsuarioDTO Crear(UsuarioDTO dto);
    }
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;
        private IMapper _mapper;
        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        #region Listar
        public List<UsuarioDTO> Listar()
        {
            var usuarios = _mapper.Map<List<UsuarioDTO>>(_usuarioRepository.Listar());
            return usuarios;
        }
        #endregion

        #region Buscar
        public List<UsuarioDTO> Buscar(UsuarioDTO dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);
            var data = _usuarioRepository.Buscar(usuario);
            return _mapper.Map<List<UsuarioDTO>>(data);
        }
        #endregion

        #region Crear
        public UsuarioDTO Crear(UsuarioDTO dto)
        {
            var usuarioExist = _usuarioRepository.Buscar(dto.Documento);
            if (usuarioExist == null)
            {
                var usuario = _mapper.Map<Usuario>(dto);
                var data = _usuarioRepository.Crear(usuario);
                return _mapper.Map<UsuarioDTO>(data);
            } 
            else
            {
                throw new ApplicationException();
            }

        }
        #endregion

    }
}
