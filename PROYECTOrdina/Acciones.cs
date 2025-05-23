using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTOrdina
{
    internal class Acciones : IAcciones
    {
        Correo c = new Correo();
        List<Auto> autos = new List<Auto>();
        Auto a = new Auto();

        public List<Auto> Mostrar()
        {
            return autos;
        }

        public bool AgregarAuto(int iD, string marca, string modelo, int anio, string color, double precio, string estado)
        {
            try
            {
                Auto nuevoAuto = new Auto
                {
                    ID = iD,
                    Marca = marca,
                    Modelo = modelo,
                    Anio = anio,
                    Color = color,
                    Precio = precio,
                    Estado = estado
                };

                autos.Add(nuevoAuto);
                return true;
            }
            catch (Exception ex)
            {
                c.Correoo("Error al agregar auto: " + ex.ToString());
                return false;
            }

        }



        public bool EliminarAuto(int id)
        {
            try
            {
                Auto autoAEliminar = autos.Find(a => a.ID == id);
                if (autoAEliminar != null)
                {
                    autos.Remove(autoAEliminar);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                c.Correoo("Error al eliminar auto: " + ex.ToString());
                return false;
            }
        }

        public bool ActualizarAuto(int id, string nuevaMarca, string nuevoModelo, int nuevoAnio, string nuevoColor, double nuevoPrecio, string nuevoEstado)
        {
            try
            {
                Auto autoAActualizar = autos.Find(a => a.ID == id);

                if (autoAActualizar != null)
                {
                    autoAActualizar.Marca = nuevaMarca;
                    autoAActualizar.Modelo = nuevoModelo;
                    autoAActualizar.Anio = nuevoAnio;
                    autoAActualizar.Color = nuevoColor;
                    autoAActualizar.Precio = nuevoPrecio;
                    autoAActualizar.Estado = nuevoEstado;

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                c.Correoo("Error al actualizar auto: " + ex.ToString());
                return false;
            }
        }

        public bool Exportar()
        {
            try
            {
                string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Autos_Exportacion.xlsx");

                using (var workbook = new XLWorkbook())
                {
                    var hoja = workbook.Worksheets.Add("Autos");

                    // Encabezados
                    hoja.Cell(1, 1).Value = "Id";
                    hoja.Cell(1, 2).Value = "Marca";
                    hoja.Cell(1, 3).Value = "Modelo";
                    hoja.Cell(1, 4).Value = "Anio";
                    hoja.Cell(1, 5).Value = "Color";
                    hoja.Cell(1, 6).Value = "Precio";
                    hoja.Cell(1, 7).Value = "Estado";

                    int fila = 2;

                    foreach (var auto in autos)
                    {
                        hoja.Cell(fila, 1).Value = auto.ID;
                        hoja.Cell(fila, 2).Value = auto.Marca;
                        hoja.Cell(fila, 3).Value = auto.Modelo;
                        hoja.Cell(fila, 4).Value = auto.Anio;
                        hoja.Cell(fila, 5).Value = auto.Color;
                        hoja.Cell(fila, 6).Value = auto.Precio;
                        hoja.Cell(fila, 7).Value = auto.Estado;

                        fila++;
                    }

                    workbook.SaveAs(rutaArchivo);
                }

                return true;
            }
            catch (Exception ex)
            {
                c.Correoo(ex.ToString());
                return false;
            }
        }

        public bool ImportarAuto()
        {

            try
            {
                string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Autos_Importacion.xlsx");

                if (!File.Exists(rutaArchivo))
                {
                    MessageBox.Show("Archivo no encontrado en: " + rutaArchivo);
                    return false;
                }

                using (var workbook = new XLWorkbook(rutaArchivo))
                {
                    var hoja = workbook.Worksheets.First();
                    var filas = hoja.RowsUsed().Skip(1);

                    foreach (var fila in filas)
                    {
                        Auto auto = new Auto()
                        {
                            ID = int.Parse(fila.Cell(1).GetValue<string>()),
                            Marca = fila.Cell(2).GetValue<string>(),
                            Modelo = fila.Cell(3).GetValue<string>(),
                            Anio = int.Parse(fila.Cell(4).GetValue<string>()),
                            Color = fila.Cell(5).GetValue<string>(),
                            Precio = double.Parse(fila.Cell(6).GetValue<string>(), System.Globalization.CultureInfo.InvariantCulture),
                            Estado = fila.Cell(7).GetValue<string>()
                        };

                        autos.Add(auto);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                c.Correoo(ex.ToString());
                return false;
            }
        }

        public int Contadordisp()
        {
            int contador = 0;

            foreach (var d in autos)
            {
                if (d.Estado == "Disponible")
                {
                    contador = contador + 1;
                }
            }
            return contador;
        }
    }
}

