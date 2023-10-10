using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OkulYonetimPaneli.Data;
using OkulYonetimPaneli.Models;

namespace OkulYonetimPaneli.Controllers
{
    public class DersKayitController : Controller
    {
        private readonly DataContext _context;
        public DersKayitController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dersKayitlari = await _context.DersKayitlari.Include(x => x.Ogrenci).Include(x => x.Ders).ToListAsync();
            return View(dersKayitlari);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Ogrenciler = new SelectList(await _context.Ogrenciler.ToListAsync(),"OgrenciId","AdSoyad");
            ViewBag.Dersler = new SelectList(await _context.Dersler.ToListAsync(),"DersId","Baslik");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DersKayit model)
        {
            model.KayitTarihi = DateTime.Now;
            _context.DersKayitlari.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            
            var dersk = await _context.DersKayitlari.FindAsync(id);

            if(dersk == null)
            {
                return NotFound();
            }

            return View(dersk);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
           var dersk = await _context.DersKayitlari.FindAsync(id);
           if(dersk == null)
           {
            return NotFound();
           }
           _context.DersKayitlari.Remove(dersk);
           await _context.SaveChangesAsync();
           return RedirectToAction("Index");
        }

    }
} 