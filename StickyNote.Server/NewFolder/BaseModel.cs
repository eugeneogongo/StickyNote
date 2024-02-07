using System.ComponentModel.DataAnnotations;

namespace StickyNote.Server.NewFolder
{
    public abstract class BaseModel
    {
        protected BaseModel()
        {
            this.LastModifiedDate = DateTime.Now;
        }
        public string Id { get;  set; }
        public DateTime? CreatedDate { get; private set; } = DateTime.Now;

        public DateTime? LastModifiedDate { get; private set; }
    }
}
