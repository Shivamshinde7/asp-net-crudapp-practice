using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp.Data;
using NotesApp.Models;

namespace NotesApp.Pages.Notes
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _db;
        public DeleteModel(AppDbContext db) => _db = db;

        [BindProperty]
        public Note Note { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Note = await _db.Notes.FindAsync(id);
            if (Note == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var note = await _db.Notes.FindAsync(Note.Id);
            if (note != null)
            {
                _db.Notes.Remove(note);
                await _db.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}
