using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Conntact_Book.Data;
using Conntact_Book.Models;

namespace Conntact_Book.Pages.Contacts
{
    public class IndexModel : PageModel
    {
        private readonly Conntact_Book.Data.Conntact_BookContext _context;

        public IndexModel(Conntact_Book.Data.Conntact_BookContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList City { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ContactCity { get; set; }
        public IList<Contact> Contact { get;set; }

        public async Task OnGetAsync()
        {
            var contacts = from c in _context.Contact select c ;

            if(!string.IsNullOrEmpty(SearchString))
            {
                contacts = contacts.Where(s => s.Name.Contains(SearchString) 
                || s.Surname.Contains(SearchString) || s.Gender.Contains(SearchString)
                || s.Age.ToString().Contains(SearchString) || s.City.Contains(SearchString) 
                || s.PostCode.Contains(SearchString) || s.HomeNumber.Contains(SearchString));

                System.Diagnostics.Debug.Print(contacts.ToString());
            }

            Contact = await contacts.ToListAsync();
        }
    }
}
