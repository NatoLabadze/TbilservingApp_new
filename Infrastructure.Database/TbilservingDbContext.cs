using Core.Domain;
using Core.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database
{
    public class TbilservingDbContext : DbContext
    {
        public TbilservingDbContext(DbContextOptions<TbilservingDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Statement> Statements { get; set; }
        public DbSet<Message> Messages { get; set; }
      //  public DbSet<MessageType> MessageType { get; set; }





    }
}
