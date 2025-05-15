using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOrdina
{
    internal class Usuario
    {

        private static List<Usuario> usuarios = new List<Usuario>
        {
        new Usuario{NombreUsuario = "Sofia", Contrasenia="1234"},
        new Usuario{NombreUsuario = "Yeyo", Contrasenia="0000"},

};
        public Usuario() { }

        public List<Usuario> Obtenerusuario()
        {
            return usuarios;
        }

        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
    }
}

    

