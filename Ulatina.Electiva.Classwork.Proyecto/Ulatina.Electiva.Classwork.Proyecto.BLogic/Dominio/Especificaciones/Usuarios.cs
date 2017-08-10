using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ulatina.Electiva.Classwork.Proyecto.Model;

namespace Especificaciones
{
    internal class Usuarios
    {
        public Usuarios()
        {
        }

        internal IList<Usuario> listarUsuarios()
        {
            IList<Usuario> resultado;
            var miRepositorio = new Repositorio.Usuarios();
            resultado = miRepositorio.listarUsuarios();
            return resultado;
        }

        internal IList<Custodia> listarCustodiaPorUsuario(int IdUsuario)
        {
            IList<Custodia> resultado;
            var miRepositorio = new Repositorio.Usuarios();
            resultado = miRepositorio.listarCustodiaPorUsuario(IdUsuario);
            return resultado;
        }
    }
}