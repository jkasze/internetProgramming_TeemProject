using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace internetProgramming_TeemProject.Models
{
    public class InstituteContext : DbContext
    {
        public InstituteContext(DbContextOptions<InstituteContext> options)
        : base(options)
        {
        }

        public DbSet<InstituteContext> InstituteItems { get; set; }
    }
}
