using System.ComponentModel.DataAnnotations.Schema;

namespace Gluogli.Models {
   [Table("pagina")]
   public class Pagina {
        [Column("id")]
        public int Id { get; set; }
        [Column("link")]
        public string Link { get; set; }
        [Column("titulo")]
        public string Titulo { get; set; }

    }
}