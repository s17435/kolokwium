using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolokowiumAPBD.Model
{
    public class Artist_Event
    {
        [ForeignKey("Artist")]
        public int? IdArtist { get; set; }
        public virtual Artist Artist { get; set; }

        [ForeignKey("Event")]
        public int? IdEvent { get; set; }
        public virtual Event Event { get; set; }
        
        [Required]
        public DateTime PerformanceDate { get; set; }
        
    }
}