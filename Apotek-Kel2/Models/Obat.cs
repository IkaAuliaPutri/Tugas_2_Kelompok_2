using System.ComponentModel.DataAnnotations;

namespace Apotek_Kel2.Models
{
    public class Obat
    {
        public String id { get; set; }

        [Required(ErrorMessage = "Nama Obat wajib diisi.")]
        public string namaObat { get; set; }

        [Required(ErrorMessage = "Merk Obat wajib diisi.")]
        public string merkObat { get; set; }

        [Required(ErrorMessage = "Deskripsi Obat wajib diisi.")]
        public String id_jenis { get; set; }

        [Required(ErrorMessage = "Jenis Obat wajib diisi.")]
        public string deskripsiObat { get; set; }

        [Required(ErrorMessage = "Harga Obat wajib diisi.")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Harga Obat hanya boleh mengandung angka.")]
        public float hargaObat { get; set; }

        [Required(ErrorMessage = "Stok Obat wajib diisi.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Stok Obat hanya boleh mengandung angka.")]
        public int stokObat { get; set; }

        [Required(ErrorMessage = "Tanggal Kadaluarsa wajib diisi.")]
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "Format tanggal tidak valid. Gunakan format yyyy-MM-dd.")]
        public String expObat { get; set; }

    }
}
