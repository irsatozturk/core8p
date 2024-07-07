using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace proje1.Models
{
    public class Kategori
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30,ErrorMessage ="En fazla 30 karakter girilebilir")]
        [DisplayName("Kategori Adı")]
        public string Name { get; set; }
        [DisplayName("Sıra Numarası")]
        [Range(1,100,ErrorMessage ="Rakam aralığı 1 ile 100 arasında olmalı")]
        public int DisplayOrder { get; set; }
    }
}
