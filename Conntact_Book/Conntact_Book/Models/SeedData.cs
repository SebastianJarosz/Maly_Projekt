using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Conntact_Book.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conntact_Book.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new Conntact_BookContext(serviceProvider.GetRequiredService<
                DbContextOptions<Conntact_BookContext>>()))
            {
                //Szukaj kontaktów
                if (context.Contact.Any())
                {
                    return;
                }

                context.Contact.AddRange(
                    new Contact
                    {
                        Name = "Joanna",
                        Surname = "Nowak",
                        Age = 18,
                        Gender = "Kobieta",
                        City = "Poznań",
                        PostCode = "60-333",
                        Street = "Poznańska",
                        HomeNumber = "14/1"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
