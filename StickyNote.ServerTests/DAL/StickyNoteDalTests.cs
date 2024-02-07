using Microsoft.VisualStudio.TestTools.UnitTesting;
using StickyNote.Server.DAL;
using StickyNote.Server.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNote.Server.DAL.Tests
{
    [TestClass()]
    public class StickyNoteDalTests
    {
        private StickyNoteDbContext dbcontext;
        StickyNoteDal stickyNoteDal;
        [TestInitialize]
        public void Initialize()
        {
             dbcontext = new StickyNoteDbContext();
            stickyNoteDal = new StickyNoteDal(dbcontext);
        }

        [TestCleanup]
        public void Cleanup() {
        dbcontext.Database.EnsureDeleted();
        }

   
        [TestMethod()]
        public async Task CreateAsyncTest()
        {
            var note = Create();
            var newnote = await stickyNoteDal.CreateAsync(note, CancellationToken.None);
            Assert.AreEqual(note.Id, newnote.Id);
        }

        [TestMethod()]
        public async Task DeleteAsyncTest()
        {
            var note = Create();

            var newnote = await stickyNoteDal.CreateAsync(note, CancellationToken.None);
            await stickyNoteDal.DeleteAsync(note.Id, CancellationToken.None);

            var oldnote = await stickyNoteDal.GetByIdAsync(note.Id, CancellationToken.None);

            Assert.IsNull(oldnote);


        }

        [TestMethod()]
        public async Task GetAllAsyncTest()
        {
            for(int i= 0; i < 10; i++) 
            {
                await stickyNoteDal.CreateAsync(Create(), CancellationToken.None);
            }

            var notes = await stickyNoteDal.GetAllAsync(cancellationToken: CancellationToken.None);

            Assert.AreEqual(10, notes.Count);

        }

        [TestMethod()]
        public async Task GetByIdAsyncTest()
        {
            var note = Create();
            await stickyNoteDal.CreateAsync(note, CancellationToken.None);

            var currentnote =  await stickyNoteDal.GetByIdAsync(note.Id, CancellationToken.None);

            Assert.AreEqual(note.Id, currentnote.Id);
        }

        [TestMethod()]
        public async Task UpdateAsyncTest()
        {
            var note = Create();

            var newnote = await stickyNoteDal.CreateAsync(note, CancellationToken.None);
           var notetoupdate = await stickyNoteDal.GetByIdAsync(note.Id, CancellationToken.None);

            notetoupdate.Title = "new title";
            notetoupdate.Description = "new descpriotion";

            await stickyNoteDal.UpdateAsync(note, notetoupdate, CancellationToken.None);


            var updatednote = await stickyNoteDal.GetByIdAsync(note.Id, CancellationToken.None);

            Assert.AreEqual(updatednote.Title, notetoupdate.Title);
            Assert.AreEqual(updatednote.Description, notetoupdate.Description); 

        }


        private StickyNoteModel Create()
        {
            var note = new StickyNoteModel();
            note.Title = "Test";
            note.Id = Guid.NewGuid().ToString();    
            note.Description = "Test";
            return note;
        }
    }
}