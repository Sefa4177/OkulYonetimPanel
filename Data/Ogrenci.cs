using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OkulYonetimPaneli.Data
{
    public class Ogrenci
    {
        [Key]
        [DisplayName("Öğrenci ID")]
        public int OgrenciId { get; set; }

        [DisplayName("Ad")]
        public string? OgrenciAd { get; set; }

        [DisplayName("Soyad")]
        public string? OgrenciSoyad { get; set; }   

        [DisplayName("Öğrencinin Adı Soyadı")]
        public string AdSoyad 
        { 
            get
            {
                return this.OgrenciAd + " " + OgrenciSoyad;
            }
        }
        public string? OgrenciEposta { get; set; }   
        public string? OgrenciTelefon { get; set; }  

        public ICollection<DersKayit> DersKayitlari { get; set; } = new List<DersKayit>(); 
    }
}