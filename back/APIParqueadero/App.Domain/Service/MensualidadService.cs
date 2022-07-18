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
    public interface IMensualidadService
    {
        List<MensualidadDTO> Listar();
        MensualidadDTO Crear(MensualidadDTO dto);
    }
    public class MensualidadService : IMensualidadService
    {
        private IMensualidadRepository _mensualidadRepository;
        private IMapper _mapper;
        public MensualidadService(IMensualidadRepository mensualidadRepository, IMapper mapper)
        {
            _mensualidadRepository = mensualidadRepository;
            _mapper = mapper;
        }

        #region Listar
        public List<MensualidadDTO> Listar()
        {
            var mensualidades = _mapper.Map<List<MensualidadDTO>>(_mensualidadRepository.Listar());
            return mensualidades;
        }
        #endregion

        #region Crear
        public MensualidadDTO Crear(MensualidadDTO dto)
        {
            var mensualidad = _mapper.Map<Mensualidad>(dto);
            var data = _mensualidadRepository.Crear(mensualidad);
            return _mapper.Map<MensualidadDTO>(data);
        }
        #endregion

    }
}
