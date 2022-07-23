using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RezContext:DbContext
    {
        //public RezContext(DbContextOptions<RezContext> options) :base(options)
        //{

        //}

        //public RezContext()
        //{
            

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RezervationDb;Trusted_Connection=True;");
        }

        public DbSet<RezRight> rezRights { get; set; }
        public DbSet<RezUser> rezUsers { get;set; }
        public DbSet<UserRight> userRights { get; set; }
        public DbSet<Place> places { get; set; }
        public DbSet<Rezervation> rezervations { get; set; }
    }
}
