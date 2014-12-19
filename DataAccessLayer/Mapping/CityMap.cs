using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Core;

namespace DataAccessLayer.Mapping
{
    public class CityMap : EntityTypeConfiguration<City>
    {
        public CityMap()
        {
            this.HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.Name).IsRequired().HasMaxLength(100);
            
            // Names of columns
            this.Property(m => m.Name).HasColumnName("Name");
            this.Property(m => m.Id).HasColumnName("Id");
        }
    }
}