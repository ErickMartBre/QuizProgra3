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
    
    public partial class Viajeros
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Viajeros()
        {
            this.Documentos = new HashSet<Documentos>();
            this.Movimientos = new HashSet<Movimientos>();
        }
    
        public int ViajeroID { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public string Genero { get; set; }
        public int UsuarioID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Documentos> Documentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movimientos> Movimientos { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}