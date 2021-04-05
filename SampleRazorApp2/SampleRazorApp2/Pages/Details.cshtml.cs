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
    public class DetailsModel : PageModel
    {
        private readonly SampleRazorApp2.Data.SampleRazorApp2Context _context;

        public DetailsModel(SampleRazorApp2.Data.SampleRazorApp2Context context)
        {
            _context = context;
        }

        public Person Person { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = await _context.Person.FirstOrDefaultAsync(m => m.PersonId == id);

            if (Person == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
