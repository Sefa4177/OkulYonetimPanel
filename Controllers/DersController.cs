using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OkulYonetimPaneli.Data;
using OkulYonetimPaneli.Models;

namespace OkulYonetimPaneli.Controllers
{
    public class DersController: Controller
    {
        private readonly DataContext _context;

        public DersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dersler.Include(d => d.Ogretmen).ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenId", "AdSoyad");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DersViewModel model)
        {
            if(ModelState.IsValid)
            {
                _context.Dersler.Add(new Ders() {DersId = model.DersId, Baslik = model.Baslik, OgretmenId = model.OgretmenId});
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenId", "AdSoyad");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit (int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var drs = await _context.Dersler.Include(d => d.DersKayitlari).ThenInclude(d => d.Ogrenci).Select(d => new DersViewModel{DersId = d.DersId, Baslik = d.Baslik, OgretmenId = d.OgretmenId, DersKayitlari = d.DersKayitlari}).FirstOrDefaultAsync(d => d.DersId == id);

            if(drs == null)
            {
                return NotFound();
            }
            ViewBag.Ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenId", "AdSoyad");
            return View(drs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int? id , DersViewModel model)
        {
            if ( id != model.DersId)
            {
                return NotFound();
            }

            if( ModelState.IsValid)
            {
                try
                {
                    _context.Update(new Ders() {DersId = model.DersId, Baslik = model.Baslik, OgretmenId = model.OgretmenId});
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!_context.Dersler.Any(o => o.DersId == model.DersId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewBag.Ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenId", "AdSoyad");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            
            var ders = await _context.Dersler.FindAsync(id);

            if(ders == null)
            {
                return NotFound();
            }

            return View(ders);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
           var ders = await _context.Dersler.FindAsync(id);
           if(ders == null)
           {
            return NotFound();
           }
           _context.Dersler.Remove(ders);
           await _context.SaveChangesAsync();
           return RedirectToAction("Index");
        }

    }
}