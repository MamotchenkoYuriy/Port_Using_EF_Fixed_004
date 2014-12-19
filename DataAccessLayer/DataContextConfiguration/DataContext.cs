using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using Core;

namespace DataAccessLayer.DataContextConfiguration
{
    public class DataContext : DbContext
    {
        public DataContext()
            :base(Config.Config.ConnectionString("DBConnectionString"))
        {
            Database.SetInitializer(new DbInitializer());
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Captain> Captains { get; set; }
        public DbSet<Cargo> Carges { get; set; }
        public DbSet<CargoType> CargoTypes { get; set; }
        public DbSet<Port> Ports { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var mapTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !String.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                               && type.BaseType.GetGenericTypeDefinition()
                               == typeof(EntityTypeConfiguration<>));
            foreach (var type in mapTypes)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
