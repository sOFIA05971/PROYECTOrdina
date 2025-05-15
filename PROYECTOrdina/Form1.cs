using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTOrdina
{
    public partial class Form1 : Form
    {
        Usuario usuario = new Usuario();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string user = tbxUsuario.Text;
            string password = tbxContra.Text;

            var lista = usuario.Obtenerusuario();
            var validar = lista.FirstOrDefault(u => u.NombreUsuario == user && u.Contrasenia == password);

            if (validar != null)
            {
                this.Hide();
                Inicio inicio = new Inicio();
                inicio.Show();
            }
            else
            {

                MessageBox.Show("Fallaste...");

            }
        }
    }
}
    

