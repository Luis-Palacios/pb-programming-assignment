using csv_import.datalayer.Configurations;
using csv_import.domain;
using System.Data.Entity;

namespace csv_import.datalayer
{
    public class AccountManagerContext : DbContext
    {
        public DbSet<File> Files { get; set; }

        public DbSet<ImportResult> ImportResults { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FileDetailMapping());
            modelBuilder.Configurations.Add(new ImportResultMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
