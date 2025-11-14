using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp.Data;
using NotesApp.Models;

namespace NotesApp.Pages.Notes
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _db;
        public CreateModel(AppDbContext db) => _db = db;

        [BindProperty]
        public Note Note { get; set; } = new Note();

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _db.Notes.Add(Note);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
