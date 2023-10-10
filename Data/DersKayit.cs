using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OkulYonetimPaneli.Data
{
    public class DersKayit
    {
        [Key]
        [DisplayName("Kayıt ID")]
        public int KayitId { get; set; }

        public int OgrenciId { get; set; }
        public Ogrenci Ogrenci { get; set; } = null!;

        public int DersId { get; set; }
        public Ders Ders { get; set; } = null!;
        
        public DateTime KayitTarihi { get; set; }
    }
}