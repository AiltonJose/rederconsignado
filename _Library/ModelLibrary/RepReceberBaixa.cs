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
    
    public partial class RepReceberBaixa
    {
        public long Id { get; set; }
        public Nullable<long> ReceberId { get; set; }
        public Nullable<long> CargaId { get; set; }
        public Nullable<decimal> Valor { get; set; }
        public Nullable<System.DateTime> DataPagamento { get; set; }
        public Nullable<System.DateTime> DataBaixa { get; set; }
        public Nullable<decimal> Juros { get; set; }
        public Nullable<decimal> Desconto { get; set; }
    }
}
