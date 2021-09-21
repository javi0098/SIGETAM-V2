using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    public class PerfilBL
    {
        PerfilDAL perfilDAL = new PerfilDAL();
        public List<Componente> ObtenerTodosPermisos( ) 
        {
           
            return perfilDAL.ObtenerTodosPermisos();
        }

        public List<Componente> ObtenerTodosPermisos(UsuarioBE user)
        {

            return perfilDAL.ObtenerTodosPermisos(user);
        }

        public Componente ObtenerPerfilPorUsuario(UsuarioBE user)
        {
            return perfilDAL.ObtenerPerfilPorUsuario(user);
        }
    }
}
