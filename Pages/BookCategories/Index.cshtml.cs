using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mocanu_Raluca_Lab2.Data;
using Mocanu_Raluca_Lab2.Models;

namespace Mocanu_Raluca_Lab2.Pages.BookCategories
{
    public class IndexModel : PageModel
    {
        private readonly Mocanu_Raluca_Lab2.Data.Mocanu_Raluca_Lab2Context _context;

        public IndexModel(Mocanu_Raluca_Lab2.Data.Mocanu_Raluca_Lab2Context context)
        {
            _context = context;
        }

        public IList<BookCategory> BookCategory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.BookCategory != null)
            {
                BookCategory = await _context.BookCategory
                .Include(b => b.Book)
                .Include(b => b.Category).ToListAsync();
            }
        }
    }
}
