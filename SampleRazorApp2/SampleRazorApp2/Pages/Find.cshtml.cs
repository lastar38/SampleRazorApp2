using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SampleRazorApp2.Models;

namespace SampleRazorApp2.Pages
{
    public class FindModel : PageModel
    {
        private readonly SampleRazorApp2.Data.SampleRazorApp2Context _context;
        public IList<Person> People { get; set; }

        [BindProperty(SupportsGet = true)]
        public int p { get; set; }

        [BindProperty(SupportsGet = true)]
        public int n { get; set; }

        public FindModel(SampleRazorApp2.Data.SampleRazorApp2Context context)
        {
            _context = context;
        }

        public async Task GetTaskAsync()
        {
            People = await _context.Person.ToListAsync();
        }

        public async Task OnPostAsync(string Find)
        {
            //int n = Int32.Parse(Find);
            People = await _context.Person.Where(m => m.Mail.EndsWith(Find)).ToListAsync();
        }

        public async Task OnGetAsync()
        {
            IQueryable<Person> result = _context.Person.FromSqlRaw("select * from person order by PersonId desc");
            People = await result.ToListAsync();
        }
    }
}
