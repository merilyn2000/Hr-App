using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HrApp_WebAPI.Entities
{
    public class CompanyContext : IdentityDbContext<User>
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        //public DbSet<EmployeePersonalDatas> PersonalDatas { get; set; }
        public DbSet<EmployeeBankData> BankDatas { get; set; }
        public DbSet<EmployeeAddresses> Addresses { get; set; }
        public DbSet<EmployeeContracts> Contracts { get; set; }
        public DbSet<EmployeeContacts> Contacts { get; set; }
        public DbSet<EmployeeIdentityDocuments> IdentityDocuments { get; set; }
        public DbSet<EmployeeDependents> Dependents { get; set; }
        public DbSet<EmployeeVersions> Versions { get; set; }
    }
}