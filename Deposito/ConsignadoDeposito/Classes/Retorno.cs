﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsignadoDeposito;
using System.Windows.Forms;

namespace ConsignadoDeposito
{
    public partial class Retorno
    {

        //////////////////////////////
        /// Declaração de Variáveis
        //////////////////////////////

        public Int32 cRetornoProdutoGradeId;
        public string cModoRetornoProduto;
        public Int32 cRetornoId;
        public Int32 cRetornoPedidoId;
        public Int32 cRetornoPedidoItemId;
        public Int32 cRetornoPedidoProdutoGradeId;
        public string cModoRetornoPedidoItem;
        public Int32 cRetornoReceberId;
        public Int32 cRetornoReceberBaixaId;
        public string cModoRetornoReceber;

        public FormDeposito localDepositoForm = null;

        public Retorno(FormDeposito formDeposito)
        {

            localDepositoForm = formDeposito;

        }


        ///////////////////////////////////////////
        /// Carregar Formulário de Pesquisa Retorno
        ///////////////////////////////////////////

        public void CarregarListaRetorno()
        {
            localDepositoForm.cbbRetornoPraca.DataSource = ModelLibrary.MetodosDeposito.ObterListaPracas();
            localDepositoForm.cbbRetornoPraca.DisplayMember = "Descricao";
            localDepositoForm.cbbRetornoPraca.ValueMember = "Id";
            localDepositoForm.cbbRetornoPraca.Invalidate();
            localDepositoForm.cbbRetornoPraca.SelectedIndex = -1;
        }

        public void CarregarListaRepresentante()
        {
            localDepositoForm.cbbRetornoRepresentante.DataSource = ModelLibrary.MetodosDeposito.ObterListaRepresentantes();
            localDepositoForm.cbbRetornoRepresentante.DisplayMember = "Nome";
            localDepositoForm.cbbRetornoRepresentante.ValueMember = "Id";
            localDepositoForm.cbbRetornoRepresentante.Invalidate();
            localDepositoForm.cbbRetornoRepresentante.SelectedIndex = -1;
        }


        public void LimparRetorno()
        {
            localDepositoForm.cbbRetornoPraca.SelectedIndex = -1;
            localDepositoForm.cbbRetornoRepresentante.SelectedIndex = -1;
            localDepositoForm.txtRetornoCodPraca.Text = "";
            localDepositoForm.txtRetornoCodRepresentante.Text = "";
            localDepositoForm.cbbRetornoMesAno.ResetText();

            localDepositoForm.tbcRetorno.Visible = false;
            localDepositoForm.txtRetornoCodigoBarras.Text = "";
            localDepositoForm.txtRetornoProduto.Text = "";
            localDepositoForm.txtRetornoQuantidade.Text = "";
            localDepositoForm.btnRetornoConfirmar.Enabled = false;
        }

        public void ResetarVariaveis()
        {
            cRetornoId = 0;
            cRetornoProdutoGradeId = 0;
            cRetornoId = 0;
        }


        ////////////////////////////////////////
        /// Pesquisar Carga
        ////////////////////////////////////////

        public void PesquisarCarga()
        {

            try
            {

                /* Obter os Campos Selecionados */


                ModelLibrary.Representante representante = (ModelLibrary.Representante)localDepositoForm.cbbRetornoRepresentante.SelectedItem;
                var representanteId = representante.Id;
                ModelLibrary.Praca praca = (ModelLibrary.Praca)localDepositoForm.cbbRetornoPraca.SelectedItem;
                var pracaId = praca.Id;
                int mes = localDepositoForm.cbbRetornoMesAno.Value.Month;
                int ano = localDepositoForm.cbbRetornoMesAno.Value.Year;

                /* Procurar Carga no BD com os dados selecionados */


                var carga = ModelLibrary.MetodosDeposito.ObterCarga(representanteId, pracaId, mes, ano);

                if (carga != null) /* Se existir Carga */
                {
                    /* Carrega Grid com Produtos */
                    localDepositoForm.tbcRetorno.Visible = true;

                    cRetornoId = carga.Id;                    

                    var totalizadores = ModelLibrary.MetodosDeposito.ObterTotalizadores(cRetornoId);

                    localDepositoForm.dlbRetornoQtdProdutos.Text = totalizadores[0].ToString();
                    localDepositoForm.dlbRetornoTotalProdutos.Text = totalizadores[1].ToString("C");
                    
                    localDepositoForm.dlbRetornoDataAbertura.Text = carga.DataAbertura.HasValue ? carga.DataAbertura.Value.ToShortDateString() : "-";
                    localDepositoForm.dlbRetornoDataExportacao.Text = carga.DataExportacao.HasValue ? carga.DataExportacao.Value.ToShortDateString() : "-";
                    localDepositoForm.dlbRetornoDataRetorno.Text = carga.DataRetorno.HasValue ? carga.DataRetorno.Value.ToShortDateString() : "-";
                    localDepositoForm.dlbRetornoDataConferencia.Text = carga.DataConferencia.HasValue ? carga.DataConferencia.Value.ToShortDateString() : "-";
                    localDepositoForm.dlbRetornoDataFinalizacao.Text = carga.DataFinalizacao.HasValue ? carga.DataFinalizacao.Value.ToShortDateString() : "-";

                    

                    var viagemanterior = ModelLibrary.MetodosDeposito.ObterViagemAnterior(representanteId, pracaId, carga.DataAbertura.Value);

                    if (viagemanterior != null)
                    {

                        /*
                         * Carregar Dados da Viagem ANterior 
                         */

                    }
                    else
                    {

                        /*
                         * Exibir informações como ND
                         */

                    }


                    CarregarFormulario();




                }
                else /* Se não existir */
                {
                    MessageBox.Show("Não foi encontrada nenhuma carga com os dados informados.", "Importante!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (IOException vE)
            {
                MessageBox.Show("Ocorreu um erro ao processar a sua consulta. Verifique os dados digitados e tente novamente. Se o erro persisitr, contate o administrador.", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(vE.Message);
            }
        }


        public void CarregarFormulario()
        {

            Cursor.Current = Cursors.WaitCursor;
            CarregarResumo();
            CarregarGradeRetornoProduto(cRetornoId);
            CarregarProdutosConsignados();
            CarregarPedidos();
            CarregarListaPesquisaVendedor();
            CarregarContasAReceber();
            CarregarConferenciaProdutos();
            CarregarAcerto();
            localDepositoForm.tbcRetorno.SelectedTab = localDepositoForm.tabRetornoResumo;
            Cursor.Current = Cursors.Default;



        }

        ////////////////////////////////////////////
        /// Carregar Resumo
        ////////////////////////////////////////////
        

        public void CarregarResumo()
        {


        }

        ////////////////////////////////////////////
        /// Carregar Pesquisa de Produtos do Retorno
        ////////////////////////////////////////////


        public void LimparRetornoProduto()
        {
            localDepositoForm.txtRetornoCodigoBarras.Text = "";
            localDepositoForm.txtRetornoProduto.Text = "";
            localDepositoForm.txtRetornoQuantidade.Text = "";
            localDepositoForm.btnRetornoConfirmar.Enabled = false;
            localDepositoForm.btnRetornoCancelar.Enabled = false;
            localDepositoForm.txtRetornoCodigoBarras.ReadOnly = false;
            cRetornoProdutoGradeId = 0;
            cModoRetornoProduto = "Insert";
        }



        void CarregarGradeRetornoProduto(int pCargaId)
        {

            ModelLibrary.Representante representante = (ModelLibrary.Representante)localDepositoForm.cbbRetornoRepresentante.SelectedItem;
            var representanteId = representante.Id;
            ModelLibrary.Praca praca = (ModelLibrary.Praca)localDepositoForm.cbbRetornoPraca.SelectedItem;
            var pracaId = praca.Id;
            int mes = localDepositoForm.cbbRetornoMesAno.Value.Month;
            int ano = localDepositoForm.cbbRetornoMesAno.Value.Year;

            localDepositoForm.grdRetornoProduto.DataSource = ModelLibrary.MetodosDeposito.ObterProdutosCarga(pCargaId);

            /// Ocultar colunas CargaId e cRetornoProdutoGradeId
            localDepositoForm.grdRetornoProduto.Columns[8].Visible = false;
            localDepositoForm.grdRetornoProduto.Columns[9].Visible = false;

            /// Exibir Coluna como "Moeda"
            localDepositoForm.grdRetornoProduto.Columns[6].DefaultCellStyle.Format = "c";
            localDepositoForm.grdRetornoProduto.Columns[7].DefaultCellStyle.Format = "c";

            /// Alterar Título da Coluna
            localDepositoForm.grdRetornoProduto.Columns[0].HeaderText = "Código de Barras";
            localDepositoForm.grdRetornoProduto.Columns[5].HeaderText = "Quantidade Retorno";
            localDepositoForm.grdRetornoProduto.Columns[6].HeaderText = "Valor Saída";
            localDepositoForm.grdRetornoProduto.Columns[7].HeaderText = "Valor Custo";
        }


        public void LimparGradeRetornoProduto()
        {
            localDepositoForm.grdRetornoProduto.DataSource = null;
            localDepositoForm.tbcRetorno.Visible = false;

        }


        public void PesquisarRetornoProduto(string pCodigo)
        {

            int rowIndex = -1;

            DataGridViewRow produto = localDepositoForm.grdRetornoProduto.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells["CodigoBarras"].Value.ToString().Equals(pCodigo))
                .FirstOrDefault();

            


            if (produto != null)
            {

                rowIndex = produto.Index;

                localDepositoForm.txtRetornoProduto.Text = localDepositoForm.grdRetornoProduto.Rows[rowIndex].Cells["Descricao"].Value.ToString();
                localDepositoForm.txtRetornoQuantidade.Text = localDepositoForm.grdRetornoProduto.Rows[rowIndex].Cells["QuantidadeRetorno"].Value.ToString();


                if (localDepositoForm.txtRetornoCodigoBarras.Text != localDepositoForm.grdRetornoProduto.Rows[rowIndex].Cells["CodigoBarras"].Value.ToString())
                {
                    localDepositoForm.txtRetornoCodigoBarras.Text = localDepositoForm.grdRetornoProduto.Rows[rowIndex].Cells["CodigoBarras"].Value.ToString();
                    if (localDepositoForm.chkRetornoQuantidade.Checked == false)
                    {
                        localDepositoForm.chkRetornoQuantidade.Checked = true;
                        localDepositoForm.txtRetornoQuantidade.Enabled = true;
                    }
                }



                cRetornoProdutoGradeId = Convert.ToInt32(localDepositoForm.grdRetornoProduto.Rows[rowIndex].Cells["ProdutoGradeId"].Value.ToString());
                Console.WriteLine("ProdutoGradeID: " + cRetornoProdutoGradeId.ToString());

                localDepositoForm.btnRetornoConfirmar.Enabled = true;
                localDepositoForm.btnRetornoCancelar.Enabled = true;

                if (localDepositoForm.chkRetornoQuantidade.Checked)
                {
                    localDepositoForm.txtRetornoQuantidade.Focus();

                }
                else
                {
                    //inserir direto qtd=1

                    int tempQtd = localDepositoForm.grdRetornoProduto.Rows[rowIndex].Cells["QuantidadeRetorno"].Value != null ? Convert.ToInt32(localDepositoForm.grdRetornoProduto.Rows[rowIndex].Cells["QuantidadeRetorno"].Value) : 0;
                    localDepositoForm.txtRetornoQuantidade.Text = (tempQtd + 1).ToString();
                    AlterarRetornoProdutoGrade();
                }

            }
            else
            {

                MessageBox.Show("Dígito verificador inválido. Não foi possível encontrar a grade deste produto.");

                cRetornoProdutoGradeId = 0;
                localDepositoForm.txtRetornoCodigoBarras.Focus();
                localDepositoForm.btnRetornoConfirmar.Enabled = false;
                localDepositoForm.btnRetornoCancelar.Enabled = false;


            }
        }


        public void ExibirRetornoProdutoGrade()
        {

            //ClearRetornoProduto();


            cModoRetornoProduto = "Edit";
            cRetornoProdutoGradeId = Convert.ToInt32(localDepositoForm.grdRetornoProduto.CurrentRow.Cells[9].Value);

            localDepositoForm.txtRetornoCodigoBarras.Text = localDepositoForm.grdRetornoProduto.CurrentRow.Cells[0].Value.ToString();
            localDepositoForm.txtRetornoCodigoBarras.ReadOnly = true;


            if (localDepositoForm.chkRetornoQuantidade.Checked == false)
            {
                localDepositoForm.chkRetornoQuantidade.Checked = true;
                localDepositoForm.txtRetornoQuantidade.Enabled = true;
            }
            localDepositoForm.txtRetornoQuantidade.Text = localDepositoForm.grdRetornoProduto.CurrentRow.Cells[5].Value.ToString();

            localDepositoForm.txtRetornoProduto.Text = localDepositoForm.grdRetornoProduto.CurrentRow.Cells[1].Value.ToString();


            localDepositoForm.btnRetornoConfirmar.Enabled = true;
            localDepositoForm.btnRetornoCancelar.Enabled = true;


        }






        public void AlterarRetornoProdutoGrade()
        {

            /*try
            {*/

            ModelLibrary.MetodosDeposito.AlterarRetornoProduto(cRetornoId, cRetornoProdutoGradeId, Convert.ToDouble(localDepositoForm.txtRetornoQuantidade.Text));

            CarregarGradeRetornoProduto(cRetornoId);

            LimparRetornoProduto();

            /*} catch
            {

                MessageBox.Show("Não foi possível alterar o produto. Por favor, verifique os dados digitados e tente novamente");

            }*/


        }


        public void ConfirmarRetornoProdutoGrade()
        {

            AlterarRetornoProdutoGrade();

        }



        ////////////////////////////////////////////
        /// Produtos Consignados
        ////////////////////////////////////////////
        
        public void CarregarProdutosConsignados()
        {

            localDepositoForm.grdRetornoProdConsig.DataSource = ModelLibrary.MetodosDeposito.ObterListaProdutosConsignados(cRetornoId);

            localDepositoForm.grdRetornoProdConsig.Columns[1].Width = 250;


        }

        ////////////////////////////////////////////
        /// Pedidos
        ////////////////////////////////////////////
        
        public void CarregarPedidos(Boolean pAtual = true)
        {

            localDepositoForm.grdRetornoPedido.DataSource = ModelLibrary.MetodosDeposito.ObterListaPedidosRetorno(cRetornoId, pAtual);

            if (pAtual)
            {

                localDepositoForm.btnRetornoPedidoAtual.Enabled = false;
                localDepositoForm.btnRetornoPedidoAnterior.Enabled = true;

            } else
            {
                localDepositoForm.btnRetornoPedidoAtual.Enabled = true;
                localDepositoForm.btnRetornoPedidoAnterior.Enabled = false;

            }

            localDepositoForm.grdRetornoPedido.Columns[1].Width = 250;
            localDepositoForm.grdRetornoPedido.Columns[2].DefaultCellStyle.Format = "c";
            localDepositoForm.grdRetornoPedido.Columns[3].DefaultCellStyle.Format = "c";
            localDepositoForm.grdRetornoPedido.Columns[4].DefaultCellStyle.Format = "c";
            localDepositoForm.grdRetornoPedido.Columns[5].DefaultCellStyle.Format = "c";
            localDepositoForm.grdRetornoPedido.Columns[6].DefaultCellStyle.Format = "c";
            localDepositoForm.grdRetornoPedido.Columns[7].DefaultCellStyle.Format = "c";

            localDepositoForm.grdRetornoPedido.Refresh();

            


        }

        ////////////////////////////////////////////
        /// Lançamento de Pedidos
        ////////////////////////////////////////////
        


        public void CarregarListaPesquisaVendedor()
        {

            localDepositoForm.cbbPesqVendedor.DataSource = ModelLibrary.MetodosDeposito.ObterListaVendedor(cRetornoId);
            localDepositoForm.cbbPesqVendedor.DisplayMember = "Nome";
            localDepositoForm.cbbPesqVendedor.ValueMember = "Id";
            localDepositoForm.cbbPesqVendedor.Invalidate();
            localDepositoForm.cbbPesqVendedor.SelectedIndex = -1;

            localDepositoForm.cbbPesqVendedor.SelectedIndexChanged += PesquisaVendedor_Change;

        }


        public void VendedorLimpar()
        {
            localDepositoForm.txtPesqVendedorCpfCnpj.Text = "";
            localDepositoForm.cbbPesqVendedor.SelectedIndex = -1;
            localDepositoForm.lblPesqVendedor.Visible = false;

            LancamentoPedidoLimpar();
        }

        public void PesquisaVendedor_Change(object sender, EventArgs e)
        {
            if (localDepositoForm.cbbPesqVendedor.SelectedIndex > 0)
            {
                
                ModelLibrary.Vendedor vendedor = (ModelLibrary.Vendedor)localDepositoForm.cbbPesqVendedor.SelectedItem;

                localDepositoForm.txtPesqVendedorCpfCnpj.Text = vendedor.CpfCnpj;
                VendedorExibir(vendedor.Id);

            }

        }

        public void VendedorPesquisar()
        {

            var vendedor = ModelLibrary.MetodosDeposito.PesquisarVendedor(localDepositoForm.txtPesqVendedorCpfCnpj.Text);

            if (vendedor != null)
            {
                localDepositoForm.cbbPesqVendedor.SelectedIndex = localDepositoForm.cbbPesqVendedor.FindString(vendedor.Nome);

                
            }
            else
            {
                localDepositoForm.lblPesqVendedor.Visible = true;
                localDepositoForm.lblPesqVendedor.Text = "Vendedor não encontrado.";
                LancamentoPedidoLimpar();
            }
        }

        public void VendedorExibir(long pVendedorId)
        {

            LancamentoPedidoLimpar();

            var vendedor = ModelLibrary.MetodosDeposito.ObterVendedor(pVendedorId);


            if (vendedor != null)
            {
                var pedido = ModelLibrary.MetodosDeposito.ObterVendedorPedido(vendedor.Id, cRetornoId);

                Console.WriteLine("Pesquisando Pedido do Vendedor: " + vendedor.Id.ToString() + " referente a carga: " + cRetornoId.ToString());

                

                if (pedido != null)
                {

                    cRetornoPedidoId = pedido.Id;

                    localDepositoForm.lblPesqVendedor.Visible = false;

                    localDepositoForm.grpPesqVendedorPedido.Visible = true;
                    localDepositoForm.pnlLancPedTop.Visible = true;
                    localDepositoForm.pnlLancPedMain.Visible = true;
                                       

                    localDepositoForm.dlbValorPedido.Text = string.Format("{0:C2}", pedido.ValorPedido);
                    localDepositoForm.dlbValorCompra.Text = string.Format("{0:C2}", pedido.ValorCompra);
                    localDepositoForm.dlbPercentualComissao.Text = string.Format("{0}%", pedido.PercentualFaixa);
                    localDepositoForm.dlbValorComissao.Text = string.Format("{0:C2}", pedido.ValorComissao);
                    localDepositoForm.dlbValorLiquido.Text = string.Format("{0:C2}", pedido.ValorLiquido);
                    localDepositoForm.dlbRecebimentoAnterior.Text = string.Format("{0:C2}", pedido.ValorAReceber);

                    localDepositoForm.dlbTotalAPagar.Text = string.Format("{0:C2}", pedido.ValorLiquido + pedido.ValorAReceber);


                    CarregarListaLancamentoPedido();

                }

                else
                {
                    localDepositoForm.lblPesqVendedor.Visible = true;
                    localDepositoForm.lblPesqVendedor.Text = "Vendedor não possui pedidos associados a esta carga.";
                    LancamentoPedidoLimpar();
                }
            }
            else
            {
                localDepositoForm.lblPesqVendedor.Visible = true;
                localDepositoForm.lblPesqVendedor.Text = "Vendedor não encontrado.";
                LancamentoPedidoLimpar();
            }

        }



        public void LancamentoPedidoLimpar()
        {
            cRetornoPedidoId = 0;
            localDepositoForm.grpPesqVendedorPedido.Visible = false;
            localDepositoForm.pnlLancPedTop.Visible = false;
            localDepositoForm.pnlLancPedMain.Visible = false;

        }

        public void LancamentoPedidoItemLimpar()
        {

            localDepositoForm.txtLancPedCodigoBarras.Text = "";
            localDepositoForm.txtLancPedProduto.Text = "";
            localDepositoForm.txtLancPedQuantidade.Text = "";
            localDepositoForm.txtLancPedQtdRetorno.Text = "";
            localDepositoForm.txtLancPedPreco.Text = "";

            localDepositoForm.btnLancPedConfirmar.Enabled = false;
            localDepositoForm.btnLancPedCancelar.Enabled = false;



        }


        public void CarregarListaLancamentoPedido()
        {

            localDepositoForm.grdLancPedido.DataSource = ModelLibrary.MetodosDeposito.ObterListaPedidoItem(cRetornoPedidoId);

            localDepositoForm.grdLancPedido.Columns[0].Visible = false;
            localDepositoForm.grdLancPedido.Columns[1].Width = 250;

        }


        public void LancamentoPedidoPesquisar(string pCodigo)
        {


            int rowIndex = -1;

            DataGridViewRow pedidoitem = localDepositoForm.grdLancPedido.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells["CodigoBarras"].Value.ToString().Equals(pCodigo))
                .FirstOrDefault();


            if (pedidoitem != null)
            {

                rowIndex = pedidoitem.Index;

                localDepositoForm.txtLancPedProduto.Text = localDepositoForm.grdLancPedido.Rows[rowIndex].Cells["NomeProduto"].Value.ToString();
                localDepositoForm.txtLancPedQuantidade.Text = localDepositoForm.grdLancPedido.Rows[rowIndex].Cells["Quantidade"].Value.ToString();
                localDepositoForm.txtLancPedQtdRetorno.Text = localDepositoForm.grdLancPedido.Rows[rowIndex].Cells["Retorno"].Value.ToString();
                localDepositoForm.txtLancPedPreco.Text = localDepositoForm.grdLancPedido.Rows[rowIndex].Cells["Preco"].Value.ToString();


                if (localDepositoForm.txtLancPedCodigoBarras.Text != localDepositoForm.grdLancPedido.Rows[rowIndex].Cells["CodigoBarras"].Value.ToString())
                {
                    localDepositoForm.txtLancPedCodigoBarras.Text = localDepositoForm.grdLancPedido.Rows[rowIndex].Cells["CodigoBarras"].Value.ToString();
                    if (localDepositoForm.chkLancPedQuantidade.Checked == false)
                    {
                        localDepositoForm.chkLancPedQuantidade.Checked = true;
                        localDepositoForm.txtLancPedQuantidade.Enabled = true;
                    }
                }


                cRetornoPedidoItemId = Convert.ToInt32(localDepositoForm.grdLancPedido.Rows[rowIndex].Cells["PedidoItemId"].Value.ToString());
                cModoRetornoPedidoItem = "Edit";

                localDepositoForm.btnLancPedConfirmar.Enabled = true;
                localDepositoForm.btnLancPedCancelar.Enabled = true;

                if (localDepositoForm.chkLancPedQuantidade.Checked)
                {
                    localDepositoForm.txtLancPedQuantidade.Focus();

                }
                else
                {
                    //inserir direto qtd=1

                    int tempQtd = localDepositoForm.grdLancPedido.Rows[rowIndex].Cells["Quantidade"].Value != null ? Convert.ToInt32(localDepositoForm.grdLancPedido.Rows[rowIndex].Cells["Quantidade"].Value) : 0;
                    localDepositoForm.txtLancPedQuantidade.Text = (tempQtd + 1).ToString();
                    SalvarLancamentoPedido();
                }

            }
            else
            {


                /// pesquisar no BD
                /// 
                var produtograde = ModelLibrary.MetodosDeposito.ObterProdutoGrade(localDepositoForm.txtLancPedCodigoBarras.Text);

                if (produtograde != null)
                {
                    /// se existir -- carregar com ação de incluir

                    var produto = ModelLibrary.MetodosDeposito.ObterProduto(produtograde.CodigoBarras);



                    localDepositoForm.txtLancPedProduto.Text = produto.Descricao;
                    localDepositoForm.txtLancPedQuantidade.Text = "";
                    localDepositoForm.txtLancPedQtdRetorno.Text = "";
                    localDepositoForm.txtLancPedPreco.Text = produtograde.ValorSaida.ToString();

                    localDepositoForm.txtLancPedQuantidade.Focus();
                    cRetornoPedidoProdutoGradeId = produtograde.Id;
                    cModoRetornoPedidoItem = "Insert";

                    localDepositoForm.btnLancPedConfirmar.Enabled = true;
                    localDepositoForm.btnLancPedCancelar.Enabled = true;
                }
                else
                {
                    /// se não - exibir mensagem de erro
                    MessageBox.Show("Dígito verificador inválido. Não foi possível encontrar a grade deste produto.");

                    cRetornoPedidoItemId = 0;
                    localDepositoForm.txtLancPedCodigoBarras.Focus();
                    localDepositoForm.btnLancPedConfirmar.Enabled = false;
                    localDepositoForm.btnLancPedCancelar.Enabled = false;
                }

            }

        }


        public void SalvarLancamentoPedido()
        {
            if (cModoRetornoPedidoItem == "Edit")
            {

                ModelLibrary.MetodosDeposito.AlterarPedidoItem(cRetornoPedidoItemId, Convert.ToDouble(localDepositoForm.txtLancPedQuantidade.Text), Convert.ToDouble(localDepositoForm.txtLancPedQtdRetorno.Text), Convert.ToDouble(localDepositoForm.txtLancPedPreco.Text));

            } else
            {

                ModelLibrary.MetodosDeposito.InserirPedidoItem(cRetornoPedidoId, cRetornoPedidoProdutoGradeId, Convert.ToDouble(localDepositoForm.txtLancPedQuantidade.Text), Convert.ToDouble(localDepositoForm.txtLancPedQtdRetorno.Text), Convert.ToDouble(localDepositoForm.txtLancPedPreco.Text));

            }

            CarregarListaLancamentoPedido();
            LancamentoPedidoItemLimpar();

        }
        

        ////////////////////////////////////////////
        /// Contas a Receber
        ////////////////////////////////////////////
        
        public void CarregarContasAReceber()
        {
            localDepositoForm.grdContasAReceber.DataSource = ModelLibrary.MetodosDeposito.ObterListaAReceber(cRetornoId);

            localDepositoForm.grdContasAReceber.Columns[0].Visible = false;
            localDepositoForm.grdContasAReceber.Columns[1].Visible = false;
            localDepositoForm.grdContasAReceber.Columns[4].Width = 250;
            localDepositoForm.grdContasAReceber.Columns[5].DefaultCellStyle.Format = "c";
            localDepositoForm.grdContasAReceber.Columns[6].DefaultCellStyle.Format = "c";


        }


        public void LimparAReceber()
        {
            localDepositoForm.txtRetornoRecDocumento.Text = "";
            localDepositoForm.txtRetornoRecDocumento.ReadOnly = false;
            localDepositoForm.txtRetornoRecSerie.Text = "";
            localDepositoForm.txtRetornoRecSerie.ReadOnly = false;


            localDepositoForm.txtRetornoRecNome.Text = "";
            localDepositoForm.txtRetornoRecValor.Text = "";
            localDepositoForm.txtRetornoRecData.Text = DateTime.Now.ToString();


            cModoRetornoReceber = null;
            cRetornoReceberBaixaId = 0;

            localDepositoForm.btnRetornoRecConfirmar.Enabled = false;
            localDepositoForm.btnRetornoRecCancelar.Enabled = false;

        }


        public void PesquisarAReceber(string pDocumento, string pSerie) 
        {


            int rowIndex = -1;

            DataGridViewRow receber = localDepositoForm.grdContasAReceber.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells["Documento"].Value.ToString().Equals(pDocumento) && r.Cells["Serie"].Value.ToString().Equals(pSerie))
                .FirstOrDefault();




            if (receber != null)
            {

                rowIndex = receber.Index;

                ExibirAReceber(rowIndex);
            }
            else
            {

                MessageBox.Show("Documento ou série não encontrados. Por favor, verifique os dados digitados");

                cRetornoProdutoGradeId = 0;
                localDepositoForm.txtRetornoRecDocumento.Focus();
                localDepositoForm.btnRetornoRecConfirmar.Enabled = false;
                localDepositoForm.btnRetornoRecCancelar.Enabled = false;


            }


        }

        public void ExibirAReceber(int rowindex = -1)
        {

            
            if (rowindex == -1)
            {
                rowindex = localDepositoForm.grdContasAReceber.CurrentRow.Index;
            }


            cRetornoReceberId = Convert.ToInt32(localDepositoForm.grdContasAReceber.Rows[rowindex].Cells["Id"].Value);

            localDepositoForm.txtRetornoRecDocumento.Text = localDepositoForm.grdContasAReceber.Rows[rowindex].Cells["Documento"].Value.ToString();
            localDepositoForm.txtRetornoRecDocumento.ReadOnly = true;

            localDepositoForm.txtRetornoRecSerie.Text = localDepositoForm.grdContasAReceber.Rows[rowindex].Cells["Serie"].Value.ToString();
            localDepositoForm.txtRetornoRecSerie.ReadOnly = true;


            localDepositoForm.txtRetornoRecNome.Text = localDepositoForm.grdContasAReceber.Rows[rowindex].Cells["Nome"].Value.ToString();

            if (localDepositoForm.grdContasAReceber.Rows[rowindex].Cells["ValorPago"].Value == null) {

                localDepositoForm.txtRetornoRecValor.Text = localDepositoForm.grdContasAReceber.Rows[rowindex].Cells["ValorAReceber"].Value.ToString();
                localDepositoForm.txtRetornoRecData.Text = DateTime.Now.ToString();

                cRetornoReceberBaixaId = 0;

                cModoRetornoReceber = "Insert";

            } else
            {

                localDepositoForm.txtRetornoRecValor.Text = localDepositoForm.grdContasAReceber.Rows[rowindex].Cells["ValorPago"].Value.ToString();
                localDepositoForm.txtRetornoRecData.Text = localDepositoForm.grdContasAReceber.Rows[rowindex].Cells["DataPagamento"].Value.ToString();
                cRetornoReceberBaixaId = Convert.ToInt32(localDepositoForm.grdContasAReceber.Rows[rowindex].Cells["ReceberBaixaId"].Value);
                cModoRetornoReceber = "Edit";

            }
            

            localDepositoForm.btnRetornoRecConfirmar.Enabled = true;
            localDepositoForm.btnRetornoRecCancelar.Enabled = true;


        }


        public void ConfirmarAReceber()
        {

            ModelLibrary.MetodosDeposito.SalvarAReceber(cRetornoReceberId, cRetornoReceberBaixaId, Convert.ToDouble(localDepositoForm.txtRetornoRecValor.Text), localDepositoForm.txtRetornoRecData.Text);

            CarregarContasAReceber();

            LimparAReceber();

        }



        ////////////////////////////////////////////
        /// Produtos Conferencia
        ////////////////////////////////////////////


        public void CarregarConferenciaProdutos()
        {
            localDepositoForm.grdRetornoConfProdutos.DataSource = ModelLibrary.MetodosDeposito.ObterListaProdutoConferencia(cRetornoId);

            localDepositoForm.grdRetornoConfProdutos.Columns[1].Width = 250;
        }
        

        ////////////////////////////////////////////
        /// Acerto
        ////////////////////////////////////////////
        
        public void CarregarAcerto()
        {



        }

        public void FinalizarAcerto()
        {

            ModelLibrary.MetodosDeposito.AlterarStatusCarga(cRetornoId, "F");
        }

    }
}