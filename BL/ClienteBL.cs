using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public  class ClienteBL
    {
        ClienteDAL clienteDAL = new ClienteDAL();
        public int AgregarCliente(ClienteBE cli) 
        {
            return clienteDAL.AgregarCliente(cli);
        }
    }
}
