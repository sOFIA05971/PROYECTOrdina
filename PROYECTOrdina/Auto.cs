using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOrdina
{
    internal class Auto : Vehiculo
    {
        public Auto(int iD, string marca, string modelo, int anio, string color, double precio, string estado)
            :base(precio, estado)
        {
            ID = iD;
            Marca = marca;
            Modelo = modelo;
            Anio = anio;
            Color = color;

        }

        public Auto() { }

        public int ID { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string Color { get; set; }
        
    }
}
