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
        private UsuarioEntities _context = new UsuarioEntities();

        public Usuarios(){
        }

        internal IList<Usuario> listarUsuarios(){
            IList<Usuario> resultado = _context.Usuarios
                .Include("Custodias").ToList();
            return resultado;
        }
        internal IList<Custodia> listarCustodiaPorUsuario (int IdUsuarioCustodia)
        {
            IList<Custodia> resultado = _context.Custodias
                .Include("Usuarios")
                .Where(c => c.idUsuarioCustodia == IdUsuarioCustodia).ToList();
            return resultado;
        }   







    }
}