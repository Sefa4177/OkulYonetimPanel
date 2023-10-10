using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OkulYonetimPaneli.Data
{

    public class Ogretmen
    {

        [Key]
        [DisplayName("Öğretmen ID")]
        public int OgretmenId { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }

        [DisplayName("Öğretmenin Adı Soyadı")]
        public string AdSoyad 
        { 
            get
            {
                return this.Ad + " " + Soyad;
            }
        }
        public string? Eposta { get; set; }
        public string? Telefon { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("İşe Başlama Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime BaslamaTarihi { get; set; }
        public ICollection<Ders> Dersler { get; set; } = new List<Ders>();
    }
}