using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NumberCount2.Model;

namespace NumberCount2.Models
{
    public class NumberCount2Context : DbContext
    {
        public NumberCount2Context (DbContextOptions<NumberCount2Context> options)
            : base(options)
        {
        }

        public DbSet<NumberCount2.Model.NumberSeries> NumberSeries { get; set; }
    }
}
