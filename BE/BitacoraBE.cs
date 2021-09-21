using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BitacoraBE
    {
        public enum Incidencia
        {
         Sesion = 1,
         Perfil = 2
        }
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public Incidencia Tipo_incidencia { get; set; }

        public string NombreUsuario { get; set; }

    }
}
