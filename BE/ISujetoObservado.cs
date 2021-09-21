using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    interface ISujetoObservado
    {
        void AgregarObservador(IObservador observador);
        void RemoverObservador(IObservador observador);
        void NotificarObservadores();
    }
}
