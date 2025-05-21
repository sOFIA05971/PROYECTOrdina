using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOrdina
{
    internal class Vehiculo
    {
        public Vehiculo() { }
        public Vehiculo(double precio, string estado)
        {
            Precio = precio;
            Estado = estado;
        }

        public double Precio { get; set; }
        public string Estado { get; set; }
    }
}
