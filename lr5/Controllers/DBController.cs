using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lr5.Data;
using lr5.Models;

namespace lr5.Controllers
{
    public class DBController : Controller
    {
        private readonly lr5Context _context;

        public static int ID_AUT = 0;
        public static string A_NAME = "";
        public static string MSG = "";
        public static List<string> BS = new();


        public DBController(lr5Context context)
        {
            _context = context;
        }

        // GET: DB
        public async Task<IActionResult> Index()
        {
              return _context.Author != null ? 
                          View(await _context.Author.ToListAsync()) :
                          Problem("Entity set 'lr5Context.Author'  is null.");
        }

        // GET: DB/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Author == null)
            {
                return NotFound();
            }

            var author = await _context.Author
                .FirstOrDefaultAsync(m => m.ID == id);
            if (author == null)
            {
                return NotFound();
            }

            BS = _context.Book.Where(b => b.Aut.ID == author.ID).Select(b => b.Title).ToList();

            return View(author);
        }

        // GET: DB/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DB/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Add(author);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: DB/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Author == null)
            {
                return NotFound();
            }

            var author = await _context.Author.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            ID_AUT = author.ID;
            A_NAME = author.Name;

            return View(author);
        }

        // POST: DB/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Author author)
        {
            if (id != author.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(author);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorExists(author.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: DB/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Author == null)
            {
                return NotFound();
            }

            var author = await _context.Author
                .FirstOrDefaultAsync(m => m.ID == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: DB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Author == null)
            {
                return Problem("Entity set 'lr5Context.Author'  is null.");
            }
            var author = await _context.Author.FindAsync(id);
            if (author != null)
            {
                _context.Author.Remove(author);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorExists(int id)
        {
          return (_context.Author?.Any(e => e.ID == id)).GetValueOrDefault();
        }

        [HttpGet]
        public ViewResult MemoriesBook(string ID)
        {
            MSG = "MemoriesBook: Get: Info = " + ID + ", " + A_NAME;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MemoriesBook()
        {
            string title = HttpContext.Request.Form["Title"];
            int AutID = Convert.ToInt32(HttpContext.Request.Form["AutID"]);
            Author author = _context.Author.Where(a => a.ID == AutID).Select(a => a).FirstOrDefault();
            Book b = new()
            {
                Aut = author,
                Title = title
            };
            author.AddBook(b); 
            await _context.SaveChangesAsync(); 

            return RedirectToAction(nameof(Index)); 
        }
    }
}
