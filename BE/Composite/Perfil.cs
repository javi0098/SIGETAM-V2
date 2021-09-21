using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Composite
{
    public class Perfil : Componente
    {

        List<Componente> ListaPermisos;

        public Perfil( )
        {
             
        }
        public Perfil(int id, string descrip)
        {
            ListaPermisos = new List<Componente>();
            Id = id;
            Descripcion = descrip;
        }

        public override IList<Componente> Hijos => ListaPermisos;

        public override void AgregarHijo(Componente c)
        {
            ListaPermisos.Add(c);
        }

        public override void EliminarHijo(Componente c)
        {
            ListaPermisos.Remove(c);
        }
    }
}
