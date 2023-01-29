using SQLite;
using System.Reflection.Metadata;

namespace STRAYS.Models
{
    [Table("info")]
    public class InfoModel
    {
        [PrimaryKey, AutoIncrement]
        public int IdInfo { get; set; }

        [MaxLength(30)]
        public string Titulo { get; set; }

        [MaxLength(30)]
        public string Sexo { get; set; }

        [MaxLength(30)]
        public string Raza { get; set; }

        [MaxLength(50)]
        public string Ubicacion { get; set; }

        [MaxLength(400)]
        public string Descripcion { get; set; }

        public string Imagen { get; set; }

        public DateTime Date { get; set; }
    }
}
