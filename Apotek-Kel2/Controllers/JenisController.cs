using Apotek_Kel2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Apotek_Kel2.Controllers
{
    public class JenisController : Controller
    {
        private static List<Jenis> jeniss = InitializeData();

        private static List<Jenis> InitializeData()
        {
            List<Jenis> initialData = new List<Jenis>()
            {
                new Jenis
                {
                    id = "JNS001",
                    namaJenis = "Obat Keras"
                },
                new Jenis
                {
                    id = "JNS002",
                    namaJenis = "Obat Ringan"
                }
            };
            return initialData;
        }
        public IActionResult Index()
        {
            List<Jenis> jenisList = jeniss.ToList();
            return View(jenisList);
        }


        [HttpGet]
        public IActionResult Create()
        {
            Jenis jenis = new Jenis();
            int maxId = jeniss.Max(j => int.TryParse(j.id.Replace("JNS", ""), out int id) ? id : 0);
            int nextId = maxId + 1;
            string new_id = $"JNS{nextId:D3}";
            jenis.id = new_id;

            return View(jenis);
        }


        [HttpPost]
        public IActionResult Create(Jenis jenis)
        {
            if (ModelState.IsValid)
            {
                int maxId = jeniss.Max(j => int.TryParse(j.id.Replace("JNS", ""), out int id) ? id : 0);
                int nextId = maxId + 1;
                string new_id = $"JNS{nextId:D3}";

                jenis.id = new_id;

                jeniss.Add(jenis);
                TempData["SuccessMessage"] = "Data berhasil ditambahkan";
                return RedirectToAction("Index");
            }
            return View(jenis);
        }


        [HttpPost]
        public IActionResult Delete(String id)
        {
            var response = new { success = false, message = "Gagal menghapus Jenis Obat." };

            try
            {
                var jenisBuku = jeniss.FirstOrDefault(b => b.id == id);
                if (jenisBuku != null)
                {
                    jeniss.Remove(jenisBuku);
                    response = new { success = true, message = "Jenis Obat berhasil dihapus." };
                }
                else
                {
                    response = new { success = false, message = "Jenis Obat tidak ditemukan." };
                }
            }
            catch (Exception ex)
            {
                response = new { success = false, message = ex.Message };
            }

            return Json(response);
        }

        [HttpGet]
        public IActionResult Edit(String id)
        {
            Jenis jenis = jeniss.FirstOrDefault(b => b.id == id);

            if (jenis == null)
            {
                return NotFound();
            }

            return View(jenis);
        }

        [HttpPost]
        public IActionResult Edit(Jenis jenis)
        {
            if (ModelState.IsValid)
            {
                Jenis newJenis = jeniss.FirstOrDefault(b => b.id == jenis.id);

                if (newJenis == null)
                {
                    return NotFound();
                }

                newJenis.namaJenis = jenis.namaJenis;

                TempData["SuccessMessage"] = "Jenis Obat berhasil diupdate.";
                return RedirectToAction("Index");
            }

            return View(jenis);
        }
    }
}
