using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NotesApp.Data;
using NotesApp.Models;

namespace NotesApp.Pages.Notes
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _db;
        public EditModel(AppDbContext db) => _db = db;

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
            if (!ModelState.IsValid) return Page();

            _db.Attach(Note).State = EntityState.Modified;

           await _db.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
