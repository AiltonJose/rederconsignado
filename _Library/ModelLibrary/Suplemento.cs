//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class Suplemento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Suplemento()
        {
            this.SuplementoProduto = new HashSet<SuplementoProduto>();
        }
    
        public int Id { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public string Situacao { get; set; }
        public string Observacao { get; set; }
        public Nullable<int> temp_old_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuplementoProduto> SuplementoProduto { get; set; }
    }
}