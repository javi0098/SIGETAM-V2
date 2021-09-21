using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class UsuarioBE
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }

        public string Email { get; set; }

        public Componente Perfil { get; set; }

        public List<Componente> Permisos { get; set; }

        public bool Activo { get; set; }

        public bool Bloqueado { get; set; }

        public override string ToString()
        {
            return NombreUsuario;
        }

    }
}
