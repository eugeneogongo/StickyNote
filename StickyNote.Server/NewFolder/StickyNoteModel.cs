﻿using System.ComponentModel.DataAnnotations;

namespace StickyNote.Server.NewFolder
{
    public class StickyNoteModel : BaseModel
    {
       
        [Required]
        [MaxLength(120)]
        public string Title { get; set; }
        [MaxLength(1024)]
        public string Description { get; set; }
      
    }
}