using csv_import.domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace csv_import.datalayer.Configurations
{
    public class FileDetailMapping: EntityTypeConfiguration<File>
    {
        public FileDetailMapping()
        {
            this.ToTable("PTFile");
            this.Property(p => p.Address).HasMaxLength(200).IsRequired();
            this.Property(p => p.FirstName).HasMaxLength(45).IsRequired();
            this.Property(p => p.MiddleName).HasMaxLength(45).IsRequired();
            this.Property(p => p.LastName).HasMaxLength(45).IsRequired();
            this.Property(p => p.City).HasMaxLength(45).IsRequired();
            this.Property(p => p.StateProvince).HasMaxLength(45).IsRequired();
            this.Property(p => p.ZipPostalCode).HasMaxLength(10).IsRequired();
            this.Property(p => p.Phone).HasMaxLength(20).IsRequired();
            this.Property(p => p.Country).HasMaxLength(20).IsRequired();
            this.Property(p => p.Gender).HasMaxLength(1).IsRequired();
            this.Property(p => p.BirthDate).HasColumnType("Date").IsRequired();
            this.Property(p => p.Email).IsRequired().HasMaxLength(100).HasColumnAnnotation(
               "Index",
               new IndexAnnotation(new[]
                {
                    new IndexAttribute("Email_Index") { IsUnique = true }
                }));
        }
    }
}
