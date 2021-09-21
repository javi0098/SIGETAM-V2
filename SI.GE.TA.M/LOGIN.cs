using BE;
using BL;
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

namespace SI.GE.TA.M
{
    public partial class LOGIN : Form
    {
        CriptoManager cripto;
        public LOGIN()
        {
            InitializeComponent();
            cripto = new CriptoManager();
             
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsuarioBE usuario = new UsuarioBE();
            usuario.NombreUsuario = textBox1.Text;
            usuario.Contraseña = cripto.Hashear(textBox2.Text);
             
            UsuarioBE usuarioRetornado;
            UsuarioBL usuarioBL = new UsuarioBL();
            usuarioRetornado =  usuarioBL.Login(usuario.NombreUsuario, usuario.Contraseña);
            if (usuarioRetornado != null) 
            {

                MenuPrincipal menuPrincipal = new MenuPrincipal(usuarioRetornado);
               
                menuPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario/Contraseña no valido ", "Error de Login");
            }


        }
    }
}
