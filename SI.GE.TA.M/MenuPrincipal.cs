using SERVICE;
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
 

namespace SI.GE.TA.M
{
    public partial class MenuPrincipal : Form
    {
        private UsuarioBE userLogueeado;
        public MenuPrincipal(UsuarioBE usuario)
        {
            InitializeComponent();
            userLogueeado = usuario;
            administradorToolStripMenuItem.Visible = false;
            ventasToolStripMenuItem.Visible = false;
            comprasToolStripMenuItem.Visible = false;
            almacenToolStripMenuItem.Visible = false;
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            label2.Text = Sesion_Manager.Get_Instance(userLogueeado.NombreUsuario).Usuario.NombreUsuario;
            switch (Sesion_Manager.Get_Instance(userLogueeado.NombreUsuario).Usuario.Perfil.Descripcion)
            {
                case "Administrador":
                    administradorToolStripMenuItem.Visible = true;
                        break;
                default:
                    break;
            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void asignarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_AsignacionRolesyPermisos rolesyPermisos = new Frm_AsignacionRolesyPermisos();
            rolesyPermisos.Show();

        }
    }
}
