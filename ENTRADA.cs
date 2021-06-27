//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace apisBlog
{
    using System;
    using System.Collections.Generic;
    
    public partial class ENTRADA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ENTRADA()
        {
            this.ARCHIVOENTRADAs = new HashSet<ARCHIVOENTRADA>();
            this.AUTORENTRADAs = new HashSet<AUTORENTRADA>();
            this.CALIFICACIONENTRADAs = new HashSet<CALIFICACIONENTRADA>();
            this.COMENTARIOENTRADAs = new HashSet<COMENTARIOENTRADA>();
        }
    
        public int IdEntrada { get; set; }
        public int Carrera { get; set; }
        public string Curso { get; set; }
        public Nullable<int> Tema { get; set; }
        public System.DateTime FechaCrear { get; set; }
        public System.DateTime FechaMod { get; set; }
        public int Vistas { get; set; }
        public bool Visible { get; set; }
        public string Abstract { get; set; }
        public string Body { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ARCHIVOENTRADA> ARCHIVOENTRADAs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AUTORENTRADA> AUTORENTRADAs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CALIFICACIONENTRADA> CALIFICACIONENTRADAs { get; set; }
        public virtual CARRERA CARRERA1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMENTARIOENTRADA> COMENTARIOENTRADAs { get; set; }
        public virtual CURSO CURSO1 { get; set; }
        public virtual TEMA TEMA1 { get; set; }
    }
}
