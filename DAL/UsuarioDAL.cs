using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BE;
using System.Windows.Forms;
using BE.Composite;

namespace DAL
{
    public class UsuarioDAL
    {
        private static string cadenaConeccion = "Data Source=.;Initial Catalog=SI.GE.TA.M;Integrated Security=True";
        private SqlConnection conexion = new SqlConnection(cadenaConeccion);

        public UsuarioBE Login(string user, string pass) 
        {
            try
            {
                UsuarioBE usuario= null;
                conexion.Open();
                SqlCommand command = new SqlCommand("spLogin", conexion);
                command.CommandType =  CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@user", user);
                command.Parameters.AddWithValue("@pass", pass);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) 
                {
                    usuario = new UsuarioBE();
                    
                    usuario.Id = int.Parse(reader["Id_Usuario"].ToString());
                    usuario.NombreUsuario = reader["Nombre_Usuario"].ToString();
                    usuario.Contraseña = reader["Contraseña"].ToString();
                    
                }
                conexion.Close();
                return usuario;

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
                return null;
            }
           
        }

        public List<UsuarioBE> Obtener_Todos()
        {
            try
            {
                UsuarioBE user = null;
                List<UsuarioBE> usuarios = new List<UsuarioBE>();
                conexion.Open();
                SqlCommand command = new SqlCommand("spObtenerTodosUsuarios", conexion);
                command.CommandType = CommandType.StoredProcedure;
                
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        user = new UsuarioBE();
                        user.Id = int.Parse(row["Id_Usuario"].ToString());
                        user.NombreUsuario = row["Nombre_Usuario"].ToString();
                        user.Email = row["Email"].ToString();
                        user.Activo = Boolean.Parse(row["Activo"].ToString());
                        user.Bloqueado = Boolean.Parse(row["Bloqueado"].ToString());
                        usuarios.Add(user);
                        user = null;
                    }

                }
                conexion.Close();
                return usuarios;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public int AgregarPerfil(Componente c, UsuarioBE usuarioSeleccionado)
        {
            try
            {
                 
                conexion.Open();
                SqlCommand command = new SqlCommand("spAgregarPerfil_Usuario", conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idUsuario", usuarioSeleccionado.Id);
                command.Parameters.AddWithValue("@idPerfil", c.Id);
                command.ExecuteReader();

                
                conexion.Close();
                return 1;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return -1;
            }

        }

        public List<Componente> Obtener_Todos_x_Usuarios(UsuarioBE selectedItem)
        {
            try
            {
                Componente componente = null;
                List<Componente> permisos = new List<Componente>();
                conexion.Open();
                SqlCommand command = new SqlCommand("spObtenerTodosPermisosUsuario", conexion);
                command.Parameters.AddWithValue("@id", selectedItem.Id);
                command.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        componente = new Perfil();
                        componente.Id = int.Parse(row[2].ToString());
                        componente.Descripcion = "[Perfil] -  " + (row[3].ToString());
                        if (permisos.FindAll(x => x.Descripcion == componente.Descripcion).Count == 0)
                        {
                            permisos.Add(componente);
                        }
                        else
                        {
                            //ya existe
                        }

                        componente = null;
                        componente = new Permisos();
                        componente.Id = int.Parse(row[4].ToString());
                        componente.Descripcion = (row[5].ToString());
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
    }
}
