using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Conntact_Book.Models;

namespace Conntact_Book.Data
{
    public class Conntact_BookContext : DbContext
    {
        public Conntact_BookContext (DbContextOptions<Conntact_BookContext> options)
            : base(options)
        {
        }

        public DbSet<Conntact_Book.Models.Contact> Contact { get; set; }
    }
}
