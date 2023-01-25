﻿using SQLite;

namespace STRAYS.Models
{
    [Table("alerta")]
    public class AlertaModel
    {
        [PrimaryKey, AutoIncrement]
        public int IdAlerta { get; set; }

        [MaxLength(30)]
        public string Titulo { get; set; }

        [MaxLength(30)]
        public string Sexo { get; set; }

        [MaxLength(30)]
        public string Raza { get; set; }

        [MaxLength(50)]
        public string Ubicacion { get; set; }

        [MaxLength(200)]
        public string Descripcion { get; set; }

        [MaxLength(300)]
        public string urlImagen { get; set; }

        public DateTime Date { get; set; }
    }
}
