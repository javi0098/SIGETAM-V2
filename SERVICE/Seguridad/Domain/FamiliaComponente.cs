using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Seguridad.Domain
{
    /// <summary>
    /// aca se coloca la clase abstracta componetm, de la cual heredaran Familia y Patetente
    /// </summary>
    public abstract class FamiliaComponente
    {
        //Atributos
        public string idfamilia { get; set; }
        public string nombre { get; set; }

        //Constructor
        public FamiliaComponente()
        {
            this.idfamilia = Guid.NewGuid().ToString();
        }

        //Metodos
        public abstract void Agregar(FamiliaComponente c);
        public abstract void Remover(FamiliaComponente c);
        public abstract List<Patente> GetPatentes();
        public abstract int GetHijos();
    }
}
