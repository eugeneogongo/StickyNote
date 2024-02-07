using Microsoft.EntityFrameworkCore;
using StickyNote.Server.Models;

namespace StickyNote.Server.DAL
{
    public class StickyNoteDal : IDAL<StickyNoteModel>
    {
        private StickyNoteDbContext dbContext;

        public StickyNoteDal(StickyNoteDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbContext.Database.EnsureCreated();
            dbContext.Database.Migrate();
        }
        public async Task<StickyNoteModel> CreateAsync(StickyNoteModel model, CancellationToken token)
        {
            dbContext.Add(model);
           await dbContext.SaveChangesAsync(token);
            return model;
        }

        public async Task DeleteAsync(string id, CancellationToken token)
        {
            var note = dbContext.StickyNotes.Where(x => x.Id == id).First();
            dbContext.StickyNotes.Remove(note);
            await dbContext.SaveChangesAsync(token);
        }

        public Task<List<StickyNoteModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            return dbContext.StickyNotes.OrderBy(x=>x.CreatedDate).ToListAsync(cancellationToken);
        }

        public async Task<StickyNoteModel> GetByIdAsync(string id, CancellationToken token)
        {
            var note = await dbContext.StickyNotes.Where(x => x.Id == id).FirstOrDefaultAsync(token);

            return note;
        }

        public async Task<StickyNoteModel> UpdateAsync(StickyNoteModel oldModel,StickyNoteModel newModel, CancellationToken token)
        {
            dbContext.Entry(oldModel).CurrentValues.SetValues(newModel);
            await dbContext.SaveChangesAsync(token);
            return newModel;
        }
    }
}
