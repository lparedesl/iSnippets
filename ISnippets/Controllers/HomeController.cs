using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISnippets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ISnippets.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext _snippetsDb;

        public HomeController(MyDbContext snippetsDb)
        {
            _snippetsDb = snippetsDb;
        }

        // GET: /
        public async Task<IActionResult> Index()
        {
            return View(await _snippetsDb.Snippets.ToListAsync());
        }

        // GET: /Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snippet = await _snippetsDb.Snippets.SingleOrDefaultAsync(m => m.Id == id);
            if (snippet == null)
            {
                return NotFound();
            }

            return View(snippet);
        }

        // GET: /Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,CodeSnippet,Language")] Snippet snippet)
        {
            if (!ModelState.IsValid) return View(snippet);

            _snippetsDb.Snippets.Add(snippet);
            await _snippetsDb.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: /Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snippet = await _snippetsDb.Snippets.SingleOrDefaultAsync(m => m.Id == id);
            if (snippet == null)
            {
                return NotFound();
            }
            return View(snippet);
        }

        // POST: /Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,CodeSnippet,Language")] Snippet snippet)
        {
            if (id != snippet.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(snippet);

            try
            {
                _snippetsDb.Update(snippet);
                await _snippetsDb.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SnippetExists(snippet.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index");
        }

        // GET: /Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snippet = await _snippetsDb.Snippets.SingleOrDefaultAsync(m => m.Id == id);
            if (snippet == null)
            {
                return NotFound();
            }

            return View(snippet);
        }

        // POST: /Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var snippet = await _snippetsDb.Snippets.SingleOrDefaultAsync(m => m.Id == id);
            _snippetsDb.Snippets.Remove(snippet);
            await _snippetsDb.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SnippetExists(int id)
        {
            return _snippetsDb.Snippets.Any(e => e.Id == id);
        }
    }
}
