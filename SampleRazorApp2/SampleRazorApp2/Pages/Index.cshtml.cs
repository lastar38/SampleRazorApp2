using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SampleRazorApp2.Data;
using SampleRazorApp2.Models;

namespace SampleRazorApp2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SampleRazorApp2.Data.SampleRazorApp2Context _context;

        public IndexModel(SampleRazorApp2.Data.SampleRazorApp2Context context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; }

        public async Task OnGetAsync()
        {
            Person = await _context.Person.Include("Messages").ToListAsync();
        }
    }
}
