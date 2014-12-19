using System.Data.Entity.ModelConfiguration;
using Core;

namespace DataAccessLayer.Mapping
{
    public class CaptainMap : EntityTypeConfiguration<Captain>
    {
        public CaptainMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasColumnName("Id");
            Property(m => m.LastName).IsRequired().HasColumnName("LastName").HasMaxLength(50);
            Property(m => m.FirstName).IsRequired().HasColumnName("FirstName").HasMaxLength(50);
            //Ignore(m => m.Ships);
            //HasMany(m => m.Ships).WithOptional(m => m.Captain).HasForeignKey(m=>m.CaptainId);
        }
    }
}