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
    public partial class Inicio : Form
    {
        Acciones acc = new Acciones();
        public Inicio()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            try
            {
                int id = int.Parse(tbxID.Text);
                string marca = tbxMarca.Text;
                string modelo = tbxModelo.Text;
                int anio = int.Parse(tbxAnio.Text);
                string color = tbxColor.Text;
                double precio = double.Parse(tbxPrecio.Text);
                string estado = tbxEstado.Text;

                if (acc.ActualizarAuto(id, marca, modelo, anio, color, precio, estado))
                {
                    MessageBox.Show("Actualizado con éxito");
                    DGdatos.DataSource = null;
                    DGdatos.DataSource = acc.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
