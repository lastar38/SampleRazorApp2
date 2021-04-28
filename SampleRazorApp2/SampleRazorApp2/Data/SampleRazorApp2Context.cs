using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleRazorApp2.Models;

namespace SampleRazorApp2.Data
{
    public class SampleRazorApp2Context : DbContext
    {
        public SampleRazorApp2Context (DbContextOptions<SampleRazorApp2Context> options)
            : base(options)
        {
        }

        public DbSet<SampleRazorApp2.Models.Person> Person { get; set; }

        public DbSet<SampleRazorApp2.Models.Message> Message { get; set; }
    }
}
