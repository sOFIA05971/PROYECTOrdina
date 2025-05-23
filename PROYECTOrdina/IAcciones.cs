using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOrdina
{
    internal interface IAcciones
    {
        List<Auto> Mostrar();
        bool EliminarAuto(int id);
        bool AgregarAuto(int iD, string marca, string modelo, int anio, string color, double precio, string estado);
        bool ActualizarAuto(int id, string nuevaMarca, string nuevoModelo, int nuevoAnio, string nuevoColor, double nuevoPrecio, string nuevoEstado);
        bool Exportar();
        bool ImportarAuto();
        int ContadorDisponible();

        

    }
}
