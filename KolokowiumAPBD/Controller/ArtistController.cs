using System;
using System.Linq;
using KolokowiumAPBD.DTO;
using KolokowiumAPBD.Model;
using Microsoft.AspNetCore.Mvc;

namespace KolokowiumAPBD.Controller
{
    [Route("api/concert")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly KolokwiumDbContext _context;

        public ArtistController(KolokwiumDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetArtist(string id)
        {
            ArtistDTO a = new ArtistDTO();
            a.Artist = _context.Artist.Where((a => a.IdArtist == int.Parse(id))).FirstOrDefault();
            if (a.Artist == null)
            {
                return NotFound("Brak artysty");
            }

            var tmp = _context.Artist_Event.Where((a => a.IdArtist == int.Parse(id)));
            foreach (var aE in tmp)
            {
                var x = _context.Event.Where(e => e.IdEvent == aE.IdEvent).FirstOrDefault();
                if (x == null) continue;
                if (!a.Events.Contains(x))
                {
                    a.Events.Add(h);
                }
            }

            a.Events = a.Events.OrderByDescending(e => e.StartDate).ToList();
            return Ok(a);
        }


        [HttpPut]
        public IActionResult UpdateEvent(ArtistEventDTO artistEventDto)
        {
            var artist = _context.Artist.FirstOrDefault(h => h.IdArtist == artistEventDto.idArtist);
            if (artist == null)
            {
                return NotFound("Nie znaleziono artysty");
            }

            var event1 = _context.Event.FirstOrDefault(h => h.IdEvent == artistEventDto.idEvent);
            if (event1 == null)
            {
                return NotFound("Nie znaleziono wydarzenia");
            }

            var artistEvent = _context.Artist_Event
                .Where(h => h.IdArtist == artist.idArtist && h.IdEvent == artistEventDto.idEvent).FirstOrDefault();
            if (artistEvent == null)
            {
                return NotFound("Nie znaleziono artysty w wydarzeniu");
            }

            if (e.StartDate < DateTime.Now)
            {
                return NotFound("Event sie juz zaczal");
            }

            if (artistEventDto.performaceDate < event1.StartDate || artistEvent.performaceDate > event1.EndDate)
            {
                {
                    return NotFound("Nowy czas jest poza eventem");
                }



            }

            artistEvent.performanceDate = artistEventDto.performanceDate;
            return Ok("Zapisano datę");

        }
    }
}