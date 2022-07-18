using App.Common.DTO;
using App.Domain.Base;
using App.Infrastructure.Base;
using App.Infrastructure.Database.Entities;
using App.Infrastructure.Repositories;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Service
{

    public interface ILogsGeneralConBaseServices : IBaseService<LogsGeneralDTO> { }
    public class LogsGeneralConBaseServices : BaseService<LogsGeneralDTO, LogsGeneral>, ILogsGeneralConBaseServices
    {

        private ILogsGeneralRepository Repository;

        public LogsGeneralConBaseServices(IBaseRepository<LogsGeneral> repo,
               IMapper mapper,
               ILogsGeneralRepository Repository,
               IConfiguration configuration
               ) 
            : base(repo, mapper, configuration)
        {
            Repository = this.Repository;
        }

    }
}
