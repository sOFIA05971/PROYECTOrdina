using DocumentFormat.OpenXml.Wordprocessing;
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
            DGdatos.DataSource = null;  // para forzar refresco
            DGdatos.DataSource = acc.Mostrar();
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
                    MessageBox.Show("Auto actualizado con éxito.");
                }
                else
                {
                    MessageBox.Show("No se encontró un auto con ese ID");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al actualizar");
            }
        }



        private void btnImportar_Click(object sender, EventArgs e)
        {
            if (acc.ImportarAuto())
            {
                MessageBox.Show("Importado con exito...");
                
            }
            else
            {
                MessageBox.Show("Fallo importando...");

            }
            DGdatos.DataSource = acc.Mostrar();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            {
                if (acc.AgregarAuto(Convert.ToInt32(tbxID.Text),tbxMarca.Text, tbxModelo.Text, Convert.ToInt32(tbxAnio.Text),tbxColor.Text,Convert.ToDouble(tbxPrecio.Text),tbxEstado.Text))
                {
                    MessageBox.Show("Agregado con éxito");
                }
                else
                {
                    MessageBox.Show("Fallo al agregar");
                }

                DGdatos.DataSource = null;
                DGdatos.DataSource = acc.Mostrar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (acc.EliminarAuto(Convert.ToInt32(tbxID.Text)))

            {
                MessageBox.Show("Eliminado con exito");
            }
            else
            {
                MessageBox.Show("Fallo al eliminar");
            }

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (acc.Exportar())
                MessageBox.Show("Exportado con exito...");
            else
                MessageBox.Show("No se exporto...");

        }

        private void btnContador_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Tienes disponibles {acc.Contadordisp()} ");           
        }
    }
}
