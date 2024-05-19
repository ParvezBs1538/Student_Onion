using Microsoft.EntityFrameworkCore;
using OA_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Repository
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Skill> Skills { get; set; }
    }
}
