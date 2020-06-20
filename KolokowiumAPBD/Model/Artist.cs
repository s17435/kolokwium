using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolokowiumAPBD.Model
{
    public class Artist
    {
      

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdArtist { get; set; }

        [Required]
        [MaxLength(30)]
        public string NickName { get; set; }
    }
}