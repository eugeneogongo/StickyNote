using Microsoft.AspNetCore.Mvc;
using StickyNote.Server.DAL;
using StickyNote.Server.NewFolder;

namespace StickyNote.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StickyNoteController : ControllerBase
    {
        public StickyNoteController(IDAL<StickyNoteModel> Idal)
        {
            this.Idal = Idal;
        }

        public IDAL<StickyNoteModel> Idal { get; }

        [HttpGet]
        [Route("/all")]
        public async Task<List<StickyNoteModel>> GetAll(CancellationToken token)
        {
            return await Idal.GetAllAsync(token);
        }

        [HttpGet]

        public async Task<IActionResult> Get(string id, CancellationToken token)
        {
            var note = await Idal.GetByIdAsync(id, token);

            if(note == null)
            {
                return NotFound();

            }
            return Ok(note);
        }

        [HttpDelete]
        public async Task Delete(string id)
        {
            await Idal.DeleteAsync(id, CancellationToken.None);
        }

        [HttpPut]
        public async Task<IActionResult> Create(StickyNoteModel model, CancellationToken token)
        {
            model.Id = Guid.NewGuid().ToString();
            var note = await Idal.CreateAsync(model, token);

            return Created();
        }

        [HttpPatch]
        public async Task<IActionResult> Update(StickyNoteModel model, CancellationToken token)
        {
            var note = await Idal.GetByIdAsync(model.Id, token);

            if (note == null)
            {
                return NotFound();
            }
            await Idal.UpdateAsync(note,model, token);

            return Created();
        }
    }
}
