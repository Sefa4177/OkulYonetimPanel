using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OkulYonetimPaneli.Data
{
    public class Ders
    {   
        [DisplayName("Ders ID")]
        public int DersId { get; set; }

        [DisplayName("Ders Adı")]
        public string? Baslik { get; set; }
        
        public int OgretmenId { get; set; }
        public Ogretmen Ogretmen { get; set; } = null!;
        public ICollection<DersKayit> DersKayitlari { get; set; } = new List<DersKayit>();
    }
    
}