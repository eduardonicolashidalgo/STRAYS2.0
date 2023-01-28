using SQLite;
using System.Reflection.Metadata;

namespace STRAYS.Models
{
    [Table("pae")]
    public class PaeModel
    {
        [PrimaryKey, AutoIncrement]
        public int IdPae { get; set; }

        [MaxLength(30)]
        public string Nombre { get; set; }

        [MaxLength(30)]
        public string Sexo { get; set; }

        public int Edad { get; set; }

        [MaxLength(30)]
        public string Raza { get; set; }

        [MaxLength(30)]
        public string Tamano { get; set; }

        [MaxLength(200)]
        public string Descripcion { get; set; }

        public byte[] Imagen { get; set; }

        public DateTime Date { get; set; }
    }
}
