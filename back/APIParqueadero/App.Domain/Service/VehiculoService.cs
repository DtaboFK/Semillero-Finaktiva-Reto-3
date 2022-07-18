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
    public interface IVehiculoService
    {
        List<VehiculoDTO> Listar();
        VehiculoDTO Crear(VehiculoDTO dto);
    }
    public class VehiculoService : IVehiculoService
    {
        private IVehiculoRepository _vehiculoRepository;
        private IMapper _mapper;
        public VehiculoService(IVehiculoRepository vehiculoRepository, IMapper mapper)
        {
            _vehiculoRepository = vehiculoRepository;
            _mapper = mapper;
        }

        #region Listar
        public List<VehiculoDTO> Listar()
        {
            var vehiculos = _mapper.Map<List<VehiculoDTO>>(_vehiculoRepository.Listar());
            return vehiculos;
        }
        #endregion

        #region Crear
        public VehiculoDTO Crear(VehiculoDTO dto)
        {
            var vehiculo = _mapper.Map<Vehiculo>(dto);
            var data = _vehiculoRepository.Crear(vehiculo);
            return _mapper.Map<VehiculoDTO>(data);
        }
        #endregion

    }
}
