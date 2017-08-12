using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ulatina.Electiva.Classwork.Proyecto.Model;

//namespace Ulatina.Electiva.Classwork.Proyecto.BLogic.Dominio.Repositorio
namespace Repositorio
{
    internal class Usuarios
    {
        private ProyectoArticuloPerdidoEntities _context = new ProyectoArticuloPerdidoEntities();

        public Usuarios(){
        }

        internal IList<Usuario> listarUsuarios(){
            IList<Usuario> resultado = _context.Usuario
                .Include("Custodias").ToList();
            return resultado;
        }
        internal IList<Custodia> listarCustodiaPorUsuario (int IdUsuarioCustodia)
        {
            IList<Custodia> resultado = _context.Custodia
                .Include("Usuarios")
                .Where(c => c.idUsuarioCustodia == IdUsuarioCustodia).ToList();
            return resultado;
        }   







    }
}