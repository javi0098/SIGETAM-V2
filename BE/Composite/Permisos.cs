using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Composite
{
    public class Permisos : Componente
    {

        public Permisos( )
        {
             

        }
        public Permisos(int id,string descrip)
        { 
            Id = id;
            Descripcion = descrip;
                    
        }
        public override IList<Componente> Hijos => null;

        public override void AgregarHijo(Componente c)
        {
            throw new NotImplementedException();
        }

        public override void EliminarHijo(Componente c)
        {
            throw new NotImplementedException();
        }
    }
}
