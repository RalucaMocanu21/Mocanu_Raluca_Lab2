using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mocanu_Raluca_Lab2.Data;
using Mocanu_Raluca_Lab2.Models;

namespace Mocanu_Raluca_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Mocanu_Raluca_Lab2.Data.Mocanu_Raluca_Lab2Context _context;

        public IndexModel(Mocanu_Raluca_Lab2.Data.Mocanu_Raluca_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Category != null)
            {
                List<Category> categories = await _context.Category.ToListAsync();
                Category = categories;
            }
        }
    }
}
