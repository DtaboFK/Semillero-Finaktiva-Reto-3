using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Database
{
    public class DataContext: DbContext
    {

        public DbSet<LogsGeneral> LogsGeneral { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Vehiculo> Vehiculo { get; set; }
        public DbSet<Operario> Operario { get; set; }
        public DbSet<Mensualidad> Mensualidad { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
