using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Core;

namespace DataAccessLayer.Mapping
{
    public class PortMap : EntityTypeConfiguration<Port>
    {
        public PortMap()
        {
            this.HasKey(m => m.Id);
            this.Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.Name).IsRequired().HasColumnName("Name").HasMaxLength(50);
            this.Property(m => m.CityId).IsOptional().HasColumnName("CityId");
            this.Property(m => m.Id).HasColumnName("Id");

            //Relations
            HasOptional(m => m.City).WithMany(m => m.Ports).HasForeignKey(m => m.CityId);
        }
    }
}