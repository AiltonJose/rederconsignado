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
    
    public partial class RepCargaProduto
    {
        public long Id { get; set; }
        public Nullable<long> CargaId { get; set; }
        public long ProdutoGradeId { get; set; }
        public Nullable<decimal> Quantidade { get; set; }
        public Nullable<decimal> Retorno { get; set; }
    }
}
