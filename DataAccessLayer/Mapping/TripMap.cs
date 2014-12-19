using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Core;

namespace DataAccessLayer.Mapping
{
    public class TripMap : EntityTypeConfiguration<Trip>
    {
        public TripMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.StartDate).IsRequired().HasColumnName("StartDate");
            Property(m => m.EndDate).IsRequired().HasColumnName("EndDate");
            Property(m => m.PortFromId).IsOptional().HasColumnName("PortFromId");
            Property(m => m.PortToId).IsOptional().HasColumnName("PortToId");
            Property(m => m.CaptainId).IsOptional().HasColumnName("CaptainId");

            // Relations
            HasOptional(m => m.PortTo).WithMany(m => m.TripsTo).HasForeignKey(m => m.PortToId).WillCascadeOnDelete(false);
            HasOptional(m => m.PortFrom).WithMany(m => m.TripsFrom).HasForeignKey(m => m.PortFromId).WillCascadeOnDelete(false);
            HasOptional(m=>m.Captain).WithMany(m=>m.Trips).HasForeignKey(m=>m.CaptainId).WillCascadeOnDelete(false);
        }
    }
}