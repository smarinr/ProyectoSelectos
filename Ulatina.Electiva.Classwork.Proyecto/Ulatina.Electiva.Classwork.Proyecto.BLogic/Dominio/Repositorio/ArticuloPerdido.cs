using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ulatina.Electiva.Classwork.Proyecto.Model;

namespace Repositorio
{
    internal class ArticuloPerdido
    {
        private ProyectoArticuloPerdidoEntities _context = new ProyectoArticuloPerdidoEntities();

        public ArticuloPerdido()
        {
        }

        internal IList<Ulatina.Electiva.Classwork.Proyecto.Model.ArticuloPerdido> listarArticulosPerdidos()
        {

            IList<Ulatina.Electiva.Classwork.Proyecto.Model.ArticuloPerdido> resultado = _context.ArticuloPerdidoes.
                Include("Categoria").Include("Custodia").ToList();
            return resultado;
        }

        internal IList<Custodia> listarCustodiaPorArticulosPerdidos(int idArticulo)
        {
            IList<Custodia> resultado = _context.Custodias.
                Include("ArticuloPerdido").Where(c => c.idArticuloPerdido==idArticulo).ToList();
            return resultado;
            
        }

    }
}