using Jquer_Ajax_Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Jquer_Ajax_Core.Controllers
{
    public class HomeController : Controller
    {



        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult GetirHepsi()
        {
            using var context = new Context();
            var kullanicilar = context.Kullanicilar.ToList();

            var jsonData = JsonConvert.SerializeObject(kullanicilar);

            return Json(jsonData);
        }
        public IActionResult GetirIdIle(int kullaniciid)
        {
            using var context = new Context();
            var kullanici = context.Kullanicilar.FirstOrDefault(x => x.Id == kullaniciid);
            var jsondata = JsonConvert.SerializeObject(kullanici);
            return Json(jsondata);
        }
        [HttpPost]
        public void Guncelle(Kullanici kullanici)
        {
            using var context = new Context();
            var guncellenecekkullanici=context.Kullanicilar.Find(kullanici.Id);
            if (kullanici.File != null)
            {
                var benzersizIsim = Guid.NewGuid() + Path.GetExtension(kullanici.File.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" +benzersizIsim);
                var stream = new FileStream(path,FileMode.Create);
                kullanici.File.CopyTo(stream);

                guncellenecekkullanici.ResimAd = benzersizIsim;
            }
            guncellenecekkullanici.AdSoyad = kullanici.AdSoyad;
            context.Kullanicilar.Update(guncellenecekkullanici);
            context.SaveChanges();
        }
    }
}
