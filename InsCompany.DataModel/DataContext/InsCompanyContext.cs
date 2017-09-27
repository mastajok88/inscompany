using System.Data.Entity;
using InsCompany.DataModel.Models;

namespace InsCompany.DataModel.DataContext
{
    public class InsCompanyContext : DbContext
    {
        public DbSet<Risk> Risks { get; set; }

        public InsCompanyContext() : base("name=TestDefault")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<InsCompanyContext>());
        }
    }
}