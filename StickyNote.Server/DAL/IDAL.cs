using StickyNote.Server.Models;

namespace StickyNote.Server.DAL
{
    public interface IDAL<Tmodel> where Tmodel : BaseModel
    {
        public Task<Tmodel> CreateAsync(Tmodel model, CancellationToken token);
        public Task<Tmodel> UpdateAsync(Tmodel oldModel, Tmodel newModel, CancellationToken token);
        public Task DeleteAsync(string id, CancellationToken token);
        public Task<Tmodel> GetByIdAsync(string id, CancellationToken token);

        public Task<List<Tmodel>> GetAllAsync(CancellationToken token);
    }
}
