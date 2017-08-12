using Acciones;
using Especificaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ulatina.Electiva.Classwork.Proyecto.Model;

namespace Acciones
{
    internal class ArticulosPedidos
    {

        public ArticulosPedidos()
        {

        }

        public IList<Ulatina.Electiva.Classwork.Proyecto.Model.ArticuloPerdido> listarArticulosPerdidos()
        {
            IList<Ulatina.Electiva.Classwork.Proyecto.Model.ArticuloPerdido> resultado;
            var miEspecificacion = new Especificaciones.ArticuloPerdido();

            resultado = miEspecificacion.listarArticulosPerdidos();
            return resultado;
        }

        public IList<Custodia> listarCustodiaPorArticulo(int idArticulo)
        {
            IList<Custodia> resultado;
            var miEspecificacion = new Especificaciones.ArticuloPerdido();
            resultado = miEspecificacion.listarCustodiaPorArticulo(idArticulo);
            return resultado;
        }
         

    }
}