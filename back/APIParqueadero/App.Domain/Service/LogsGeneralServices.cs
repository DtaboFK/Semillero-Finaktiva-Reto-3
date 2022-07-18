using App.Common.DTO;
using App.Infrastructure.Repositories;
using AutoMapper;
using System.Collections.Generic;

namespace App.Domain.Service
{
    public interface ILogsGeneralServices 
    {
        List<LogsGeneralDTO> GetAll();
        List<LogsGeneralDTO> GetAllSinBase();
    }
    public class LogsGeneralServices: ILogsGeneralServices
    {
        private ILogsGeneralRepository _LogsGeneralRepository;
        private IMapper _mapper;

        public LogsGeneralServices(ILogsGeneralRepository LogsGeneralServices, IMapper mapper)
        {
            _LogsGeneralRepository = LogsGeneralServices;
            _mapper = mapper;
        }
        /// <summary>
        /// COmo funciona el base service y controllador ?? 
        /// </summary>
        /// <returns></returns>
        public List<LogsGeneralDTO> GetAll()
        {
            List<LogsGeneralDTO> result = new List<LogsGeneralDTO>();
            var test = _LogsGeneralRepository.GetAll();
            result = _mapper.Map<List<LogsGeneralDTO>>(test);
            return result;

        }

        public List<LogsGeneralDTO> GetAllSinBase()
        {
            List<LogsGeneralDTO> result = new List<LogsGeneralDTO>();
            var test = _LogsGeneralRepository.GetAllSinBase();
            result = _mapper.Map<List<LogsGeneralDTO>>(test);
            return result;

        }
    }
}
