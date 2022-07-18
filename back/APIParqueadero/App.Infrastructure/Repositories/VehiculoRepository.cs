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
    public interface IVehiculoRepository : IBaseRepository<Vehiculo>
    {
        List<Vehiculo> Listar();
        Vehiculo Crear(Vehiculo vehiculo);
    }
    public class VehiculoRepository : BaseRepository<Vehiculo>, IVehiculoRepository
    {
        public VehiculoRepository(DataContext database) : base(database)
        {
        }

        #region Listar
        public List<Vehiculo> Listar()
        {
            return _table.ToList();
        }
        #endregion

        #region Crear
        public Vehiculo Crear(Vehiculo vehiculo)
        {
            var data = _table.Add(vehiculo);
            _database.SaveChanges();
            return data.Entity;
        }
        #endregion

    }
}
