using System.ComponentModel.DataAnnotations.Schema;

namespace KolokowiumAPBD.Model
{
    public class Event_Organiser
    {
        [ForeignKey("Organiser")]
        public int? IdOrganiser { get; set; }
        public virtual Organiser Organiser { get; set; }
        
        [ForeignKey("Event")]
        public int? IdEvent { get; set; }
        public virtual Event Event { get; set; }
    }
}