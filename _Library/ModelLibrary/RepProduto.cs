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
    
    public partial class RepProduto
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public Nullable<long> CategoriaId { get; set; }
        public Nullable<long> FornecedorId { get; set; }
        public string Unidade { get; set; }
        public string CodigoBarras { get; set; }
        public string Digito { get; set; }
        public Nullable<decimal> Quantidade { get; set; }
        public string Status { get; set; }
    }
}
