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
    public partial class Carga
    {

        //////////////////////////////
        /// Declaração de Variáveis
        //////////////////////////////

        public Int32 cCargaId;
        public Int32 cCargaProdutoGradeId;
        public string cModoCargaProduto;
        public Int32 cRetornoId;

        public FormDeposito localDepositoForm = null;

        public Carga(FormDeposito formDeposito)
        {

            localDepositoForm = formDeposito;

        }


        ///////////////////////////////////////////
        /// Carregar Formulário de Pesquisa Carga
        ///////////////////////////////////////////

        public void CarregarListaCarga()
        {
            localDepositoForm.cbbCargaPraca.DataSource = ModelLibrary.MetodosDeposito.ObterListaPracas();
            localDepositoForm.cbbCargaPraca.DisplayMember = "Descricao";
            localDepositoForm.cbbCargaPraca.ValueMember = "Id";
            localDepositoForm.cbbCargaPraca.Invalidate();
            localDepositoForm.cbbCargaPraca.SelectedIndex = -1;
        }

        public void CarregarListaRepresentante()
        {
            localDepositoForm.cbbCargaRepresentante.DataSource = ModelLibrary.MetodosDeposito.ObterListaRepresentantes();
            localDepositoForm.cbbCargaRepresentante.DisplayMember = "Nome";
            localDepositoForm.cbbCargaRepresentante.ValueMember = "Id";
            localDepositoForm.cbbCargaRepresentante.Invalidate();
            localDepositoForm.cbbCargaRepresentante.SelectedIndex = -1;
        }


        public void LimparCarga()
        {
            localDepositoForm.cbbCargaPraca.SelectedIndex = -1;
            localDepositoForm.cbbCargaRepresentante.SelectedIndex = -1;
            localDepositoForm.txtCargaCodPraca.Text = "";
            localDepositoForm.txtCargaCodRepresentante.Text = "";
            localDepositoForm.cbbCargaMesAno.ResetText();

            localDepositoForm.tbcCarga.Visible = false;
            localDepositoForm.txtCargaCodigoBarras.Text = "";
            localDepositoForm.txtCargaProduto.Text = "";
            localDepositoForm.txtCargaQuantidade.Text = "";
            localDepositoForm.btnCargaConfirmar.Enabled = false;
        }

        public void ResetarVariaveis()
        {
            cCargaId = 0;
            cCargaProdutoGradeId = 0;
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


                ModelLibrary.Representante representante = (ModelLibrary.Representante)localDepositoForm.cbbCargaRepresentante.SelectedItem;
                var representanteId = representante.Id;
                ModelLibrary.Praca praca = (ModelLibrary.Praca)localDepositoForm.cbbCargaPraca.SelectedItem;
                var pracaId = praca.Id;
                int mes = localDepositoForm.cbbCargaMesAno.Value.Month;
                int ano = localDepositoForm.cbbCargaMesAno.Value.Year;

                /* Procurar Carga no BD com os dados selecionados */


                var carga = ModelLibrary.MetodosDeposito.ObterCarga(representanteId, pracaId, mes, ano);

                if (carga != null) /* Se existir Carga */
                {
                    /* Carrega Grid com Produtos */
                    localDepositoForm.tbcCarga.Visible = true;

                    cCargaId = carga.Id;

                    CarregarGradeCargaProduto(carga.Id);


                    var totalizadores = ModelLibrary.MetodosDeposito.ObterTotalizadores(cCargaId);

                    localDepositoForm.dlbQtdProdutos.Text = totalizadores[0].ToString();
                    localDepositoForm.dlbTotalProdutos.Text = totalizadores[1].ToString("C");





                    localDepositoForm.dlbCargaDataAbertura.Text = carga.DataAbertura.HasValue ? carga.DataAbertura.Value.ToShortDateString() : "-";
                    localDepositoForm.dlbCargaDataExportacao.Text = carga.DataExportacao.HasValue ? carga.DataExportacao.Value.ToShortDateString() : "-";
                    localDepositoForm.dlbCargaDataRetorno.Text = carga.DataRetorno.HasValue ? carga.DataRetorno.Value.ToShortDateString() : "-";
                    localDepositoForm.dlbCargaDataConferencia.Text = carga.DataConferencia.HasValue ? carga.DataConferencia.Value.ToShortDateString() : "-";
                    localDepositoForm.dlbCargaDataFinalizacao.Text = carga.DataFinalizacao.HasValue ? carga.DataFinalizacao.Value.ToShortDateString() : "-";

                    var viagemanterior = ModelLibrary.MetodosDeposito.ObterViagemAnterior(representanteId, pracaId, carga.DataAbertura.Value);

                    if (viagemanterior != null)
                    {

                        localDepositoForm.dlbCargaVADataAbertura.Text = viagemanterior.DataAbertura.HasValue ? viagemanterior.DataAbertura.Value.ToShortDateString() : "-";
                        localDepositoForm.dlbCargaVADataExportacao.Text = viagemanterior.DataExportacao.HasValue ? viagemanterior.DataExportacao.Value.ToShortDateString() : "-";
                        localDepositoForm.dlbCargaVADataRetorno.Text = viagemanterior.DataRetorno.HasValue ? viagemanterior.DataRetorno.Value.ToShortDateString() : "-";
                        localDepositoForm.dlbCargaVADataConferencia.Text = viagemanterior.DataConferencia.HasValue ? viagemanterior.DataConferencia.Value.ToShortDateString() : "-";
                        localDepositoForm.dlbCargaVADataFinalizacao.Text = viagemanterior.DataFinalizacao.HasValue ? viagemanterior.DataFinalizacao.Value.ToShortDateString() : "-";

                    }
                    else
                    {

                        localDepositoForm.dlbCargaVADataAbertura.Text = "ND";
                        localDepositoForm.dlbCargaVADataExportacao.Text = "ND";
                        localDepositoForm.dlbCargaVADataRetorno.Text = "ND";
                        localDepositoForm.dlbCargaVADataConferencia.Text = "ND";
                        localDepositoForm.dlbCargaVADataFinalizacao.Text = "ND";

                    }






                }
                else /* Se não existir */
                {
                    if (MessageBox.Show("Não foi encontrada nenhuma carga com os dados informados. Deseja iniciar uma nova carga?", "Importante!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        cCargaId = ModelLibrary.MetodosDeposito.InserirCarga(representanteId, pracaId, mes, ano);
                        localDepositoForm.tbcCarga.Visible = true;
                        //PolulateGradeCargaProduto();
                    }
                    else
                    {
                        LimparCarga();
                    }
                }

            }
            catch (IOException vE)
            {
                MessageBox.Show("Ocorreu um erro ao processar a sua consulta. Verifique os dados digitados e tente novamente. Se o erro persisitr, contate o administrador.");
                Console.WriteLine(vE.Message);
            }
        }


        ////////////////////////////////////////////
        /// Carregar Pesquisa de Produtos da Carga
        ////////////////////////////////////////////



        public void LimparCargaProduto()
        {
            localDepositoForm.txtCargaCodigoBarras.Text = "";
            localDepositoForm.txtCargaProduto.Text = "";
            localDepositoForm.txtCargaQuantidade.Text = "";
            localDepositoForm.btnCargaConfirmar.Enabled = false;
            localDepositoForm.btnCargaCancelar.Enabled = false;
            localDepositoForm.txtCargaCodigoBarras.ReadOnly = false;
            cCargaProdutoGradeId = 0;
            cModoCargaProduto = "Insert";
        }



        void CarregarGradeCargaProduto(int pCargaId)
        {

            ModelLibrary.Representante representante = (ModelLibrary.Representante)localDepositoForm.cbbCargaRepresentante.SelectedItem;
            var representanteId = representante.Id;
            ModelLibrary.Praca praca = (ModelLibrary.Praca)localDepositoForm.cbbCargaPraca.SelectedItem;
            var pracaId = praca.Id;
            int mes = localDepositoForm.cbbCargaMesAno.Value.Month;
            int ano = localDepositoForm.cbbCargaMesAno.Value.Year;

            localDepositoForm.grdCargaProduto.DataSource = ModelLibrary.MetodosDeposito.ObterProdutosCarga(pCargaId);

            /// Ocultar colunas CargaId e cCargaProdutoGradeId
            localDepositoForm.grdCargaProduto.Columns[8].Visible = false;
            localDepositoForm.grdCargaProduto.Columns[9].Visible = false;

            /// Exibir Coluna como "Moeda"
            localDepositoForm.grdCargaProduto.Columns[6].DefaultCellStyle.Format = "c";
            localDepositoForm.grdCargaProduto.Columns[7].DefaultCellStyle.Format = "c";

            /// Alterar Título da Coluna
            localDepositoForm.grdCargaProduto.Columns[0].HeaderText = "Código de Barras";
            localDepositoForm.grdCargaProduto.Columns[5].HeaderText = "Quantidade Retorno";
            localDepositoForm.grdCargaProduto.Columns[6].HeaderText = "Valor Saída";
            localDepositoForm.grdCargaProduto.Columns[7].HeaderText = "Valor Custo";
        }
        

        public void LimparGradeCargaProduto()
        {
            localDepositoForm.grdCargaProduto.DataSource = null;
            localDepositoForm.tbcCarga.Visible = false;

        }


        public void PesquisarCargaProduto(string pCodigo)
        {



            var produtograde = ModelLibrary.MetodosDeposito.ObterProdutoGrade(pCodigo);

            if (produtograde != null)
            {

                var produto = ModelLibrary.MetodosDeposito.ObterProduto(produtograde.CodigoBarras);

                localDepositoForm.txtCargaProduto.Text = produto.Descricao;

                if (localDepositoForm.txtCargaCodigoBarras.Text != produtograde.CodigoBarras + produtograde.Digito)
                {
                    localDepositoForm.txtCargaCodigoBarras.Text = produtograde.CodigoBarras + produtograde.Digito;
                    if (localDepositoForm.chkCargaQuantidade.Checked == false)
                    {
                        localDepositoForm.chkCargaQuantidade.Checked = true;
                        localDepositoForm.txtCargaQuantidade.Enabled = true;
                    }
                }



                cCargaProdutoGradeId = produtograde.Id;

                localDepositoForm.btnCargaConfirmar.Enabled = true;
                localDepositoForm.btnCargaCancelar.Enabled = true;

                if (localDepositoForm.chkCargaQuantidade.Checked)
                {
                    localDepositoForm.txtCargaQuantidade.Focus();

                }
                else
                {
                    //inserir direto qtd=1
                    InserirCargaProdutoGrade();
                }

            }
            else
            {

                MessageBox.Show("Dígito verificador inválido. Não foi possível encontrar a grade deste produto.");

                cCargaProdutoGradeId = 0;
                localDepositoForm.txtCargaCodigoBarras.Focus();
                localDepositoForm.btnCargaConfirmar.Enabled = false;
                localDepositoForm.btnCargaCancelar.Enabled = false;


            }
        }


        public void ExibirCargaProdutoGrade()
        {

            //ClearCargaProduto();


            cModoCargaProduto = "Edit";
            cCargaProdutoGradeId = Convert.ToInt32(localDepositoForm.grdCargaProduto.CurrentRow.Cells[9].Value);

            localDepositoForm.txtCargaCodigoBarras.Text = localDepositoForm.grdCargaProduto.CurrentRow.Cells[0].Value.ToString();
            localDepositoForm.txtCargaCodigoBarras.ReadOnly = true;


            if (localDepositoForm.chkCargaQuantidade.Checked == false)
            {
                localDepositoForm.chkCargaQuantidade.Checked = true;
                localDepositoForm.txtCargaQuantidade.Enabled = true;
            }
            localDepositoForm.txtCargaQuantidade.Text = localDepositoForm.grdCargaProduto.CurrentRow.Cells[4].Value.ToString();

            localDepositoForm.txtCargaProduto.Text = localDepositoForm.grdCargaProduto.CurrentRow.Cells[1].Value.ToString();


            localDepositoForm.btnCargaConfirmar.Enabled = true;
            localDepositoForm.btnCargaCancelar.Enabled = true;


        }









        public void InserirCargaProdutoGrade()
        {
            try
            {
                double vQuantidade;

                if (localDepositoForm.chkCargaQuantidade.Checked)
                {

                    if (localDepositoForm.txtCargaQuantidade.Text != "")
                    {
                        vQuantidade = Convert.ToDouble(localDepositoForm.txtCargaQuantidade.Text);
                    }
                    else
                    {
                        MessageBox.Show("Por favor, informe uma quantidade.");
                        vQuantidade = 0;
                    }

                }
                else
                {

                    vQuantidade = 1;

                }

                if (vQuantidade > 0)
                {
                    ModelLibrary.MetodosDeposito.InserirCargaProduto(cCargaId, cCargaProdutoGradeId, vQuantidade);
                    CarregarGradeCargaProduto(cCargaId);
                    LimparCargaProduto();
                }


            }
            catch (IOException vE)
            {
                MessageBox.Show("Ocorreu um erro ao Inserir o produto. Verifique os dados digitados e tente novamente. Se o erro persisitr, contate o administrador.");
                Console.WriteLine(vE.Message);
            }


        }

        

        public void AlterarCargaProdutoGrade()
        {

            /*try
            {*/

            ModelLibrary.MetodosDeposito.AlterarCargaProduto(cCargaId, cCargaProdutoGradeId, Convert.ToDouble(localDepositoForm.txtCargaQuantidade.Text));

            CarregarGradeCargaProduto(cCargaId);

            LimparCargaProduto();

            /*} catch
            {

                MessageBox.Show("Não foi possível alterar o produto. Por favor, verifique os dados digitados e tente novamente");

            }*/


        }


        public void ConfirmarCargaProdutoGrade()
        {

            if (cModoCargaProduto == "Edit")
            {
                AlterarCargaProdutoGrade();
            }
            else
            {
                InserirCargaProdutoGrade();
            }

        }

        public void ExcluirCargaProdutoGrade()
        {



            if (MessageBox.Show("Deseja realmente excluir o produto selecionado?", "ATENÇÃO! Exclusão de Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                LimparCargaProduto();
                cCargaProdutoGradeId = Convert.ToInt32(localDepositoForm.grdCargaProduto.CurrentRow.Cells[9].Value);


                ModelLibrary.MetodosDeposito.ExcluirCargaProduto(cCargaId, cCargaProdutoGradeId);

                CarregarGradeCargaProduto(cCargaId);
            }


        }



    }
}
