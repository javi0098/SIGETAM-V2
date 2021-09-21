using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class Componente
    {
        public string Descripcion { get; set; }
        public int Id { get; set; }

        public abstract IList<Componente> Hijos { get; }
        public abstract void AgregarHijo(Componente c);

        public abstract void EliminarHijo(Componente c);

        public override string ToString()
        {
            return Descripcion;
        }

    }
}
