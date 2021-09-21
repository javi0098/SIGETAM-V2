using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace SERVICE
{
    public class Sesion_Manager
    {
        //lista de sesiones
        private static Dictionary<string, Sesion_Manager> instanciasSesion = new Dictionary<string, Sesion_Manager>();

        public  UsuarioBE Usuario;

        private Sesion_Manager(UsuarioBE usuario) 
        {
            Usuario = usuario;

        }

        public static Sesion_Manager CrearSesion(UsuarioBE user) 
        {
            //si el diccionario contiene la Key que pasamos por pNombreUsario deuvelve TRUE
            if (!instanciasSesion.ContainsKey(user.NombreUsuario))
            {
                // si el diccionario no contiene pNombreUsuairo entonces creo un nuevo y lo agrego
                instanciasSesion.Add(user.NombreUsuario, new Sesion_Manager(user));

            }

            //si existe la Key en el diccionario pero no contiene asociado una sesion
            //entonces asocio una nueva sesionMananger
            else if (instanciasSesion[user.NombreUsuario] == null)
            {
                instanciasSesion[user.NombreUsuario] = new Sesion_Manager(user);

            }

            return instanciasSesion[user.NombreUsuario];
        }

       


        public static Sesion_Manager Get_Instance(string pNombreUsuario) 
        {
            //si el diccionario contiene la Key que pasamos por pNombreUsario deuvelve TRUE
            if (instanciasSesion.ContainsKey(pNombreUsuario))
            {

                return instanciasSesion[pNombreUsuario];
            }
            
             
            else   
            {
                return null;
            
            }
           
           
        }         

    }
}
