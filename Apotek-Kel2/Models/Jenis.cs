using System.ComponentModel.DataAnnotations;

namespace Apotek_Kel2.Models
{
    public class Jenis
    {
        public String id { get; set; }

        [Required(ErrorMessage = "Nama Judul wajib diisi.")]
        public String namaJenis { get; set; }

    }

}
