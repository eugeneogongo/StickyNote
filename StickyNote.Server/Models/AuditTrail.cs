namespace StickyNote.Server.Models
{
    public class AuditTrail : BaseModel
    {
        public AuditTrail()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Method { get; set; }
    }
}
