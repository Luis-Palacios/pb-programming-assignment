using csv_import.domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
