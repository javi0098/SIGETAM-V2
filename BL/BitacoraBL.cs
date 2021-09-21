using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public class BitacoraBL
    {
        private BitacoraDAL bitacoraDAL = new BitacoraDAL();

        public void Guardar(BE.BitacoraBE bitacoraBE) 
        {
            bitacoraDAL.Guardar(bitacoraBE);
        
        }
    }
}
