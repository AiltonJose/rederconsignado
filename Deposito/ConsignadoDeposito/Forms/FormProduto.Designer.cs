﻿namespace ConsignadoDeposito.Forms
{
    partial class FormProduto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlProduto = new MetroFramework.Controls.MetroPanel();
            this.grpAdicionarGrade = new System.Windows.Forms.GroupBox();
            this.txtValorCusto = new MetroFramework.Controls.MetroTextBox();
            this.txtGradeDV = new MetroFramework.Controls.MetroTextBox();
            this.txtValorSaida = new MetroFramework.Controls.MetroTextBox();
            this.cbbGradeTamanho = new MetroFramework.Controls.MetroComboBox();
            this.cbbGradeCor = new MetroFramework.Controls.MetroComboBox();
            this.btnGradeCancelar = new MetroFramework.Controls.MetroButton();
            this.btnGradeConfirmar = new MetroFramework.Controls.MetroButton();
            this.lblAdicionarGrade = new MetroFramework.Controls.MetroLabel();
            this.txtGradeCodigoBarras = new MetroFramework.Controls.MetroTextBox();
            this.grpProduto = new System.Windows.Forms.GroupBox();
            this.grpPesquisa = new System.Windows.Forms.GroupBox();
            this.txtPesquisaCodProduto = new MetroFramework.Controls.MetroTextBox();
            this.cbbPesquisaProduto = new MetroFramework.Controls.MetroComboBox();
            this.btnPesquisaOK = new MetroFramework.Controls.MetroButton();
            this.btnNovoProduto = new MetroFramework.Controls.MetroButton();
            this.pnlProdutoItem = new MetroFramework.Controls.MetroPanel();
            this.pblProdutoBottom = new MetroFramework.Controls.MetroPanel();
            this.pnlProdutoGrade = new MetroFramework.Controls.MetroPanel();
            this.txtNomeProduto = new MetroFramework.Controls.MetroTextBox();
            this.lblNomeProduto = new MetroFramework.Controls.MetroLabel();
            this.txtUnidade = new MetroFramework.Controls.MetroTextBox();
            this.lblUnidade = new MetroFramework.Controls.MetroLabel();
            this.txtDigitoVerificador = new MetroFramework.Controls.MetroTextBox();
            this.txtCodigoBarras = new MetroFramework.Controls.MetroTextBox();
            this.lblCodigoBarras = new MetroFramework.Controls.MetroLabel();
            this.lblDigitoVerificador = new MetroFramework.Controls.MetroLabel();
            this.cbbCategoria = new MetroFramework.Controls.MetroComboBox();
            this.lblCategoria = new MetroFramework.Controls.MetroLabel();
            this.lblFornecedor = new MetroFramework.Controls.MetroLabel();
            this.cbbFornecedor = new MetroFramework.Controls.MetroComboBox();
            this.btnSalvarProduto = new MetroFramework.Controls.MetroButton();
            this.btnExcluirProduto = new MetroFramework.Controls.MetroButton();
            this.btnCancelarProduto = new MetroFramework.Controls.MetroButton();
            this.pnlProduto.SuspendLayout();
            this.grpAdicionarGrade.SuspendLayout();
            this.grpProduto.SuspendLayout();
            this.grpPesquisa.SuspendLayout();
            this.pnlProdutoItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlProduto
            // 
            this.pnlProduto.Controls.Add(this.grpProduto);
            this.pnlProduto.Controls.Add(this.grpPesquisa);
            this.pnlProduto.Controls.Add(this.btnNovoProduto);
            this.pnlProduto.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProduto.HorizontalScrollbarBarColor = true;
            this.pnlProduto.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlProduto.HorizontalScrollbarSize = 10;
            this.pnlProduto.Location = new System.Drawing.Point(20, 60);
            this.pnlProduto.Name = "pnlProduto";
            this.pnlProduto.Size = new System.Drawing.Size(679, 232);
            this.pnlProduto.TabIndex = 0;
            this.pnlProduto.VerticalScrollbarBarColor = true;
            this.pnlProduto.VerticalScrollbarHighlightOnWheel = false;
            this.pnlProduto.VerticalScrollbarSize = 10;
            // 
            // grpAdicionarGrade
            // 
            this.grpAdicionarGrade.Controls.Add(this.txtValorCusto);
            this.grpAdicionarGrade.Controls.Add(this.txtGradeDV);
            this.grpAdicionarGrade.Controls.Add(this.txtValorSaida);
            this.grpAdicionarGrade.Controls.Add(this.cbbGradeTamanho);
            this.grpAdicionarGrade.Controls.Add(this.cbbGradeCor);
            this.grpAdicionarGrade.Controls.Add(this.btnGradeCancelar);
            this.grpAdicionarGrade.Controls.Add(this.btnGradeConfirmar);
            this.grpAdicionarGrade.Controls.Add(this.lblAdicionarGrade);
            this.grpAdicionarGrade.Controls.Add(this.txtGradeCodigoBarras);
            this.grpAdicionarGrade.Location = new System.Drawing.Point(6, 6);
            this.grpAdicionarGrade.Name = "grpAdicionarGrade";
            this.grpAdicionarGrade.Size = new System.Drawing.Size(666, 75);
            this.grpAdicionarGrade.TabIndex = 17;
            this.grpAdicionarGrade.TabStop = false;
            // 
            // txtValorCusto
            // 
            // 
            // 
            // 
            this.txtValorCusto.CustomButton.Image = null;
            this.txtValorCusto.CustomButton.Location = new System.Drawing.Point(58, 1);
            this.txtValorCusto.CustomButton.Name = "";
            this.txtValorCusto.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtValorCusto.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtValorCusto.CustomButton.TabIndex = 1;
            this.txtValorCusto.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtValorCusto.CustomButton.UseSelectable = true;
            this.txtValorCusto.CustomButton.Visible = false;
            this.txtValorCusto.Lines = new string[0];
            this.txtValorCusto.Location = new System.Drawing.Point(423, 38);
            this.txtValorCusto.MaxLength = 32767;
            this.txtValorCusto.Name = "txtValorCusto";
            this.txtValorCusto.PasswordChar = '\0';
            this.txtValorCusto.PromptText = "Valor Custo";
            this.txtValorCusto.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtValorCusto.SelectedText = "";
            this.txtValorCusto.SelectionLength = 0;
            this.txtValorCusto.SelectionStart = 0;
            this.txtValorCusto.ShortcutsEnabled = true;
            this.txtValorCusto.Size = new System.Drawing.Size(80, 23);
            this.txtValorCusto.TabIndex = 20;
            this.txtValorCusto.UseSelectable = true;
            this.txtValorCusto.WaterMark = "Valor Custo";
            this.txtValorCusto.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtValorCusto.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtGradeDV
            // 
            // 
            // 
            // 
            this.txtGradeDV.CustomButton.Image = null;
            this.txtGradeDV.CustomButton.Location = new System.Drawing.Point(8, 1);
            this.txtGradeDV.CustomButton.Name = "";
            this.txtGradeDV.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtGradeDV.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtGradeDV.CustomButton.TabIndex = 1;
            this.txtGradeDV.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtGradeDV.CustomButton.UseSelectable = true;
            this.txtGradeDV.CustomButton.Visible = false;
            this.txtGradeDV.Lines = new string[0];
            this.txtGradeDV.Location = new System.Drawing.Point(133, 38);
            this.txtGradeDV.MaxLength = 32767;
            this.txtGradeDV.Name = "txtGradeDV";
            this.txtGradeDV.PasswordChar = '\0';
            this.txtGradeDV.PromptText = "DV";
            this.txtGradeDV.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtGradeDV.SelectedText = "";
            this.txtGradeDV.SelectionLength = 0;
            this.txtGradeDV.SelectionStart = 0;
            this.txtGradeDV.ShortcutsEnabled = true;
            this.txtGradeDV.Size = new System.Drawing.Size(30, 23);
            this.txtGradeDV.TabIndex = 19;
            this.txtGradeDV.UseSelectable = true;
            this.txtGradeDV.WaterMark = "DV";
            this.txtGradeDV.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtGradeDV.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtValorSaida
            // 
            // 
            // 
            // 
            this.txtValorSaida.CustomButton.Image = null;
            this.txtValorSaida.CustomButton.Location = new System.Drawing.Point(58, 1);
            this.txtValorSaida.CustomButton.Name = "";
            this.txtValorSaida.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtValorSaida.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtValorSaida.CustomButton.TabIndex = 1;
            this.txtValorSaida.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtValorSaida.CustomButton.UseSelectable = true;
            this.txtValorSaida.CustomButton.Visible = false;
            this.txtValorSaida.Lines = new string[0];
            this.txtValorSaida.Location = new System.Drawing.Point(337, 38);
            this.txtValorSaida.MaxLength = 32767;
            this.txtValorSaida.Name = "txtValorSaida";
            this.txtValorSaida.PasswordChar = '\0';
            this.txtValorSaida.PromptText = "Valor Saída";
            this.txtValorSaida.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtValorSaida.SelectedText = "";
            this.txtValorSaida.SelectionLength = 0;
            this.txtValorSaida.SelectionStart = 0;
            this.txtValorSaida.ShortcutsEnabled = true;
            this.txtValorSaida.Size = new System.Drawing.Size(80, 23);
            this.txtValorSaida.TabIndex = 18;
            this.txtValorSaida.UseSelectable = true;
            this.txtValorSaida.WaterMark = "Valor Saída";
            this.txtValorSaida.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtValorSaida.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // cbbGradeTamanho
            // 
            this.cbbGradeTamanho.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cbbGradeTamanho.FormattingEnabled = true;
            this.cbbGradeTamanho.ItemHeight = 19;
            this.cbbGradeTamanho.Location = new System.Drawing.Point(252, 37);
            this.cbbGradeTamanho.Name = "cbbGradeTamanho";
            this.cbbGradeTamanho.PromptText = "Tam";
            this.cbbGradeTamanho.Size = new System.Drawing.Size(79, 25);
            this.cbbGradeTamanho.Sorted = true;
            this.cbbGradeTamanho.TabIndex = 17;
            this.cbbGradeTamanho.UseSelectable = true;
            // 
            // cbbGradeCor
            // 
            this.cbbGradeCor.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cbbGradeCor.FormattingEnabled = true;
            this.cbbGradeCor.ItemHeight = 19;
            this.cbbGradeCor.Location = new System.Drawing.Point(167, 37);
            this.cbbGradeCor.Name = "cbbGradeCor";
            this.cbbGradeCor.PromptText = "Cor";
            this.cbbGradeCor.Size = new System.Drawing.Size(79, 25);
            this.cbbGradeCor.Sorted = true;
            this.cbbGradeCor.TabIndex = 16;
            this.cbbGradeCor.UseSelectable = true;
            // 
            // btnGradeCancelar
            // 
            this.btnGradeCancelar.Enabled = false;
            this.btnGradeCancelar.Location = new System.Drawing.Point(581, 38);
            this.btnGradeCancelar.Name = "btnGradeCancelar";
            this.btnGradeCancelar.Size = new System.Drawing.Size(67, 23);
            this.btnGradeCancelar.TabIndex = 15;
            this.btnGradeCancelar.Text = "Cancelar";
            this.btnGradeCancelar.UseSelectable = true;
            // 
            // btnGradeConfirmar
            // 
            this.btnGradeConfirmar.Enabled = false;
            this.btnGradeConfirmar.Location = new System.Drawing.Point(509, 38);
            this.btnGradeConfirmar.Name = "btnGradeConfirmar";
            this.btnGradeConfirmar.Size = new System.Drawing.Size(66, 23);
            this.btnGradeConfirmar.TabIndex = 14;
            this.btnGradeConfirmar.Text = "Confirmar";
            this.btnGradeConfirmar.UseSelectable = true;
            // 
            // lblAdicionarGrade
            // 
            this.lblAdicionarGrade.AutoSize = true;
            this.lblAdicionarGrade.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblAdicionarGrade.Location = new System.Drawing.Point(8, 16);
            this.lblAdicionarGrade.Name = "lblAdicionarGrade";
            this.lblAdicionarGrade.Size = new System.Drawing.Size(119, 19);
            this.lblAdicionarGrade.TabIndex = 13;
            this.lblAdicionarGrade.Text = "Adicionar Grade";
            // 
            // txtGradeCodigoBarras
            // 
            // 
            // 
            // 
            this.txtGradeCodigoBarras.CustomButton.Image = null;
            this.txtGradeCodigoBarras.CustomButton.Location = new System.Drawing.Point(97, 1);
            this.txtGradeCodigoBarras.CustomButton.Name = "";
            this.txtGradeCodigoBarras.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtGradeCodigoBarras.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtGradeCodigoBarras.CustomButton.TabIndex = 1;
            this.txtGradeCodigoBarras.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtGradeCodigoBarras.CustomButton.UseSelectable = true;
            this.txtGradeCodigoBarras.CustomButton.Visible = false;
            this.txtGradeCodigoBarras.Lines = new string[0];
            this.txtGradeCodigoBarras.Location = new System.Drawing.Point(8, 38);
            this.txtGradeCodigoBarras.MaxLength = 32767;
            this.txtGradeCodigoBarras.Name = "txtGradeCodigoBarras";
            this.txtGradeCodigoBarras.PasswordChar = '\0';
            this.txtGradeCodigoBarras.PromptText = "Código de Barras";
            this.txtGradeCodigoBarras.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtGradeCodigoBarras.SelectedText = "";
            this.txtGradeCodigoBarras.SelectionLength = 0;
            this.txtGradeCodigoBarras.SelectionStart = 0;
            this.txtGradeCodigoBarras.ShortcutsEnabled = true;
            this.txtGradeCodigoBarras.Size = new System.Drawing.Size(119, 23);
            this.txtGradeCodigoBarras.TabIndex = 12;
            this.txtGradeCodigoBarras.UseSelectable = true;
            this.txtGradeCodigoBarras.WaterMark = "Código de Barras";
            this.txtGradeCodigoBarras.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtGradeCodigoBarras.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // grpProduto
            // 
            this.grpProduto.Controls.Add(this.btnCancelarProduto);
            this.grpProduto.Controls.Add(this.btnExcluirProduto);
            this.grpProduto.Controls.Add(this.btnSalvarProduto);
            this.grpProduto.Controls.Add(this.lblFornecedor);
            this.grpProduto.Controls.Add(this.cbbFornecedor);
            this.grpProduto.Controls.Add(this.lblCategoria);
            this.grpProduto.Controls.Add(this.cbbCategoria);
            this.grpProduto.Controls.Add(this.lblDigitoVerificador);
            this.grpProduto.Controls.Add(this.lblCodigoBarras);
            this.grpProduto.Controls.Add(this.txtDigitoVerificador);
            this.grpProduto.Controls.Add(this.txtCodigoBarras);
            this.grpProduto.Controls.Add(this.lblUnidade);
            this.grpProduto.Controls.Add(this.txtUnidade);
            this.grpProduto.Controls.Add(this.txtNomeProduto);
            this.grpProduto.Controls.Add(this.lblNomeProduto);
            this.grpProduto.Location = new System.Drawing.Point(6, 74);
            this.grpProduto.Name = "grpProduto";
            this.grpProduto.Size = new System.Drawing.Size(666, 152);
            this.grpProduto.TabIndex = 16;
            this.grpProduto.TabStop = false;
            this.grpProduto.Text = "Dados do Produto";
            // 
            // grpPesquisa
            // 
            this.grpPesquisa.Controls.Add(this.txtPesquisaCodProduto);
            this.grpPesquisa.Controls.Add(this.cbbPesquisaProduto);
            this.grpPesquisa.Controls.Add(this.btnPesquisaOK);
            this.grpPesquisa.Location = new System.Drawing.Point(6, 8);
            this.grpPesquisa.Name = "grpPesquisa";
            this.grpPesquisa.Size = new System.Drawing.Size(554, 60);
            this.grpPesquisa.TabIndex = 14;
            this.grpPesquisa.TabStop = false;
            this.grpPesquisa.Text = "Pesquisa";
            // 
            // txtPesquisaCodProduto
            // 
            // 
            // 
            // 
            this.txtPesquisaCodProduto.CustomButton.Image = global::ConsignadoDeposito.Properties.Resources.darkmagnify1;
            this.txtPesquisaCodProduto.CustomButton.Location = new System.Drawing.Point(91, 1);
            this.txtPesquisaCodProduto.CustomButton.Name = "";
            this.txtPesquisaCodProduto.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtPesquisaCodProduto.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPesquisaCodProduto.CustomButton.TabIndex = 1;
            this.txtPesquisaCodProduto.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPesquisaCodProduto.CustomButton.UseSelectable = true;
            this.txtPesquisaCodProduto.DisplayIcon = true;
            this.txtPesquisaCodProduto.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPesquisaCodProduto.IconRight = true;
            this.txtPesquisaCodProduto.Lines = new string[0];
            this.txtPesquisaCodProduto.Location = new System.Drawing.Point(8, 19);
            this.txtPesquisaCodProduto.Margin = new System.Windows.Forms.Padding(5);
            this.txtPesquisaCodProduto.MaxLength = 32767;
            this.txtPesquisaCodProduto.Name = "txtPesquisaCodProduto";
            this.txtPesquisaCodProduto.PasswordChar = '\0';
            this.txtPesquisaCodProduto.PromptText = "Código de Barras";
            this.txtPesquisaCodProduto.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPesquisaCodProduto.SelectedText = "";
            this.txtPesquisaCodProduto.SelectionLength = 0;
            this.txtPesquisaCodProduto.SelectionStart = 0;
            this.txtPesquisaCodProduto.ShortcutsEnabled = true;
            this.txtPesquisaCodProduto.ShowButton = true;
            this.txtPesquisaCodProduto.Size = new System.Drawing.Size(119, 29);
            this.txtPesquisaCodProduto.TabIndex = 11;
            this.txtPesquisaCodProduto.UseSelectable = true;
            this.txtPesquisaCodProduto.WaterMark = "Código de Barras";
            this.txtPesquisaCodProduto.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPesquisaCodProduto.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // cbbPesquisaProduto
            // 
            this.cbbPesquisaProduto.FormattingEnabled = true;
            this.cbbPesquisaProduto.ItemHeight = 23;
            this.cbbPesquisaProduto.Location = new System.Drawing.Point(135, 19);
            this.cbbPesquisaProduto.Name = "cbbPesquisaProduto";
            this.cbbPesquisaProduto.PromptText = "Selecione o Produto";
            this.cbbPesquisaProduto.Size = new System.Drawing.Size(324, 29);
            this.cbbPesquisaProduto.Sorted = true;
            this.cbbPesquisaProduto.TabIndex = 12;
            this.cbbPesquisaProduto.UseSelectable = true;
            // 
            // btnPesquisaOK
            // 
            this.btnPesquisaOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisaOK.Location = new System.Drawing.Point(475, 19);
            this.btnPesquisaOK.Name = "btnPesquisaOK";
            this.btnPesquisaOK.Size = new System.Drawing.Size(52, 29);
            this.btnPesquisaOK.TabIndex = 10;
            this.btnPesquisaOK.Text = "OK";
            this.btnPesquisaOK.UseSelectable = true;
            // 
            // btnNovoProduto
            // 
            this.btnNovoProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNovoProduto.Location = new System.Drawing.Point(570, 16);
            this.btnNovoProduto.Name = "btnNovoProduto";
            this.btnNovoProduto.Size = new System.Drawing.Size(100, 52);
            this.btnNovoProduto.TabIndex = 15;
            this.btnNovoProduto.Text = "Adicionar\r\nNovo";
            this.btnNovoProduto.UseSelectable = true;
            // 
            // pnlProdutoItem
            // 
            this.pnlProdutoItem.Controls.Add(this.grpAdicionarGrade);
            this.pnlProdutoItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProdutoItem.HorizontalScrollbarBarColor = true;
            this.pnlProdutoItem.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlProdutoItem.HorizontalScrollbarSize = 10;
            this.pnlProdutoItem.Location = new System.Drawing.Point(20, 292);
            this.pnlProdutoItem.Name = "pnlProdutoItem";
            this.pnlProdutoItem.Size = new System.Drawing.Size(679, 94);
            this.pnlProdutoItem.TabIndex = 1;
            this.pnlProdutoItem.VerticalScrollbarBarColor = true;
            this.pnlProdutoItem.VerticalScrollbarHighlightOnWheel = false;
            this.pnlProdutoItem.VerticalScrollbarSize = 10;
            // 
            // pblProdutoBottom
            // 
            this.pblProdutoBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pblProdutoBottom.HorizontalScrollbarBarColor = true;
            this.pblProdutoBottom.HorizontalScrollbarHighlightOnWheel = false;
            this.pblProdutoBottom.HorizontalScrollbarSize = 10;
            this.pblProdutoBottom.Location = new System.Drawing.Point(20, 640);
            this.pblProdutoBottom.Name = "pblProdutoBottom";
            this.pblProdutoBottom.Size = new System.Drawing.Size(679, 43);
            this.pblProdutoBottom.TabIndex = 2;
            this.pblProdutoBottom.VerticalScrollbarBarColor = true;
            this.pblProdutoBottom.VerticalScrollbarHighlightOnWheel = false;
            this.pblProdutoBottom.VerticalScrollbarSize = 10;
            // 
            // pnlProdutoGrade
            // 
            this.pnlProdutoGrade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProdutoGrade.HorizontalScrollbarBarColor = true;
            this.pnlProdutoGrade.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlProdutoGrade.HorizontalScrollbarSize = 10;
            this.pnlProdutoGrade.Location = new System.Drawing.Point(20, 386);
            this.pnlProdutoGrade.Name = "pnlProdutoGrade";
            this.pnlProdutoGrade.Size = new System.Drawing.Size(679, 254);
            this.pnlProdutoGrade.TabIndex = 3;
            this.pnlProdutoGrade.VerticalScrollbarBarColor = true;
            this.pnlProdutoGrade.VerticalScrollbarHighlightOnWheel = false;
            this.pnlProdutoGrade.VerticalScrollbarSize = 10;
            // 
            // txtNomeProduto
            // 
            // 
            // 
            // 
            this.txtNomeProduto.CustomButton.Image = null;
            this.txtNomeProduto.CustomButton.Location = new System.Drawing.Point(407, 1);
            this.txtNomeProduto.CustomButton.Name = "";
            this.txtNomeProduto.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtNomeProduto.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNomeProduto.CustomButton.TabIndex = 1;
            this.txtNomeProduto.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNomeProduto.CustomButton.UseSelectable = true;
            this.txtNomeProduto.CustomButton.Visible = false;
            this.txtNomeProduto.Lines = new string[0];
            this.txtNomeProduto.Location = new System.Drawing.Point(8, 39);
            this.txtNomeProduto.MaxLength = 32767;
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.PasswordChar = '\0';
            this.txtNomeProduto.PromptText = "Nome";
            this.txtNomeProduto.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNomeProduto.SelectedText = "";
            this.txtNomeProduto.SelectionLength = 0;
            this.txtNomeProduto.SelectionStart = 0;
            this.txtNomeProduto.ShortcutsEnabled = true;
            this.txtNomeProduto.Size = new System.Drawing.Size(429, 23);
            this.txtNomeProduto.TabIndex = 13;
            this.txtNomeProduto.UseSelectable = true;
            this.txtNomeProduto.WaterMark = "Nome";
            this.txtNomeProduto.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNomeProduto.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblNomeProduto
            // 
            this.lblNomeProduto.AutoSize = true;
            this.lblNomeProduto.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblNomeProduto.Location = new System.Drawing.Point(6, 21);
            this.lblNomeProduto.Name = "lblNomeProduto";
            this.lblNomeProduto.Size = new System.Drawing.Size(101, 15);
            this.lblNomeProduto.TabIndex = 14;
            this.lblNomeProduto.Text = "Nome do Produto";
            // 
            // txtUnidade
            // 
            // 
            // 
            // 
            this.txtUnidade.CustomButton.Image = null;
            this.txtUnidade.CustomButton.Location = new System.Drawing.Point(29, 1);
            this.txtUnidade.CustomButton.Name = "";
            this.txtUnidade.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtUnidade.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUnidade.CustomButton.TabIndex = 1;
            this.txtUnidade.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUnidade.CustomButton.UseSelectable = true;
            this.txtUnidade.CustomButton.Visible = false;
            this.txtUnidade.Lines = new string[0];
            this.txtUnidade.Location = new System.Drawing.Point(443, 39);
            this.txtUnidade.MaxLength = 32767;
            this.txtUnidade.Name = "txtUnidade";
            this.txtUnidade.PasswordChar = '\0';
            this.txtUnidade.PromptText = "Unidade";
            this.txtUnidade.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUnidade.SelectedText = "";
            this.txtUnidade.SelectionLength = 0;
            this.txtUnidade.SelectionStart = 0;
            this.txtUnidade.ShortcutsEnabled = true;
            this.txtUnidade.Size = new System.Drawing.Size(51, 23);
            this.txtUnidade.TabIndex = 15;
            this.txtUnidade.UseSelectable = true;
            this.txtUnidade.WaterMark = "Unidade";
            this.txtUnidade.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUnidade.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblUnidade
            // 
            this.lblUnidade.AutoSize = true;
            this.lblUnidade.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblUnidade.Location = new System.Drawing.Point(443, 21);
            this.lblUnidade.Name = "lblUnidade";
            this.lblUnidade.Size = new System.Drawing.Size(49, 15);
            this.lblUnidade.TabIndex = 16;
            this.lblUnidade.Text = "Unidade";
            // 
            // txtDigitoVerificador
            // 
            // 
            // 
            // 
            this.txtDigitoVerificador.CustomButton.Image = null;
            this.txtDigitoVerificador.CustomButton.Location = new System.Drawing.Point(8, 1);
            this.txtDigitoVerificador.CustomButton.Name = "";
            this.txtDigitoVerificador.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtDigitoVerificador.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDigitoVerificador.CustomButton.TabIndex = 1;
            this.txtDigitoVerificador.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDigitoVerificador.CustomButton.UseSelectable = true;
            this.txtDigitoVerificador.CustomButton.Visible = false;
            this.txtDigitoVerificador.Lines = new string[0];
            this.txtDigitoVerificador.Location = new System.Drawing.Point(625, 39);
            this.txtDigitoVerificador.MaxLength = 32767;
            this.txtDigitoVerificador.Name = "txtDigitoVerificador";
            this.txtDigitoVerificador.PasswordChar = '\0';
            this.txtDigitoVerificador.PromptText = "Dígito";
            this.txtDigitoVerificador.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDigitoVerificador.SelectedText = "";
            this.txtDigitoVerificador.SelectionLength = 0;
            this.txtDigitoVerificador.SelectionStart = 0;
            this.txtDigitoVerificador.ShortcutsEnabled = true;
            this.txtDigitoVerificador.Size = new System.Drawing.Size(30, 23);
            this.txtDigitoVerificador.TabIndex = 21;
            this.txtDigitoVerificador.UseSelectable = true;
            this.txtDigitoVerificador.WaterMark = "Dígito";
            this.txtDigitoVerificador.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDigitoVerificador.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtCodigoBarras
            // 
            // 
            // 
            // 
            this.txtCodigoBarras.CustomButton.Image = null;
            this.txtCodigoBarras.CustomButton.Location = new System.Drawing.Point(97, 1);
            this.txtCodigoBarras.CustomButton.Name = "";
            this.txtCodigoBarras.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCodigoBarras.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCodigoBarras.CustomButton.TabIndex = 1;
            this.txtCodigoBarras.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCodigoBarras.CustomButton.UseSelectable = true;
            this.txtCodigoBarras.CustomButton.Visible = false;
            this.txtCodigoBarras.Lines = new string[0];
            this.txtCodigoBarras.Location = new System.Drawing.Point(500, 39);
            this.txtCodigoBarras.MaxLength = 32767;
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.PasswordChar = '\0';
            this.txtCodigoBarras.PromptText = "Código de Barras";
            this.txtCodigoBarras.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCodigoBarras.SelectedText = "";
            this.txtCodigoBarras.SelectionLength = 0;
            this.txtCodigoBarras.SelectionStart = 0;
            this.txtCodigoBarras.ShortcutsEnabled = true;
            this.txtCodigoBarras.Size = new System.Drawing.Size(119, 23);
            this.txtCodigoBarras.TabIndex = 20;
            this.txtCodigoBarras.UseSelectable = true;
            this.txtCodigoBarras.WaterMark = "Código de Barras";
            this.txtCodigoBarras.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCodigoBarras.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblCodigoBarras
            // 
            this.lblCodigoBarras.AutoSize = true;
            this.lblCodigoBarras.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblCodigoBarras.Location = new System.Drawing.Point(498, 21);
            this.lblCodigoBarras.Name = "lblCodigoBarras";
            this.lblCodigoBarras.Size = new System.Drawing.Size(95, 15);
            this.lblCodigoBarras.TabIndex = 22;
            this.lblCodigoBarras.Text = "Código de Barras";
            // 
            // lblDigitoVerificador
            // 
            this.lblDigitoVerificador.AutoSize = true;
            this.lblDigitoVerificador.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblDigitoVerificador.Location = new System.Drawing.Point(625, 21);
            this.lblDigitoVerificador.Name = "lblDigitoVerificador";
            this.lblDigitoVerificador.Size = new System.Drawing.Size(22, 15);
            this.lblDigitoVerificador.TabIndex = 23;
            this.lblDigitoVerificador.Text = "DV";
            // 
            // cbbCategoria
            // 
            this.cbbCategoria.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cbbCategoria.FormattingEnabled = true;
            this.cbbCategoria.ItemHeight = 19;
            this.cbbCategoria.Location = new System.Drawing.Point(8, 83);
            this.cbbCategoria.Name = "cbbCategoria";
            this.cbbCategoria.PromptText = "Categoria";
            this.cbbCategoria.Size = new System.Drawing.Size(238, 25);
            this.cbbCategoria.Sorted = true;
            this.cbbCategoria.TabIndex = 24;
            this.cbbCategoria.UseSelectable = true;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblCategoria.Location = new System.Drawing.Point(8, 65);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(56, 15);
            this.lblCategoria.TabIndex = 25;
            this.lblCategoria.Text = "Categoria";
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.AutoSize = true;
            this.lblFornecedor.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblFornecedor.Location = new System.Drawing.Point(254, 65);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(65, 15);
            this.lblFornecedor.TabIndex = 27;
            this.lblFornecedor.Text = "Fornecedor";
            // 
            // cbbFornecedor
            // 
            this.cbbFornecedor.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cbbFornecedor.FormattingEnabled = true;
            this.cbbFornecedor.ItemHeight = 19;
            this.cbbFornecedor.Location = new System.Drawing.Point(254, 83);
            this.cbbFornecedor.Name = "cbbFornecedor";
            this.cbbFornecedor.PromptText = "Fornecedor";
            this.cbbFornecedor.Size = new System.Drawing.Size(401, 25);
            this.cbbFornecedor.Sorted = true;
            this.cbbFornecedor.TabIndex = 26;
            this.cbbFornecedor.UseSelectable = true;
            // 
            // btnSalvarProduto
            // 
            this.btnSalvarProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalvarProduto.Location = new System.Drawing.Point(552, 114);
            this.btnSalvarProduto.Name = "btnSalvarProduto";
            this.btnSalvarProduto.Size = new System.Drawing.Size(103, 29);
            this.btnSalvarProduto.TabIndex = 13;
            this.btnSalvarProduto.Text = "Salvar";
            this.btnSalvarProduto.UseSelectable = true;
            // 
            // btnExcluirProduto
            // 
            this.btnExcluirProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExcluirProduto.Location = new System.Drawing.Point(8, 117);
            this.btnExcluirProduto.Name = "btnExcluirProduto";
            this.btnExcluirProduto.Size = new System.Drawing.Size(103, 29);
            this.btnExcluirProduto.TabIndex = 28;
            this.btnExcluirProduto.Text = "Excluir Produto";
            this.btnExcluirProduto.UseSelectable = true;
            // 
            // btnCancelarProduto
            // 
            this.btnCancelarProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelarProduto.Location = new System.Drawing.Point(443, 114);
            this.btnCancelarProduto.Name = "btnCancelarProduto";
            this.btnCancelarProduto.Size = new System.Drawing.Size(103, 29);
            this.btnCancelarProduto.TabIndex = 29;
            this.btnCancelarProduto.Text = "Cancelar";
            this.btnCancelarProduto.UseSelectable = true;
            // 
            // FormProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 703);
            this.Controls.Add(this.pnlProdutoGrade);
            this.Controls.Add(this.pblProdutoBottom);
            this.Controls.Add(this.pnlProdutoItem);
            this.Controls.Add(this.pnlProduto);
            this.MinimumSize = new System.Drawing.Size(719, 703);
            this.Name = "FormProduto";
            this.Text = "Cadastro de Produto";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormProduto_Load);
            this.pnlProduto.ResumeLayout(false);
            this.grpAdicionarGrade.ResumeLayout(false);
            this.grpAdicionarGrade.PerformLayout();
            this.grpProduto.ResumeLayout(false);
            this.grpProduto.PerformLayout();
            this.grpPesquisa.ResumeLayout(false);
            this.pnlProdutoItem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel pnlProduto;
        private System.Windows.Forms.GroupBox grpProduto;
        public MetroFramework.Controls.MetroButton btnCancelarProduto;
        public MetroFramework.Controls.MetroButton btnExcluirProduto;
        public MetroFramework.Controls.MetroButton btnSalvarProduto;
        private MetroFramework.Controls.MetroLabel lblFornecedor;
        public MetroFramework.Controls.MetroComboBox cbbFornecedor;
        private MetroFramework.Controls.MetroLabel lblCategoria;
        public MetroFramework.Controls.MetroComboBox cbbCategoria;
        private MetroFramework.Controls.MetroLabel lblDigitoVerificador;
        private MetroFramework.Controls.MetroLabel lblCodigoBarras;
        public MetroFramework.Controls.MetroTextBox txtDigitoVerificador;
        public MetroFramework.Controls.MetroTextBox txtCodigoBarras;
        private MetroFramework.Controls.MetroLabel lblUnidade;
        public MetroFramework.Controls.MetroTextBox txtUnidade;
        public MetroFramework.Controls.MetroTextBox txtNomeProduto;
        private MetroFramework.Controls.MetroLabel lblNomeProduto;
        private System.Windows.Forms.GroupBox grpPesquisa;
        public MetroFramework.Controls.MetroTextBox txtPesquisaCodProduto;
        public MetroFramework.Controls.MetroComboBox cbbPesquisaProduto;
        public MetroFramework.Controls.MetroButton btnPesquisaOK;
        public MetroFramework.Controls.MetroButton btnNovoProduto;
        private System.Windows.Forms.GroupBox grpAdicionarGrade;
        public MetroFramework.Controls.MetroTextBox txtValorCusto;
        public MetroFramework.Controls.MetroTextBox txtGradeDV;
        public MetroFramework.Controls.MetroTextBox txtValorSaida;
        public MetroFramework.Controls.MetroComboBox cbbGradeTamanho;
        public MetroFramework.Controls.MetroComboBox cbbGradeCor;
        public MetroFramework.Controls.MetroButton btnGradeCancelar;
        public MetroFramework.Controls.MetroButton btnGradeConfirmar;
        private MetroFramework.Controls.MetroLabel lblAdicionarGrade;
        public MetroFramework.Controls.MetroTextBox txtGradeCodigoBarras;
        private MetroFramework.Controls.MetroPanel pnlProdutoItem;
        private MetroFramework.Controls.MetroPanel pblProdutoBottom;
        private MetroFramework.Controls.MetroPanel pnlProdutoGrade;
    }
}