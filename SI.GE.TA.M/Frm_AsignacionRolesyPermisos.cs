using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BL;

namespace SI.GE.TA.M
{
    public partial class Frm_AsignacionRolesyPermisos : Form
    {
        UsuarioBL usuarioBL = new UsuarioBL();
        public Frm_AsignacionRolesyPermisos()
        {
            InitializeComponent();
        }

        private void Frm_AsignacionRolesyPermisos_Load(object sender, EventArgs e)
        {
            try
            {
               
                var usuarios = usuarioBL.Obtener_Todos();
                comboBox1.DataSource = usuarios.ToList();

                PerfilBL perfilBL = new PerfilBL();
                var perfiles = perfilBL.ObtenerTodosPermisos();
                listBox1.DataSource = perfiles.ToList();

                if (comboBox1.SelectedItem != null) 
                {

                    var perfilUser = usuarioBL.Obtener_Todos_x_Usuarios((UsuarioBE)comboBox1.SelectedItem).ToList();
                    listBox2.DataSource = perfilUser.ToList();
                }
               

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var usuarioSeleccionado = (UsuarioBE)comboBox1.SelectedItem;
            var permisoXasignar = (BE.Composite.Permisos)listBox1.SelectedItem;
            if (permisoXasignar.Descripcion.Contains("Perfil")) 
            {
                if (usuarioBL.AgregarPerfil(permisoXasignar, usuarioSeleccionado) > 0) 
                {
                    MessageBox.Show("Asignacion Correcta");
                }
            }
            else
            {
                MessageBox.Show("Solo se pueden asignar  Perfiles");
            }
             


        }
    }
}
