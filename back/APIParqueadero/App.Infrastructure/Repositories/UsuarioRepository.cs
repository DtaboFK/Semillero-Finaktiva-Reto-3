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
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        List<Usuario> Listar();
        List<Usuario> Buscar(Usuario doc);
        Usuario Buscar(string doc);
        Usuario Crear(Usuario usuario);
        Usuario Actualizar(Usuario usuario);
    }
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DataContext databse) : base(databse)
        {
        }

        #region Listar
        public List<Usuario> Listar()
        {
            return _table.ToList();
        }
        #endregion

        #region Buscar
        public List<Usuario> Buscar(Usuario doc)
        {
            return _table.Where(item => item.Documento == doc.Documento).ToList();
        }

        public Usuario Buscar(string doc)
        {
            return _table.Where(item => item.Documento == doc).FirstOrDefault();
        }
        #endregion

        #region Crear
        public Usuario Crear(Usuario usuario)
        {
            var data = _table.Add(usuario);
            _database.SaveChanges();
            return data.Entity;
        }
        #endregion

        #region Actualizar
        public Usuario Actualizar(Usuario usuario)
        {
            if (usuario == null)
            {
                return null;
            }
            Usuario user = _table.Find(GetValuePrimaryKey(usuario));
            if (user != null)
            {
                _database.Entry(user).CurrentValues.SetValues(usuario);
                _database.SaveChanges();
            }
            return user;
        }
        #endregion

    }
}
