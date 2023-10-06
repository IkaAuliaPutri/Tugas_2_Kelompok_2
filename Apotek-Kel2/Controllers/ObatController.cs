using Apotek_Kel2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Apotek_Kel2.Controllers
{
    public class ObatController : Controller
    {
        private static List<Obat> obats = InitializeData();

        public static List<Obat> InitializeData()
        {
            List<Obat> initialData = new List<Obat>
            {
                new Obat
                {
                    id = "OBT001",
                    namaObat = "Parasetamol",
                    id_jenis = "JNS001",
                    hargaObat = 1200,
                    stokObat = 15,
                    expObat ="2023-10-10"
                },
                new Obat
                {
                    id = "OBT002",
                    namaObat = "Sanmol",
                    id_jenis = "JNS002",
                    hargaObat = 1700,
                    stokObat = 10,
                    expObat = "2023-10-1"
                }
            };
            return initialData;
        }

        public IActionResult Index()
        {
            List<Obat> obatList = obats.ToList();
            return View(obatList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Obat obat = new Obat();
            int maxId = obats.Max(j => int.TryParse(j.id.Replace("OBT", ""), out int id) ? id : 0);
            int nextId = maxId + 1;
            string new_id = $"OBT{nextId:D3}";
            obat.id = new_id;


            return View(obat);
        }


        [HttpPost]
        public IActionResult Create(Obat obat)
        {
            if (ModelState.IsValid)
            {
                int maxId = obats.Max(j => int.TryParse(j.id.Replace("OBT", ""), out int id) ? id : 0);
                int nextId = maxId + 1;
                string new_id = $"OBT{nextId:D3}";

                obat.id = new_id;

                obats.Add(obat);
                TempData["SuccessMessage"] = "Data berhasil ditambahkan";
                return RedirectToAction("Index");
            }
            return View(obat);
        }

        [HttpPost]
        public IActionResult Delete(String id)
        {
            var response = new { success = false, message = "Gagal menghapus Obat." };

            try
            {
                var obat = obats.FirstOrDefault(b => b.id == id);
                if (obat != null)
                {
                    obats.Remove(obat);
                    response = new { success = true, message = "Obat berhasil dihapus." };
                }
                else
                {
                    response = new { success = false, message = "Obat tidak ditemukan." };
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
            Obat obat = obats.FirstOrDefault(b => b.id == id);

            if (obat == null)
            {
                return NotFound();
            }

            return View(obat);
        }

        [HttpPost]
        public IActionResult Edit(Obat obat)
        {
            if (ModelState.IsValid)
            {
                Obat newObat = obats.FirstOrDefault(b => b.id == obat.id);

                if (newObat == null)
                {
                    return NotFound();
                }

                newObat.namaObat = obat.namaObat;
                newObat.id_jenis = obat.id_jenis;
                newObat.hargaObat = obat.hargaObat;
                newObat.stokObat = obat.stokObat;
                newObat.expObat = obat.expObat;

                TempData["SuccessMessage"] = "Obat berhasil diupdate.";
                return RedirectToAction("Index");
            }

            return View(obat);
        }
        
    }
}
