using App.Common.DTO;
using App.Infrastructure.Database.Entities;
using AutoMapper;



namespace App.Config.Dependecias
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LogsGeneral, LogsGeneralDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Vehiculo, VehiculoDTO>().ReverseMap();
            CreateMap<Mensualidad, MensualidadDTO>().ReverseMap();
            CreateMap<Operario, OperarioDTO>().ReverseMap();
        }
    }
}
