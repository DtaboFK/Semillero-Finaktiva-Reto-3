using App.Infrastructure.Base;
using App.Infrastructure.Database;
using App.Infrastructure.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories
{
    public interface IMensualidadRepository : IBaseRepository<Mensualidad>
    {
        List<Mensualidad> Listar();
        Mensualidad Crear(Mensualidad mensualidad);
    }
    public class MensualidadRepository : BaseRepository<Mensualidad>, IMensualidadRepository
    {
        public MensualidadRepository(DataContext database) : base(database)
        {
        }

        #region Listar
        public List<Mensualidad> Listar()
        {
            return _table.ToList();
        }
        #endregion

        #region Crear
        public Mensualidad Crear(Mensualidad mensualidad)
        {
            var data = _table.Add(mensualidad);
            _database.SaveChanges();
            return data.Entity;
        }
        #endregion

    }
}
