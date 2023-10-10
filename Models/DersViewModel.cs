using System.ComponentModel.DataAnnotations;
using OkulYonetimPaneli.Data;

namespace OkulYonetimPaneli.Models
{
    public class DersViewModel
    {
        public int DersId { get; set; }

        [Required]
        [StringLength(50)]
        public string? Baslik { get; set; }
        public int OgretmenId { get; set; }
        public ICollection<DersKayit> DersKayitlari { get; set; } = new List<DersKayit>();
    }
    
}