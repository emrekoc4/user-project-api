using Microsoft.EntityFrameworkCore;
using UserProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UserProject.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //proje içindeki tüm configurationları uygular(configuration dosyalarını kalıtım aldıkları interface üzerinden tanır)

            base.OnModelCreating(modelBuilder);
        }
    }
}
