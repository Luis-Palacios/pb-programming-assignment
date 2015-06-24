using csv_import.domain;
using System.Data.Entity.ModelConfiguration;

namespace csv_import.datalayer.Configurations
{
    public class ImportResultMapping : EntityTypeConfiguration<ImportResult>
    {
        public ImportResultMapping()
        {
            this.ToTable("PTFileResult");
        }
    }
}
