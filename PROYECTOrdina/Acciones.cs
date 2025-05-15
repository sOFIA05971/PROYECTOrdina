using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOrdina
{
    internal class Acciones
    {
        private List<Auto> autos = new List<Auto>();

        public List<Auto> Mostrar()
        {
            return autos;
        }

        public void AgregarAuto(int iD, string marca, string modelo, int anio, string color, double precio, string estado)
        {
            Auto nuevoAuto = new Auto(iD, marca, modelo, anio, color, precio, estado);
            autos.Add(nuevoAuto);
        }

        public bool EliminarAuto(int id)
        {
            Auto autoAEliminar = autos.Find(a => a.ID == id);
            if (autoAEliminar != null)
            {
                autos.Remove(autoAEliminar);
                return true;
            }
            return false;
        }

        public bool ActualizarAuto(int id, string nuevaMarca, string nuevoModelo, int nuevoAnio, string nuevoColor, double nuevoPrecio, string nuevoEstado)
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
    }
}
