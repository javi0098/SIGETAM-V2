using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BE;
using BE.Composite;
using System.Windows.Forms;

namespace DAL
{
    public class PerfilDAL
    {
        private static string cadenaConeccion = "Data Source=.;Initial Catalog=SI.GE.TA.M;Integrated Security=True";

       

        private SqlConnection conexion = new SqlConnection(cadenaConeccion);


        public List<Componente> ObtenerTodosPermisos()
        {
            try
            {
                Componente componente = null;
                List<Componente> permisos = new List<Componente>();
                conexion.Open();
                SqlCommand command = new SqlCommand("spObtenerTodosPermisos", conexion);
                command.CommandType = CommandType.StoredProcedure;                
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        componente = new Permisos();
                        componente.Id = int.Parse(row[0].ToString());
                        componente.Descripcion = "[Perfil] -  "+(row[1].ToString());
                        if (permisos.FindAll(x=> x.Descripcion == componente.Descripcion).Count == 0 ) 
                        {
                            permisos.Add(componente);
                        }
                        else
                        {
                            //ya existe
                        }
                                          
                        componente = null;
                        componente = new Permisos();
                        componente.Id = int.Parse(row[2].ToString());
                        componente.Descripcion = (row[3].ToString());
                        if (permisos.FindAll(x => x.Descripcion == componente.Descripcion).Count == 0)
                        {
                            permisos.Add(componente);
                        }
                        else
                        {
                            //ya existe
                        }
                        componente = null;
                    }

                }
                conexion.Close();
                return permisos;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return null;
            }

        }
        public List<Componente> ObtenerTodosPermisos(UsuarioBE user)
        {
            try
            {
                Componente componente = null;
                List<Componente> Permisos = new List<Componente>();
                conexion.Open();
                SqlCommand command = new SqlCommand("spObtenerTodosPermisosUsuario", conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", user.Perfil.Id);
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                 
                adapter.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        componente = new Permisos();
                        componente.Id = int.Parse(row["Id_Permiso"].ToString());
                        componente.Descripcion = row["Descripcion"].ToString();
                        Permisos.Add(componente);
                        componente = null;
                    }
                    
                }
                conexion.Close();
                return Permisos;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return null;
            }
        }

       
        public List<Componente> ObtenerTodosPerfiles() 
        {
            return null;
        }

        public Componente ObtenerPerfilPorUsuario(UsuarioBE user)
        {
            try
            {
                Componente componente = null;
                 
                conexion.Open();
                SqlCommand command = new SqlCommand("spObtenerPerfilUsuario", conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", user.Id);
                 
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    componente = new Perfil();
                    componente.Id = int.Parse(reader["Id_Perfil"].ToString());
                    componente.Descripcion = reader["Descripcion"].ToString();

                }
                conexion.Close();
                return componente;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
