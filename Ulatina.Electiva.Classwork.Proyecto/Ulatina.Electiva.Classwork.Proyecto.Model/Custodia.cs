//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ulatina.Electiva.Classwork.Proyecto.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Custodia
    {
        public int idCustodia { get; set; }
        public int idArticuloPerdido { get; set; }
        public int idUsuarioReporta { get; set; }
        public int idUsuarioCustodia { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
               ApplyFormatInEditMode = true)]
        public System.DateTime fechaCustodiaIngresada { get; set; }
    
        public virtual ArticuloPerdido ArticuloPerdido { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
    }
}
