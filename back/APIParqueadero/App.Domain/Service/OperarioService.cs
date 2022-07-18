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
    public interface IOperarioService
    {
        List<OperarioDTO> Listar();
        List<OperarioDTO> Buscar(OperarioDTO dto);
        OperarioDTO Crear(OperarioDTO dto);
    }
    public class OperarioService : IOperarioService
    {
        private IOperarioRepository _operarioRepository;
        private IMapper _mapper;
        public OperarioService(IOperarioRepository repository, IMapper mapper)
        {
            _operarioRepository = repository;
            _mapper = mapper;
        }

        #region Listar
        public List<OperarioDTO> Listar()
        {
            var operarios = _mapper.Map<List<OperarioDTO>>(_operarioRepository.Listar());
            return operarios;
        }
        #endregion

        #region Buscar
        public List<OperarioDTO> Buscar(OperarioDTO dto)
        {
            var operario = _mapper.Map<Operario>(dto);
            var data = _operarioRepository.Buscar(operario);
            return _mapper.Map<List<OperarioDTO>>(data);
        }
        #endregion

        #region Crear
        public OperarioDTO Crear(OperarioDTO dto)
        {
            var operario = _mapper.Map<Operario>(dto);
            var data = _operarioRepository.Crear(operario);
            return _mapper.Map<OperarioDTO>(data);
        }
        #endregion

    }
}
