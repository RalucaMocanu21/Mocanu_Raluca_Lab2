using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mocanu_Raluca_Lab2.Models;

namespace Mocanu_Raluca_Lab2.Data
{
    public class Mocanu_Raluca_Lab2Context : DbContext
    {
        public Mocanu_Raluca_Lab2Context (DbContextOptions<Mocanu_Raluca_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Mocanu_Raluca_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Mocanu_Raluca_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Mocanu_Raluca_Lab2.Models.Category>? Category { get; set; }
    }
}
