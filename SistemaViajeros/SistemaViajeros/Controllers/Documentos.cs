//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaViajeros.Controllers
{
    using System;
    using System.Collections.Generic;
    
    public partial class Documentos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Documentos()
        {
            this.Movimientos = new HashSet<Movimientos>();
        }
    
        public int DocumentoID { get; set; }
        public string TipoDocumento { get; set; }
        public string Numero { get; set; }
        public System.DateTime FechaExpiracion { get; set; }
        public int ViajeroID { get; set; }
    
        public virtual Viajeros Viajeros { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movimientos> Movimientos { get; set; }
    }
}