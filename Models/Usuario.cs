using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultarNotasRecoleccion.Models
{
    public class Usuario
    {
        public int IdUsuario{ get; set; }

        public string CodigoAlumno { get; set; }
        public string AnioEscolar { get; set; }
        public string Bimensual { get; set; }
    }
}
