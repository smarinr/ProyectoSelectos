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
    
    public partial class ArticuloPerdido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ArticuloPerdido()
        {
            this.Custodias = new HashSet<Custodia>();
        }
    
        public int idArticuloPerdido { get; set; }
        public string descripcionArticuloPerdido { get; set; }
        public string statusArticuloPerdido { get; set; }
        public int idCategoria { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Custodia> Custodias { get; set; }
    }
}