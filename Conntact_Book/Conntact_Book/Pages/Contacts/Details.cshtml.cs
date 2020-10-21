using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Conntact_Book.Data;
using Conntact_Book.Models;

namespace Conntact_Book.Pages.Contacts
{
    public class DetailsModel : PageModel
    {
        private readonly Conntact_Book.Data.Conntact_BookContext _context;

        public DetailsModel(Conntact_Book.Data.Conntact_BookContext context)
        {
            _context = context;
        }

        public Contact Contact { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contact = await _context.Contact.FirstOrDefaultAsync(m => m.Id == id);

            if (Contact == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
