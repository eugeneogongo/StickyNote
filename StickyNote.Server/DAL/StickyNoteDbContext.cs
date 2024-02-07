using Microsoft.EntityFrameworkCore;
using StickyNote.Server.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StickyNote.Server.DAL
{
    public class StickyNoteDbContext : DbContext
    {
        public string DbPath= "Data Source=stickynotes.db;";
        public DbSet<StickyNoteModel> StickyNotes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(DbPath);
            
        }
    }
}
