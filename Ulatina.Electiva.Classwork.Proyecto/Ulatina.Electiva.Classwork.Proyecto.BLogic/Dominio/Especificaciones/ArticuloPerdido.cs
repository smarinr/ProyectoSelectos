using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ulatina.Electiva.Classwork.Proyecto.Model;

namespace Especificaciones
{
    internal class ArticuloPerdido
    {
        public ArticuloPerdido()
        {
        }

        internal IList<Ulatina.Electiva.Classwork.Proyecto.Model.ArticuloPerdido> listarArticulosPerdidos()
        {
            IList<Ulatina.Electiva.Classwork.Proyecto.Model.ArticuloPerdido> resultado;
            var miRepositorio = new Repositorio.ArticuloPerdido();
            resultado = miRepositorio.listarArticulosPerdidos();
            return resultado;
        }

        internal IList<Custodia> listarCustodiaPorArticulo(int idArticulo)
        {
            IList<Custodia> resultado;
            var miRepositorio = new Repositorio.ArticuloPerdido();
            resultado = miRepositorio.listarCustodiaPorArticulosPerdidos(idArticulo);
            return resultado;
        }
    }
}