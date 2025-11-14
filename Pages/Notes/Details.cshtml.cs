using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp.Data;
using NotesApp.Models;

namespace NotesApp.Pages.Notes
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _db;
        public DetailsModel(AppDbContext db) => _db = db;

        public Note Note { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Note = await _db.Notes.FindAsync(id);
            if (Note == null) return NotFound();
            return Page();
        }
    }
}
