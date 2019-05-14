using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using linkus_tv;

namespace linkus_tv.Models
{
    public class linkus_tvContext : DbContext
    {
        public linkus_tvContext (DbContextOptions<linkus_tvContext> options)
            : base(options)
        {
        }

        public DbSet<carte> Carte { get; set; }
    }
}
