using DailyExpenses.Models;
using Microsoft.EntityFrameworkCore;

namespace DailyExpenses.Data
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<Products> products { get; set; }
    }
}
