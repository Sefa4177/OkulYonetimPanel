using Microsoft.EntityFrameworkCore;
using OkulYonetimPaneli.Models;

namespace OkulYonetimPaneli.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }
        public DbSet<Ders> Dersler => Set<Ders>();
        public DbSet<Ogrenci> Ogrenciler => Set<Ogrenci>();
        public DbSet<DersKayit> DersKayitlari => Set<DersKayit>();
        public DbSet<Ogretmen> Ogretmenler => Set<Ogretmen>();
    }
}