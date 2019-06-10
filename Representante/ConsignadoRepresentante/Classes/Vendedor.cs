﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsignadoRepresentante;
using System.Windows.Forms;

namespace ConsignadoRepresentante
{
    public partial class Vendedor
    {
        //////////////////////////////
        /// Declaração de Variáveis
        //////////////////////////////
        

        public FormRepresentante localRepresentanteForm = null;

        public long cVendedorId;

        public string cTipoPessoa;

        public string cVendedorModo;

        public string cVendedorPedidoModo;

        public string cVendedorProdRetModo;

        public long cPedidoId;

        decimal cValorRecebido, cValorTotalAPagar;

        long cDuplicataReceberId, cDuplicataId;





        public Vendedor(FormRepresentante formRepresentante)
        {

            localRepresentanteForm = formRepresentante;
        
        }


        public void CarregarFormulario()
        {


            CarregarListaPesquisa();
            CarregarListaEstado();



        }


        ////////////////////////////////////////
        /// Pesquisar Vendedor
        ////////////////////////////////////////



        public void CarregarListaPesquisa()
        {
            localRepresentanteForm.cbbPesqVendedor.DataSource = ModelLibrary.MetodosRepresentante.ObterListaVendedor();
            localRepresentanteForm.cbbPesqVendedor.DisplayMember = "Nome";
            localRepresentanteForm.cbbPesqVendedor.ValueMember = "Id";
            localRepresentanteForm.cbbPesqVendedor.Invalidate();
            localRepresentanteForm.cbbPesqVendedor.SelectedIndex = -1;

            localRepresentanteForm.cbbPesqVendedor.SelectedIndexChanged += PesquisaVendedor_Change;

        }


        public void PesquisaVendedor_Change(object sender, EventArgs e)
        {
            if (localRepresentanteForm.cbbPesqVendedor.SelectedIndex > 0)
            {
                ModelLibrary.RepVendedor vendedor = (ModelLibrary.RepVendedor)localRepresentanteForm.cbbPesqVendedor.SelectedItem;
                VendedorExibir(vendedor.Id);

            }

        }

        public void VendedorPesquisar()
        {
            var vendedor = ModelLibrary.MetodosRepresentante.PesquisarVendedor(localRepresentanteForm.txtVendedorPesqCodigo.Text, localRepresentanteForm.txtVendedorPesqCpfCnpj.Text);

            if (vendedor != null)
            {
                VendedorExibir(vendedor.Id);
            }

            else
            {

                MessageBox.Show("Vendedor não encontrado.");
            }
        }


        ///////////////////////////////////////////////
        /// Carregar Campos de Cadastro de Vendedor
        ///////////////////////////////////////////////

        public void CarregarListaEstado()
        {


            localRepresentanteForm.cbbUF.DataSource = ModelLibrary.MetodosRepresentante.ObterListaEstado();
            localRepresentanteForm.cbbUF.DisplayMember = "Sigla";
            localRepresentanteForm.cbbUF.ValueMember = "Id";
            localRepresentanteForm.cbbUF.Invalidate();
            localRepresentanteForm.cbbUF.SelectedIndex = -1;

            localRepresentanteForm.cbbUF.SelectedIndexChanged += ListaEstado_Change;

        }




        public void ListaEstado_Change(object sender, EventArgs e)
        {
            if (localRepresentanteForm.cbbUF.SelectedIndex > 0)
            {
                ModelLibrary.RepEstado estado = (ModelLibrary.RepEstado)localRepresentanteForm.cbbUF.SelectedItem;
                CarregarListaCidade(estado.Id);
            }
        }


        void CarregarListaCidade(long pEstadoId = 0)
        {
            localRepresentanteForm.cbbCidade.DataSource = ModelLibrary.MetodosRepresentante.ObterListaCidade(pEstadoId);
            localRepresentanteForm.cbbCidade.DisplayMember = "Descricao";
            localRepresentanteForm.cbbCidade.ValueMember = "Id";
            localRepresentanteForm.cbbCidade.Invalidate();
            localRepresentanteForm.cbbCidade.SelectedIndex = -1;
        }


        public void SelecionarTipoPessoa(string pTipoPessoa)
        {

            if (pTipoPessoa == "Pessoa Física")
            {
                localRepresentanteForm.lblCPFCNPJ.Text = "CPF";
                localRepresentanteForm.txtCPFCnpj.WaterMark = "CPF";

                localRepresentanteForm.txtRazaoSocial.Enabled = false;
                localRepresentanteForm.lblRGInscricao.Text = "RG";
                localRepresentanteForm.txtRGInscricao.WaterMark = "RG";
                cTipoPessoa = "PF";
            }
            else
            {
                localRepresentanteForm.lblCPFCNPJ.Text = "CNPJ";
                localRepresentanteForm.txtCPFCnpj.WaterMark = "CNPJ";
                localRepresentanteForm.txtRazaoSocial.Enabled = true;
                localRepresentanteForm.lblRGInscricao.Text = "Insc. Estadual";
                localRepresentanteForm.txtRGInscricao.WaterMark = "Insc. Estadual";
                cTipoPessoa = "PJ";
            }
        }




        



        ///////////////////////////////////////////////
        /// Validações do Formulario
        ///////////////////////////////////////////////


        public void ValidarCPFCnpj(string pCPFCnpj)
        {
            //verificar se o CPF/CNPJ é valido


            //se estivar cadastrando um novo, verificar se não existe na base

            //se for alteração não permitir alteração

        }


        public void VerificarCPFCnpjExistente(string pCPFCnpj)
        {


            pCPFCnpj = localRepresentanteForm.MascaraCnpjCpf(pCPFCnpj);

            if (pCPFCnpj != "")
            {



                var vendedor = ModelLibrary.MetodosRepresentante.PesquisarVendedor("0", pCPFCnpj);

                if (vendedor != null)
                {

                    if (MessageBox.Show("CPF/CNPJ já cadastrado. Deseja carregar os dados para atualização?", "Reder Consignado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        VendedorExibir(vendedor.Id);
                    }
                    else
                    {

                        VendedorLimpar();
                    }

                }
                else
                {
                    var vendedorbase = ModelLibrary.MetodosRepresentante.PesquisarVendedorBase(pCPFCnpj);

                    if (vendedorbase != null)
                    {

                        if (MessageBox.Show("O CPF/CNPJ informado está cadastrado em uma outra carga. Deseja carregar os dados e continuar com a inclusão?", "Reder Consignado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            VendedorBaseExibir(vendedorbase.Id);
                        }
                        else
                        {
                            VendedorLimpar();
                        }

                    }
                }




            }




        }



        //////////////////////////////////////////////////////
        /// ABA INICIO
        //////////////////////////////////////////////////////


        public void CarregarInicio()
        {

            ///
        }


        ///////////////////////////////////////////////
        /// CRUD Vendedor
        ///////////////////////////////////////////////


        public void VendedorLimpar()
        {
            localRepresentanteForm.cbbPesqVendedor.SelectedIndex = -1;
            localRepresentanteForm.txtVendedorPesqCodigo.Text = "";
            localRepresentanteForm.txtVendedorPesqCpfCnpj.Text = "";

            localRepresentanteForm.tbcVendedor.Visible = false;

            localRepresentanteForm.cbbTipoPessoa.SelectedIndex = -1;
            localRepresentanteForm.txtCPFCnpj.Text = "";
            localRepresentanteForm.txtDataInicial.ResetText();
            localRepresentanteForm.txtDataFinal.ResetText();
            localRepresentanteForm.cbbStatus.SelectedIndex = -1; //--- Ver quais os status apresentados
            localRepresentanteForm.txtNome.Text = "";
            localRepresentanteForm.txtRazaoSocial.Text = "";
            localRepresentanteForm.txtRGInscricao.Text = "";
            localRepresentanteForm.cbbDataNasc.ResetText();
            localRepresentanteForm.txtCep.Text = "";
            localRepresentanteForm.txtEndereco.Text = "";
            localRepresentanteForm.txtComplemento.Text = "";
            localRepresentanteForm.txtBairro.Text = "";
            localRepresentanteForm.cbbUF.SelectedIndex = -1;
            localRepresentanteForm.cbbCidade.SelectedIndex = -1;
            localRepresentanteForm.txtTelefone.Text = "";
            localRepresentanteForm.txtTelefoneComercial.Text = "";
            localRepresentanteForm.txtCelular.Text = "";
            localRepresentanteForm.txtEmail.Text = "";
            localRepresentanteForm.txtLimitePedido.Text = "";
            localRepresentanteForm.txtLimiteCredito.Text = "";
            localRepresentanteForm.txtObservacao.Text = "";

            cVendedorId = 0;


            PedidoLimpar();
            RetornoProdutoLimpar();
        }



        public void VendedorExibir(long pVendedorId)
        {
            var vendedor = ModelLibrary.MetodosRepresentante.ObterVendedor(pVendedorId);


            if (vendedor != null)
            {

                cVendedorId = vendedor.Id;
                localRepresentanteForm.tbcVendedor.Visible = true;
                localRepresentanteForm.cbbTipoPessoa.Text = vendedor.TipoPessoa == "PF" ? "Pessoa Física" : "Pessoa Jurídica";
                localRepresentanteForm.txtCPFCnpj.Text = vendedor.CpfCnpj.Trim();
                localRepresentanteForm.txtDataInicial.Text = vendedor.DataInicial.ToString();
                localRepresentanteForm.txtDataFinal.Text = vendedor.DataFinal.ToString();


                switch (vendedor.Status)
                {
                    case "2":
                        localRepresentanteForm.cbbStatus.Text = "Negativado";
                        break;
                    case "0":
                        localRepresentanteForm.cbbStatus.Text = "Inativo";
                        break;
                    default:
                        localRepresentanteForm.cbbStatus.Text = "Ativo";
                        break;
                }
                //cbbStatus --- Ver quais os status apresentados
                localRepresentanteForm.txtNome.Text = vendedor.Nome.Trim();
                localRepresentanteForm.txtRazaoSocial.Text = vendedor.RazaoSocial.Trim();
                localRepresentanteForm.txtRGInscricao.Text = vendedor.RGInscricao.Trim();
                localRepresentanteForm.cbbDataNasc.Text = vendedor.DataNascimento.ToString();
                localRepresentanteForm.txtCep.Text = vendedor.Cep.Trim();
                localRepresentanteForm.txtEndereco.Text = vendedor.Endereco.Trim();
                localRepresentanteForm.txtComplemento.Text = vendedor.Complemento.Trim();
                localRepresentanteForm.txtBairro.Text = vendedor.Bairro.Trim();
                localRepresentanteForm.cbbUF.Text = vendedor.UF.Trim();
                localRepresentanteForm.cbbCidade.Text = vendedor.Cidade.Trim();
                localRepresentanteForm.txtTelefone.Text = vendedor.Telefone.Trim();
                localRepresentanteForm.txtTelefoneComercial.Text = vendedor.TelefoneComercial.Trim();
                localRepresentanteForm.txtCelular.Text = vendedor.Celular.Trim();
                localRepresentanteForm.txtEmail.Text = vendedor.Email.Trim();
                localRepresentanteForm.txtLimitePedido.Text = vendedor.LimitePedido.ToString();
                localRepresentanteForm.txtLimiteCredito.Text = vendedor.LimiteCredito.ToString();
                localRepresentanteForm.txtObservacao.Text = vendedor.Observacao.Trim();

                cVendedorModo = "Edit";


                localRepresentanteForm.cbbPesqVendedor.Text = vendedor.Nome;
                localRepresentanteForm.txtVendedorPesqCodigo.Text = vendedor.Id.ToString();
                localRepresentanteForm.txtVendedorPesqCpfCnpj.Text = vendedor.CpfCnpj.ToString();



                ExibirPedido(cVendedorId);
                ExibirRetornoProduto(cVendedorId);
                ExibirAcerto();
                ExibirRecebimentos();


            }
            else
            {
                MessageBox.Show("Vendedor não encontrado.");
            }



        }

        public void VendedorIncluir()
        {
            VendedorLimpar();
            localRepresentanteForm.tbcVendedor.Visible = true;
            localRepresentanteForm.tbcVendedor.SelectedTab = localRepresentanteForm.tabVendedorCadastro;
            cVendedorModo = "Create";

        }

        public void VendedorSalvar()
        {

            localRepresentanteForm.btnVendedorSalvar.Text = "Salvando...";
            localRepresentanteForm.btnVendedorSalvar.Enabled = false;

            Cursor.Current = Cursors.WaitCursor;

            ModelLibrary.RepVendedor vendedor = new ModelLibrary.RepVendedor();


            vendedor.TipoPessoa = localRepresentanteForm.cbbTipoPessoa.Text == "Pessoa Física" ? "PF" : "PJ";
            vendedor.CpfCnpj = localRepresentanteForm.txtCPFCnpj.Text;
            vendedor.DataInicial = localRepresentanteForm.txtDataInicial.Value;
            vendedor.DataFinal = localRepresentanteForm.txtDataFinal.Value;

            switch (localRepresentanteForm.cbbStatus.Text)
            {
                case "Negativado":
                    vendedor.Status = "2";
                    break;
                case "Inativo":
                    vendedor.Status = "0";
                    break;
                default:
                    vendedor.Status = "1";
                    break;
            }

            vendedor.Nome = localRepresentanteForm.txtNome.Text;
            vendedor.RazaoSocial = localRepresentanteForm.txtRazaoSocial.Text;
            vendedor.RGInscricao = localRepresentanteForm.txtRGInscricao.Text;
            vendedor.DataNascimento = localRepresentanteForm.cbbDataNasc.Value;
            vendedor.Cep = localRepresentanteForm.txtCep.Text;
            vendedor.Endereco = localRepresentanteForm.txtEndereco.Text;
            vendedor.Complemento = localRepresentanteForm.txtComplemento.Text;
            vendedor.Bairro = localRepresentanteForm.txtBairro.Text;
            vendedor.UF = localRepresentanteForm.cbbUF.Text;
            vendedor.Cidade = localRepresentanteForm.cbbCidade.Text;
            vendedor.Telefone = localRepresentanteForm.txtTelefone.Text;
            vendedor.TelefoneComercial = localRepresentanteForm.txtTelefoneComercial.Text;
            vendedor.Celular = localRepresentanteForm.txtCelular.Text;
            vendedor.Email = localRepresentanteForm.txtEmail.Text;
            vendedor.LimitePedido = localRepresentanteForm.txtLimitePedido.Text != "" ? Convert.ToDecimal(localRepresentanteForm.txtLimitePedido.Text) : 0;
            vendedor.LimiteCredito = localRepresentanteForm.txtLimiteCredito.Text != "" ? Convert.ToDecimal(localRepresentanteForm.txtLimiteCredito.Text) : 0;
            vendedor.Observacao = localRepresentanteForm.txtObservacao.Text;


            ModelLibrary.MetodosRepresentante.SalvarVendedor(cVendedorModo, vendedor, cVendedorId);

            Cursor.Current = Cursors.Default;

            localRepresentanteForm.btnVendedorSalvar.Text = "Salvar";
            localRepresentanteForm.btnVendedorSalvar.Enabled = true;

            if (cVendedorModo == "Create")
            {
                MessageBox.Show("Vendedor Incluído com Sucesso");
                cVendedorModo = "Edit";
                CarregarFormulario();

            }
            else
            {
                MessageBox.Show("Vendedor Alterado com Sucesso");
            }

        }

        public void VendedorExcluir()
        {

        }



        //////////////////////////////////////////////////////
        ///VENDEDOR BASE
        //////////////////////////////////////////////////////


        public void VendedorBaseExibir(long pVendedorId)
        {
            var vendedor = ModelLibrary.MetodosRepresentante.ObterVendedorBase(pVendedorId);


            if (vendedor != null)
            {

                cVendedorId = vendedor.Id;
                localRepresentanteForm.tbcVendedor.Visible = true;
                localRepresentanteForm.cbbTipoPessoa.Text = vendedor.TipoPessoa == "PF" ? "Pessoa Física" : "Pessoa Jurídica";
                localRepresentanteForm.txtCPFCnpj.Text = vendedor.CpfCnpj.Trim();
                localRepresentanteForm.txtDataInicial.Text = vendedor.DataInicial.ToString();
                localRepresentanteForm.txtDataFinal.Text = vendedor.DataFinal.ToString();

                switch (vendedor.Status)
                {
                    case "2":
                        localRepresentanteForm.cbbStatus.Text = "Negativado";
                        break;
                    case "0":
                        localRepresentanteForm.cbbStatus.Text = "Inativo";
                        break;
                    default:
                        localRepresentanteForm.cbbStatus.Text = "Ativo";
                        break;
                }
                //cbbStatus --- Ver quais os status apresentados
                localRepresentanteForm.txtNome.Text = vendedor.Nome.Trim();
                localRepresentanteForm.txtRazaoSocial.Text = vendedor.RazaoSocial.Trim();
                localRepresentanteForm.txtRGInscricao.Text = vendedor.RGInscricao.Trim();
                localRepresentanteForm.cbbDataNasc.Text = vendedor.DataNascimento.ToString();
                localRepresentanteForm.txtCep.Text = vendedor.Cep.Trim();
                localRepresentanteForm.txtEndereco.Text = vendedor.Endereco.Trim();
                localRepresentanteForm.txtComplemento.Text = vendedor.Complemento.Trim();
                localRepresentanteForm.txtBairro.Text = vendedor.Bairro.Trim();
                localRepresentanteForm.cbbUF.Text = vendedor.UF.Trim();
                localRepresentanteForm.cbbCidade.Text = vendedor.Cidade.Trim();
                localRepresentanteForm.txtTelefone.Text = vendedor.Telefone.Trim();
                localRepresentanteForm.txtTelefoneComercial.Text = vendedor.TelefoneComercial.Trim();
                localRepresentanteForm.txtCelular.Text = vendedor.Celular.Trim();
                localRepresentanteForm.txtEmail.Text = vendedor.Email.Trim();
                localRepresentanteForm.txtLimitePedido.Text = vendedor.LimitePedido.ToString();
                localRepresentanteForm.txtLimiteCredito.Text = vendedor.LimiteCredito.ToString();
                localRepresentanteForm.txtObservacao.Text = vendedor.Observacao.Trim();

                cVendedorModo = "Create";

            }
            else
            {
                MessageBox.Show("Vendedor não encontrado.");
            }



        }


       
        //////////////////////////////////////////////////////
        ///PEDIDO
        //////////////////////////////////////////////////////


        // PedidoLimpar

        public void PedidoLimpar()
        {
            localRepresentanteForm.txtPedidoCodigoBarras.Text = "";
            localRepresentanteForm.txtPedidoProduto.Text = "";
            localRepresentanteForm.txtPedidoQuantidade.Text = "";
            localRepresentanteForm.txtPedidoPrecoUnit.Text = "";
            localRepresentanteForm.txtPedidoProdutoGradeId.Text = "";


            localRepresentanteForm.btnPedidoConfirmar.Enabled = false;
            localRepresentanteForm.btnPedidoCancelar.Enabled = false;
            localRepresentanteForm.txtPedidoCodigoBarras.ReadOnly = false;

            cVendedorPedidoModo = "Insert";



        }


        // PedidoPesquisar

        public void PedidoPesquisar(string pCodigo)
        {


            var produtograde = ModelLibrary.MetodosRepresentante.ObterProdutoGrade(pCodigo);

            if (produtograde != null)
            {

                var produto = ModelLibrary.MetodosRepresentante.ObterProduto(produtograde.CodigoBarras);

                localRepresentanteForm.txtPedidoProduto.Text = produto.Descricao;
                localRepresentanteForm.txtPedidoPrecoUnit.Text = produtograde.ValorSaida.ToString();
                localRepresentanteForm.txtPedidoProdutoGradeId.Text = produtograde.Id.ToString();

                if (localRepresentanteForm.txtPedidoCodigoBarras.Text != produtograde.CodigoBarras + produtograde.Digito)
                {
                    localRepresentanteForm.txtPedidoCodigoBarras.Text = produtograde.CodigoBarras + produtograde.Digito;
                    if (localRepresentanteForm.chkPedidoQuantidade.Checked == false)
                    {
                        localRepresentanteForm.chkPedidoQuantidade.Checked = true;
                        localRepresentanteForm.txtPedidoQuantidade.Enabled = true;
                    }
                }



                //cImportarProdutoId = produtograde.Id;

                localRepresentanteForm.btnPedidoConfirmar.Enabled = true;
                localRepresentanteForm.btnPedidoCancelar.Enabled = true;

                if (localRepresentanteForm.chkPedidoQuantidade.Checked)
                {
                    localRepresentanteForm.txtPedidoQuantidade.Focus();

                }
                else
                {
                    //inserir direto qtd=1
                    PedidoAdicionar();
                }

            }
            else
            {

                MessageBox.Show("Dígito verificador inválido. Não foi possível encontrar a grade deste produto.");

                //cImportarProdutoId = 0;
                localRepresentanteForm.txtPedidoCodigoBarras.Focus();
                localRepresentanteForm.btnPedidoConfirmar.Enabled = false;
                localRepresentanteForm.btnPedidoCancelar.Enabled = false;


            }
        }


        public void ExibirPedido(long pVendedorId)
        {

            localRepresentanteForm.grdVendedorPedido.DataSource = ModelLibrary.MetodosRepresentante.ObterVendedorPedidoItem(pVendedorId, localRepresentanteForm.cCargaId);

            var pedido = ModelLibrary.MetodosRepresentante.ObterVendedorPedido(pVendedorId, localRepresentanteForm.cCargaId);
            cPedidoId = pedido != null ? pedido.Id : 0;


            localRepresentanteForm.grdVendedorPedido.Columns[0].Visible = false;
            localRepresentanteForm.grdVendedorPedido.Columns[1].Visible = false;
            localRepresentanteForm.grdVendedorPedido.Columns[2].Visible = false;
            localRepresentanteForm.grdVendedorPedido.Columns[8].Visible = false;
            localRepresentanteForm.grdVendedorPedido.Columns[9].DefaultCellStyle.Format = "c";
            localRepresentanteForm.grdVendedorPedido.Columns[4].Width = 300;




        }

        public void ConfirmarPedido()
        {

            if (cVendedorPedidoModo == "Edit")
            {
                PedidoAtualizar();
            }
            else
            {
                PedidoAdicionar();
            }

        }

        // PedidoAdicionar

        public void PedidoAdicionar()
        {

            try
            {
                decimal vQuantidade;

                if (localRepresentanteForm.chkPedidoQuantidade.Checked)
                {

                    if (localRepresentanteForm.txtPedidoQuantidade.Text != "" && localRepresentanteForm.txtPedidoQuantidade.Text != "0")
                    {
                        vQuantidade = Convert.ToDecimal(localRepresentanteForm.txtPedidoQuantidade.Text);
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

                decimal vPreco = Convert.ToDecimal(localRepresentanteForm.txtPedidoPrecoUnit.Text);
                long vProdutoGradeId = Convert.ToInt64(localRepresentanteForm.txtPedidoProdutoGradeId.Text);

                if (vQuantidade > 0)
                {

                    ModelLibrary.MetodosRepresentante.InserirPedidoItem(localRepresentanteForm.cCargaId, cVendedorId, vProdutoGradeId, vQuantidade, vPreco);
                    ExibirPedido(cVendedorId);
                    PedidoLimpar();
                }


            }
            catch (IOException vE)
            {
                MessageBox.Show("Ocorreu um erro ao Inserir o produto. Verifique os dados digitados e tente novamente. Se o erro persisitr, contate o administrador.");
                Console.WriteLine(vE.Message);
            }

        }

        // PedidoEditar

        public void PedidoEditar()
        {


            //ClearCargaProduto();


            cVendedorPedidoModo = "Edit";
            //cImportarProdutoId = Convert.ToInt32(localDeposito.grdConfProduto.CurrentRow.Cells[8].Value);

            localRepresentanteForm.txtPedidoProdutoGradeId.Text = localRepresentanteForm.grdVendedorPedido.CurrentRow.Cells["ProdutoGradeId"].Value.ToString();
            localRepresentanteForm.txtPedidoCodigoBarras.Text = localRepresentanteForm.grdVendedorPedido.CurrentRow.Cells["CodigoBarras"].Value.ToString();
            localRepresentanteForm.txtPedidoCodigoBarras.ReadOnly = true;
            localRepresentanteForm.txtPedidoProduto.Text = localRepresentanteForm.grdVendedorPedido.CurrentRow.Cells["Descricao"].Value.ToString();


            localRepresentanteForm.txtPedidoQuantidade.Text = localRepresentanteForm.grdVendedorPedido.CurrentRow.Cells["Quantidade"].Value.ToString();
            localRepresentanteForm.txtPedidoQuantidade.Focus();

            localRepresentanteForm.txtPedidoPrecoUnit.Text = string.Format("{0:C}", localRepresentanteForm.grdVendedorPedido.CurrentRow.Cells["Preco"].Value.ToString());

            


            localRepresentanteForm.btnPedidoConfirmar.Enabled = true;
            localRepresentanteForm.btnPedidoCancelar.Enabled = true;

        }


        public void PedidoAtualizar()
        {

            Console.WriteLine("Editando Produtos do Pedido...");

            ModelLibrary.MetodosRepresentante.AtualizarPedidoItem(cPedidoId, Convert.ToInt64(localRepresentanteForm.txtPedidoProdutoGradeId.Text), Convert.ToDecimal(localRepresentanteForm.txtPedidoQuantidade.Text), Convert.ToDecimal(localRepresentanteForm.txtPedidoPrecoUnit.Text));

            ExibirPedido(cVendedorId);

            PedidoLimpar();
        }

        // PedidoExcluir

        public void PedidoExcluir()
        {

            if (MessageBox.Show("Deseja realmente excluir o produto selecionado?", "ATENÇÃO! Exclusão de Produto do Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                PedidoLimpar();
                var vPedidoItemId = Convert.ToInt32(localRepresentanteForm.grdVendedorPedido.CurrentRow.Cells[0].Value);
                var vPedidoId = Convert.ToInt32(localRepresentanteForm.grdVendedorPedido.CurrentRow.Cells[1].Value);
                var vQuantidade = Convert.ToDecimal(localRepresentanteForm.grdVendedorPedido.CurrentRow.Cells[7].Value);
                var vPreco = Convert.ToDecimal(localRepresentanteForm.grdVendedorPedido.CurrentRow.Cells[8].Value);


                ModelLibrary.MetodosRepresentante.ExcluirPedidoItem(vPedidoItemId, vPedidoId, vQuantidade, vPreco);

                ExibirPedido(cVendedorId);
            }

        }

        // PedidoTotalizador
        public void PedidoTotalizador()
        {

            Console.WriteLine("Exibindo Totalizador de Produtos do Pedido...");

        }


        //////////////////////////////////////////////////////
        /// RETORNO DE PRODUTOS
        //////////////////////////////////////////////////////


        // RetornoProdutoLimpar

        public void RetornoProdutoLimpar()
        {
            localRepresentanteForm.txtRetornoCodigoBarras.Text = "";
            localRepresentanteForm.txtRetornoProduto.Text = "";
            localRepresentanteForm.txtRetornoQuantidade.Text = "";


            localRepresentanteForm.btnRetornoConfirmar.Enabled = false;
            localRepresentanteForm.btnRetornoCancelar.Enabled = false;
            localRepresentanteForm.txtRetornoCodigoBarras.ReadOnly = false;

            cVendedorProdRetModo = "Insert";

        }


        // RetornoProdutoPesquisar

        public void RetornoProdutoPesquisar(string pCodigo)
        {




            int rowIndex = -1;

            DataGridViewRow row = localRepresentanteForm.grdVendedorRetorno.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells["CodigoBarras"].Value.ToString().Equals(pCodigo))
                .First();

            rowIndex = row.Index;

            if (rowIndex != -1)
            {

                localRepresentanteForm.txtRetornoCodigoBarras.Text = localRepresentanteForm.grdVendedorRetorno.CurrentRow.Cells["CodigoBarras"].Value.ToString();
                localRepresentanteForm.txtRetornoProdutoGradeId.Text = localRepresentanteForm.grdVendedorRetorno.CurrentRow.Cells["ProdutoGradeId"].Value.ToString();
                localRepresentanteForm.txtRetornoProduto.Text = localRepresentanteForm.grdVendedorRetorno.CurrentRow.Cells["Descricao"].Value.ToString();

                if (localRepresentanteForm.chkRetornoQuantidade.Checked == false)
                {
                    localRepresentanteForm.chkRetornoQuantidade.Checked = true;
                    localRepresentanteForm.chkRetornoQuantidade.Enabled = true;
                }

                localRepresentanteForm.btnRetornoConfirmar.Enabled = true;
                localRepresentanteForm.btnRetornoCancelar.Enabled = true;

                if (localRepresentanteForm.chkRetornoQuantidade.Checked)
                {
                    localRepresentanteForm.txtRetornoQuantidade.Focus();

                }
                else
                {
                    //inserir direto qtd=1
                    ConfirmarRetornoProduto();
                }


                localRepresentanteForm.grdVendedorRetorno.Rows[rowIndex].Selected = true;

            }
            else
            {

                MessageBox.Show("Código inválido. Não foi possível encontrar este produto no pedido.");

                //cImportarProdutoId = 0;
                localRepresentanteForm.txtRetornoCodigoBarras.Focus();
                localRepresentanteForm.btnRetornoConfirmar.Enabled = false;
                localRepresentanteForm.btnRetornoCancelar.Enabled = false;


            }

            
        }


        public void ExibirRetornoProduto(long pVendedorId)
        {

            localRepresentanteForm.grdVendedorRetorno.DataSource = ModelLibrary.MetodosRepresentante.ObterVendedorPedidoItem(pVendedorId, localRepresentanteForm.cCargaId);

            localRepresentanteForm.grdVendedorRetorno.Columns[0].Visible = false;
            localRepresentanteForm.grdVendedorRetorno.Columns[1].Visible = false;
            localRepresentanteForm.grdVendedorRetorno.Columns[2].Visible = false;
            localRepresentanteForm.grdVendedorRetorno.Columns[8].HeaderText = "Qtd. Retorn.";
            localRepresentanteForm.grdVendedorRetorno.Columns[9].DefaultCellStyle.Format = "c";
            localRepresentanteForm.grdVendedorRetorno.Columns[4].Width = 300;


        }

        public void ConfirmarRetornoProduto()
        {

            Console.WriteLine("Atualizando Retorno de Produtos do Pedido...");

            ModelLibrary.MetodosRepresentante.RetornarPedidoItem(cPedidoId, Convert.ToInt64(localRepresentanteForm.txtRetornoProdutoGradeId.Text), Convert.ToDecimal(localRepresentanteForm.txtRetornoQuantidade.Text));

            ExibirRetornoProduto(cVendedorId);

            RetornoProdutoLimpar();

        }


        // RetornoProdutoEditar

        public void RetornoProdutoEditar()
        {


            localRepresentanteForm.txtRetornoProdutoGradeId.Text = localRepresentanteForm.grdVendedorRetorno.CurrentRow.Cells["ProdutoGradeId"].Value.ToString();
            localRepresentanteForm.txtRetornoCodigoBarras.Text = localRepresentanteForm.grdVendedorRetorno.CurrentRow.Cells["CodigoBarras"].Value.ToString();
            localRepresentanteForm.txtRetornoProduto.Text = localRepresentanteForm.grdVendedorRetorno.CurrentRow.Cells["Descricao"].Value.ToString();
            localRepresentanteForm.txtRetornoCodigoBarras.ReadOnly = true;
            

            localRepresentanteForm.txtRetornoQuantidade.Text = localRepresentanteForm.grdVendedorRetorno.CurrentRow.Cells["Retorno"].Value != null ? localRepresentanteForm.grdVendedorRetorno.CurrentRow.Cells["Retorno"].Value.ToString() : "";

            localRepresentanteForm.txtRetornoQuantidade.Focus();


            localRepresentanteForm.btnRetornoConfirmar.Enabled = true;
            localRepresentanteForm.btnRetornoCancelar.Enabled = true;

        }






        // RetornoProdutoTotalizador
        public void RetornoProdutoTotalizador()
        {

            Console.WriteLine("Exibindo Totalizador de Retorno de Produtos do Pedido...");

        }



        //////////////////////////////////////////////////////
        /// ACERTO
        //////////////////////////////////////////////////////
        

        public void ExibirAcerto()
        {

            // carregar valores do pedido-retorno e calcular

            var pedido = ModelLibrary.MetodosRepresentante.ObterVendedorPedido(cVendedorId, localRepresentanteForm.cCargaId);

            if (pedido != null)
            {
                localRepresentanteForm.dlbValorPedido.Text = string.Format("{0:C2}", pedido.ValorPedido);
                localRepresentanteForm.dlbValorCompra.Text = string.Format("{0:C2}", pedido.ValorCompra);
                localRepresentanteForm.dlbPercentualCompra.Text = string.Format("{0}%", pedido.PercentualCompra);
                localRepresentanteForm.dlbFaixaComissao.Text = string.Format("{0}", pedido.FaixaComissao);
                localRepresentanteForm.dlbPercentualComissao.Text = string.Format("{0}%", pedido.PercentualFaixa);
                localRepresentanteForm.dlbValorComissao.Text = string.Format("{0:C2}", pedido.ValorComissao);
                localRepresentanteForm.dlbValorLiquido.Text = string.Format("{0:C2}", pedido.ValorLiquido);
                localRepresentanteForm.dlbRecebimentoAnterior.Text = string.Format("{0:C2}", pedido.RecebidoAnterior);

                localRepresentanteForm.dlbTotalAPagar.Text = string.Format("{0:C2}", pedido.ValorLiquido + pedido.RecebidoAnterior);

                cValorTotalAPagar = Convert.ToDecimal(pedido.ValorLiquido + pedido.RecebidoAnterior);
                cValorRecebido = Convert.ToDecimal(pedido.ValorAcerto);


                localRepresentanteForm.dlbAcertoAberto.Text = string.Format("{0:C2}", cValorTotalAPagar - cValorRecebido);


                localRepresentanteForm.txtValorRecebido.Text = string.Format("{0}", pedido.ValorAcerto);
            }








        }


        public void ExibirRecebimentos()
        {
            //carregar grid de recebimentos

            
            localRepresentanteForm.grdFinanceiroRecebimentos.DataSource = ModelLibrary.MetodosRepresentante.ObterListaRecebimentos(cVendedorId, localRepresentanteForm.cCargaId);

            localRepresentanteForm.grdFinanceiroRecebimentos.Columns[0].Visible = false;
            localRepresentanteForm.grdFinanceiroRecebimentos.Columns[1].Visible = false;


        }


        public void ReceberAcerto()
        {
            //exibir form de recebimento

            if (localRepresentanteForm.txtValorRecebido.Text != "")
            {
                ModelLibrary.MetodosRepresentante.ReceberAcerto(cPedidoId, Convert.ToDecimal(localRepresentanteForm.txtValorRecebido.Text));
            } else
            {
                MessageBox.Show("Informe o valor recebido!");
            }
                



        }

        public void CalcularValorEmAberto()
        {

            cValorRecebido = localRepresentanteForm.txtValorRecebido.Text == "" ? 0 : Convert.ToDecimal(localRepresentanteForm.txtValorRecebido.Text);           
            localRepresentanteForm.dlbAcertoAberto.Text = string.Format("{0:C2}", (cValorTotalAPagar - cValorRecebido));
            
        }

        public void DuplicataLimpar()
        {

            cDuplicataId = 0;
            cDuplicataReceberId = 0;
            localRepresentanteForm.dlbDuplicataTotal.Text = "";
            localRepresentanteForm.grpReceberTitulo.Visible = false;

        }

        public void ExibirDuplicata()
        {

            localRepresentanteForm.grpReceberTitulo.Visible = true;
            cDuplicataId = localRepresentanteForm.grdFinanceiroRecebimentos.CurrentRow.Cells["Id"].Value == null ? 0 : Convert.ToInt64(localRepresentanteForm.grdFinanceiroRecebimentos.CurrentRow.Cells["Id"].Value);
            cDuplicataReceberId = Convert.ToInt64(localRepresentanteForm.grdFinanceiroRecebimentos.CurrentRow.Cells["ReceberId"].Value);
            localRepresentanteForm.txtDuplicataReceber.Text = localRepresentanteForm.grdFinanceiroRecebimentos.CurrentRow.Cells["ValorRecebido"].Value != null ? localRepresentanteForm.grdFinanceiroRecebimentos.CurrentRow.Cells["ValorRecebido"].Value.ToString() : "0";
            localRepresentanteForm.dlbDuplicataTotal.Text = localRepresentanteForm.grdFinanceiroRecebimentos.CurrentRow.Cells["ValorDuplicata"].Value.ToString();
            localRepresentanteForm.txtDuplicataReceber.Focus();


        }

        public void ReceberDuplicata()
        {

            if (localRepresentanteForm.txtDuplicataReceber.Text != "")
            {
                ModelLibrary.MetodosRepresentante.ReceberDuplicata(cDuplicataId, cDuplicataReceberId, localRepresentanteForm.cCargaId, Convert.ToDecimal(localRepresentanteForm.txtDuplicataReceber.Text));
                ExibirRecebimentos();
                DuplicataLimpar();
            } else
            {
                MessageBox.Show("Informe o valor recebido da duplicata!");
            }

            

        }









    }
}
