using Microsoft.EntityFrameworkCore;
using Project.Areas.Admin.Models;

namespace Project.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {
        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<AboutUs> AboutUss { get; set; }
        public DbSet<TravelTip> TravelTipss { get; set; }
        public DbSet<AdminMenu> AdminMenus { get; set; }
    }
}
