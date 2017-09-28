using System.Data.Entity;
using InsCompany.DataAccess.Models;

namespace InsCompany.DataAccess.DataContext
{
    public class InsCompanyContext : DbContext
    {
        public DbSet<Risk> Risks { get; set; }

        public DbSet<Policy> Policies { get; set; }

        public InsCompanyContext() : base("TestDefault")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<InsCompanyContext>());
        }
    }
}