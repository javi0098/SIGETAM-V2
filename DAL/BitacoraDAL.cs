using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class BitacoraDAL
    {
        private static string cadenaConeccion = "Data Source=.;Initial Catalog=SI.GE.TA.M;Integrated Security=True";
        private SqlConnection conexion = new SqlConnection(cadenaConeccion);

        public void Guardar(BitacoraBE bitacoraBE)
        {
            try
            {
                 
                conexion.Open();
                SqlCommand command = new SqlCommand("spRegistrarBitacora", conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@descrip", bitacoraBE.Descripcion);
                command.Parameters.AddWithValue("@fecha", bitacoraBE.Fecha);
                command.Parameters.AddWithValue("@incidencia", bitacoraBE.Tipo_incidencia);
                command.Parameters.AddWithValue("@usuario", bitacoraBE.NombreUsuario);

                command.ExecuteNonQuery();
                conexion.Close();
                 

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                 
            }
        }
    }
}
