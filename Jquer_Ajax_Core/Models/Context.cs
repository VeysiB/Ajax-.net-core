using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jquer_Ajax_Core.Models
{
    public class Context:DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=AjaxCoreDb;Integrated Security=true;");
        }
        public DbSet<Kullanici> Kullanicilar { get; set; }
    }
}
