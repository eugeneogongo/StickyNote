using System.ComponentModel.DataAnnotations;

namespace StickyNote.Server.Models
{
    public abstract class BaseModel
    {
        protected BaseModel()
        {
            LastModifiedDate = DateTime.Now;
        }
        public string Id { get; set; }
        public DateTime? CreatedDate { get; private set; } = DateTime.Now;

        public DateTime? LastModifiedDate { get; private set; }
    }
}
