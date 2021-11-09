using Microsoft.EntityFrameworkCore;
using System;
using TicketProcessingRestApi.Entities;

namespace TicketProcessingRestApi.Repository
{
    public class TicketDbContext : DbContext
    {
        public TicketDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
   
      /*  */

    
