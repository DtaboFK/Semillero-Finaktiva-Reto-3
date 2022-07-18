﻿using App.Infrastructure.Base;
using App.Infrastructure.Database;
using App.Infrastructure.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories
{
    public interface IOperarioRepository : IBaseRepository<Operario>
    {
        List<Operario> Listar();
        Operario Crear(Operario operario);
    }
    public class OperarioRepository : BaseRepository<Operario>, IOperarioRepository
    {
        public OperarioRepository(DataContext database) : base(database)
        {
        }

        #region Listar
        public List<Operario> Listar()
        {
            return _table.ToList();
        }
        #endregion

        #region Crear
        public Operario Crear(Operario operario)
        {
            var data = _table.Add(operario);
            _database.SaveChanges();
            return data.Entity;
        }
        #endregion

    }
}
