﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class ListaRepProdutos
    {
        public string CodigoBarras { get; set; }
        public string Descricao { get; set; }
        public string Cor { get; set; }
        public string Tamanho { get; set; }
        public Nullable<double> ValorSaida { get; set; }
        public Nullable<double> SaldoEstoque { get; set; }
        public long ProdutoGradeId { get; set; }
    }
}
