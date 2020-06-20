using System.Collections.Generic;
using KolokowiumAPBD.Model;

namespace KolokowiumAPBD.DTO
{
    public class ArtistDTO
    {
        public Artist Artist { get; set; }
        public List<Event> Events { get; set; }
    }
}