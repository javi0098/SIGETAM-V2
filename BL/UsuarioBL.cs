using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.Composite;
using DAL;
using SERVICE;

namespace BL
{
    public class UsuarioBL
    {
        private PerfilBL perfilBL= new PerfilBL();
        private BitacoraBL bitacora = new BitacoraBL();
        private BitacoraBE bitacoraBE = new BitacoraBE();
        private UsuarioDAL dAL = new UsuarioDAL();

        public UsuarioBE Login(string user, string pass) 
        {
            
           
            UsuarioBE BE = dAL.Login(user, pass);
            if (BE != null) 
            {
                BE.Perfil = perfilBL.ObtenerPerfilPorUsuario(BE); ;
                BE.Permisos = perfilBL.ObtenerTodosPermisos(BE);
                var sesion = Sesion_Manager.CrearSesion(BE);
                bitacoraBE.Descripcion = "Inicio de Sesion Exitoso";
                bitacoraBE.Fecha = DateTime.Parse(System.DateTime.Now.ToShortDateString().ToString());
                bitacoraBE.NombreUsuario = BE.NombreUsuario;
                bitacoraBE.Tipo_incidencia = BitacoraBE.Incidencia.Sesion;
                bitacora.Guardar(bitacoraBE);

            }
            else
            {
                //error de contraseña o usuario
                bitacoraBE.Descripcion = "Error de Inicio de Sesion";
                bitacoraBE.Fecha = DateTime.Parse(System.DateTime.Now.ToShortDateString().ToString());
                if (BE == null) 
                {
                    bitacoraBE.NombreUsuario = "Nulo";
                }
                else
                {
                    bitacoraBE.NombreUsuario = BE.NombreUsuario;
                }
                
                bitacoraBE.Tipo_incidencia = BitacoraBE.Incidencia.Sesion;
                bitacora.Guardar(bitacoraBE);
            }
            

            return BE;        
        }

        public List<Componente> Obtener_Todos_x_Usuarios(UsuarioBE selectedItem)
        {
            return dAL.Obtener_Todos_x_Usuarios(selectedItem);
        }

        public List<UsuarioBE> Obtener_Todos()
        {
            return dAL.Obtener_Todos();
        }

        public void ObtenerPerfil(UsuarioBE user) 
        {
            PerfilBL perfilBL = new PerfilBL();
            perfilBL.ObtenerPerfilPorUsuario(user);
        }

        public int AgregarPerfil(Componente c, UsuarioBE usuarioSeleccionado) 
        {
            return dAL.AgregarPerfil(c,usuarioSeleccionado);
        }
    }
}
