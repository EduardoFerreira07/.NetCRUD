using EmployeAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeAdminPortal.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Employe> Employes { get; set; }
    }
}
