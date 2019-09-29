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
    
    public partial class RepVendedorBase
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Cep { get; set; }
        public string TipoPessoa { get; set; }
        public string CpfCnpj { get; set; }
        public string RGInscricao { get; set; }
        public Nullable<System.DateTime> DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string TelefoneComercial { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> DataInicial { get; set; }
        public Nullable<System.DateTime> DataFinal { get; set; }
        public Nullable<decimal> LimitePedido { get; set; }
        public Nullable<decimal> LimiteCredito { get; set; }
        public string Status { get; set; }
        public string Observacao { get; set; }
        public string PedidoAberto { get; set; }
        public Nullable<decimal> DebitoAReceber { get; set; }
    }
}
