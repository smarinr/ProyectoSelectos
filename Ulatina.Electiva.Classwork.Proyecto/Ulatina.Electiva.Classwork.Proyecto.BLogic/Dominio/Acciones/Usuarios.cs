using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ulatina.Electiva.Classwork.Proyecto.Model;

namespace Acciones
{
    internal class Usuarios
    {
        public Usuarios()
        {
        }

        public IList<Usuario> listarUsuarios()
        {
            IList<Usuario> resultado;
            var miEspecificacion = new Especificaciones.Usuarios();
            resultado = miEspecificacion.listarUsuarios();
            return resultado;
        }

        public IList<Custodia> listarCustodiaPorUsuario(int IdUsuario)
        {
            IList<Custodia> resultado;
            var miEspecificacion = new Especificaciones.Usuarios();
            resultado = miEspecificacion.listarCustodiaPorUsuario(IdUsuario);
            return resultado;
        }

    }
}