﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mocanu_Raluca_Lab2.Data;
using Mocanu_Raluca_Lab2.Models;

namespace Mocanu_Raluca_Lab2.Pages.Books
{
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Mocanu_Raluca_Lab2.Data.Mocanu_Raluca_Lab2Context _context;

        public CreateModel(Mocanu_Raluca_Lab2.Data.Mocanu_Raluca_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID",
          "PublisherName");
             var authorList = _context.Author.Select(x => new
                             {
                             x.ID,
                             FullName = x.LastName + " " + x.FirstName
                             });

            
            ViewData["AuthorID"] = new SelectList(authorList, "ID", "FullName");
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID",
           "PublisherName");

            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, book);

            return Page();

        }

        [BindProperty]
        public Book Book { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBook = new Book();
            if (selectedCategories != null)
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }
            if (!ModelState.IsValid || _context.Book == null || Book == null)
            {
                return Page();
            }

            Book.BookCategories = newBook.BookCategories;
            _context.Book.Add(Book);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
