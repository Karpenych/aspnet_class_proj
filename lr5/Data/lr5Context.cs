using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lr5.Models;

namespace lr5.Data
{
    public class lr5Context : DbContext
    {
        public lr5Context (DbContextOptions<lr5Context> options)
            : base(options)
        {
        }

        public DbSet<lr5.Models.Author> Author { get; set; } = default!;
        public DbSet<lr5.Models.Book>   Book   { get; set; } = default!;
    }
}
