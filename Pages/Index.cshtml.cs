using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NotesApp.Data;
using NotesApp.Models;



namespace NotesApp.Pages.Notes
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;
        public IndexModel(AppDbContext db) => _db = db;

        public IList<Note> Notes { get; set; } = new List<Note>();

        public async Task OnGetAsync()
        {
            Notes = await _db.Notes.OrderByDescending(n => n.CreatedAt).ToListAsync();
        }
    }
}
