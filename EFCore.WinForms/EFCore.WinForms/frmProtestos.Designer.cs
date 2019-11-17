namespace WF_ModerUI
{
    partial class frmProtestos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProtestos));
            this.btIncluir = new System.Windows.Forms.Button();
            this.btAlterar = new System.Windows.Forms.Button();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.pnCabecalho = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOperacao = new System.Windows.Forms.Label();
            this.txtOperacao = new System.Windows.Forms.TextBox();
            this.lblTipoDocumento = new System.Windows.Forms.Label();
            this.txtTipoDocumento = new System.Windows.Forms.TextBox();
            this.lblDataVencimento = new System.Windows.Forms.Label();
            this.lblDataEmissao = new System.Windows.Forms.Label();
            this.lblValorProtestar = new System.Windows.Forms.Label();
            this.txtValorProtestar = new System.Windows.Forms.TextBox();
            this.lblBancoId = new System.Windows.Forms.Label();
            this.txtProtestoId = new System.Windows.Forms.TextBox();
            this.lblContrato = new System.Windows.Forms.Label();
            this.gbAcoes = new System.Windows.Forms.GroupBox();
            this.btSalvar = new System.Windows.Forms.Button();
            this.btExcluir = new System.Windows.Forms.Button();
            this.cmbPesquisa = new System.Windows.Forms.ComboBox();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.gbPesquisar = new System.Windows.Forms.GroupBox();
            this.gbInformacoes = new System.Windows.Forms.GroupBox();
            this.lbDataEmissao = new System.Windows.Forms.Label();
            this.txtDataVencimento = new System.Windows.Forms.TextBox();
            this.txtDataEmissao = new System.Windows.Forms.TextBox();
            this.cmbContrato = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.pnCabecalho.SuspendLayout();
            this.gbAcoes.SuspendLayout();
            this.gbPesquisar.SuspendLayout();
            this.gbInformacoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // btIncluir
            // 
            this.btIncluir.Image = ((System.Drawing.Image)(resources.GetObject("btIncluir.Image")));
            this.btIncluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btIncluir.Location = new System.Drawing.Point(19, 21);
            this.btIncluir.Margin = new System.Windows.Forms.Padding(4);
            this.btIncluir.Name = "btIncluir";
            this.btIncluir.Size = new System.Drawing.Size(140, 47);
            this.btIncluir.TabIndex = 3;
            this.btIncluir.Text = "      Incluir Protesto";
            this.btIncluir.UseVisualStyleBackColor = true;
            this.btIncluir.Click += new System.EventHandler(this.btIncluir_Click);
            // 
            // btAlterar
            // 
            this.btAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btAlterar.Image")));
            this.btAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAlterar.Location = new System.Drawing.Point(19, 80);
            this.btAlterar.Margin = new System.Windows.Forms.Padding(4);
            this.btAlterar.Name = "btAlterar";
            this.btAlterar.Size = new System.Drawing.Size(140, 47);
            this.btAlterar.TabIndex = 3;
            this.btAlterar.Text = " Alterar";
            this.btAlterar.UseVisualStyleBackColor = true;
            this.btAlterar.Click += new System.EventHandler(this.btAlterar_Click);
            // 
            // dgvDados
            // 
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Location = new System.Drawing.Point(0, 320);
            this.dgvDados.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.RowHeadersWidth = 51;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(889, 404);
            this.dgvDados.TabIndex = 4;
            this.dgvDados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDados_CellClick);
            // 
            // pnCabecalho
            // 
            this.pnCabecalho.BackColor = System.Drawing.Color.IndianRed;
            this.pnCabecalho.Controls.Add(this.label1);
            this.pnCabecalho.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnCabecalho.Location = new System.Drawing.Point(0, 0);
            this.pnCabecalho.Margin = new System.Windows.Forms.Padding(4);
            this.pnCabecalho.Name = "pnCabecalho";
            this.pnCabecalho.Size = new System.Drawing.Size(890, 51);
            this.pnCabecalho.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cadastro de Protestos ";
            // 
            // lblOperacao
            // 
            this.lblOperacao.AutoSize = true;
            this.lblOperacao.Location = new System.Drawing.Point(58, 79);
            this.lblOperacao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOperacao.Name = "lblOperacao";
            this.lblOperacao.Size = new System.Drawing.Size(84, 17);
            this.lblOperacao.TabIndex = 64;
            this.lblOperacao.Text = "* Operação:";
            // 
            // txtOperacao
            // 
            this.txtOperacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOperacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOperacao.Location = new System.Drawing.Point(150, 77);
            this.txtOperacao.Margin = new System.Windows.Forms.Padding(4);
            this.txtOperacao.MaxLength = 1;
            this.txtOperacao.Name = "txtOperacao";
            this.txtOperacao.Size = new System.Drawing.Size(114, 22);
            this.txtOperacao.TabIndex = 63;
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.AutoSize = true;
            this.lblTipoDocumento.Location = new System.Drawing.Point(-3, 142);
            this.lblTipoDocumento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoDocumento.Name = "lblTipoDocumento";
            this.lblTipoDocumento.Size = new System.Drawing.Size(145, 17);
            this.lblTipoDocumento.TabIndex = 62;
            this.lblTipoDocumento.Text = "* Tipo de Documento:";
            // 
            // txtTipoDocumento
            // 
            this.txtTipoDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipoDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipoDocumento.Location = new System.Drawing.Point(150, 137);
            this.txtTipoDocumento.Margin = new System.Windows.Forms.Padding(4);
            this.txtTipoDocumento.MaxLength = 10;
            this.txtTipoDocumento.Name = "txtTipoDocumento";
            this.txtTipoDocumento.Size = new System.Drawing.Size(114, 22);
            this.txtTipoDocumento.TabIndex = 61;
            // 
            // lblDataVencimento
            // 
            this.lblDataVencimento.AutoSize = true;
            this.lblDataVencimento.Location = new System.Drawing.Point(380, 77);
            this.lblDataVencimento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataVencimento.Name = "lblDataVencimento";
            this.lblDataVencimento.Size = new System.Drawing.Size(149, 17);
            this.lblDataVencimento.TabIndex = 60;
            this.lblDataVencimento.Text = "* Data do Vencimento:";
            // 
            // lblDataEmissao
            // 
            this.lblDataEmissao.AutoSize = true;
            this.lblDataEmissao.Location = new System.Drawing.Point(401, 49);
            this.lblDataEmissao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataEmissao.Name = "lblDataEmissao";
            this.lblDataEmissao.Size = new System.Drawing.Size(128, 17);
            this.lblDataEmissao.TabIndex = 58;
            this.lblDataEmissao.Text = "* Data de Emissão:";
            // 
            // lblValorProtestar
            // 
            this.lblValorProtestar.AutoSize = true;
            this.lblValorProtestar.Location = new System.Drawing.Point(26, 109);
            this.lblValorProtestar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorProtestar.Name = "lblValorProtestar";
            this.lblValorProtestar.Size = new System.Drawing.Size(116, 17);
            this.lblValorProtestar.TabIndex = 55;
            this.lblValorProtestar.Text = "* Valor Protestar:";
            // 
            // txtValorProtestar
            // 
            this.txtValorProtestar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorProtestar.Location = new System.Drawing.Point(150, 107);
            this.txtValorProtestar.Margin = new System.Windows.Forms.Padding(4);
            this.txtValorProtestar.MaxLength = 21;
            this.txtValorProtestar.Name = "txtValorProtestar";
            this.txtValorProtestar.Size = new System.Drawing.Size(214, 22);
            this.txtValorProtestar.TabIndex = 56;
            this.txtValorProtestar.Leave += new System.EventHandler(this.txtValorProtestar_Leave);
            // 
            // lblBancoId
            // 
            this.lblBancoId.AutoSize = true;
            this.lblBancoId.Location = new System.Drawing.Point(105, 25);
            this.lblBancoId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBancoId.Name = "lblBancoId";
            this.lblBancoId.Size = new System.Drawing.Size(25, 17);
            this.lblBancoId.TabIndex = 53;
            this.lblBancoId.Text = "ID:";
            // 
            // txtProtestoId
            // 
            this.txtProtestoId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProtestoId.Location = new System.Drawing.Point(150, 17);
            this.txtProtestoId.Margin = new System.Windows.Forms.Padding(4);
            this.txtProtestoId.MaxLength = 50;
            this.txtProtestoId.Name = "txtProtestoId";
            this.txtProtestoId.ReadOnly = true;
            this.txtProtestoId.Size = new System.Drawing.Size(214, 22);
            this.txtProtestoId.TabIndex = 52;
            this.txtProtestoId.TabStop = false;
            // 
            // lblContrato
            // 
            this.lblContrato.AutoSize = true;
            this.lblContrato.Location = new System.Drawing.Point(58, 53);
            this.lblContrato.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContrato.Name = "lblContrato";
            this.lblContrato.Size = new System.Drawing.Size(75, 17);
            this.lblContrato.TabIndex = 51;
            this.lblContrato.Text = "* Contrato:";
            // 
            // gbAcoes
            // 
            this.gbAcoes.Controls.Add(this.btSalvar);
            this.gbAcoes.Controls.Add(this.btExcluir);
            this.gbAcoes.Controls.Add(this.btIncluir);
            this.gbAcoes.Controls.Add(this.btAlterar);
            this.gbAcoes.Location = new System.Drawing.Point(702, 58);
            this.gbAcoes.Name = "gbAcoes";
            this.gbAcoes.Size = new System.Drawing.Size(180, 239);
            this.gbAcoes.TabIndex = 65;
            this.gbAcoes.TabStop = false;
            this.gbAcoes.Text = "Ações";
            // 
            // btSalvar
            // 
            this.btSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btSalvar.Image")));
            this.btSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSalvar.Location = new System.Drawing.Point(19, 190);
            this.btSalvar.Margin = new System.Windows.Forms.Padding(4);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(140, 39);
            this.btSalvar.TabIndex = 5;
            this.btSalvar.Text = "Salvar";
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btExcluir.Image")));
            this.btExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExcluir.Location = new System.Drawing.Point(19, 135);
            this.btExcluir.Margin = new System.Windows.Forms.Padding(4);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(140, 47);
            this.btExcluir.TabIndex = 4;
            this.btExcluir.Text = "Excluír";
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // cmbPesquisa
            // 
            this.cmbPesquisa.FormattingEnabled = true;
            this.cmbPesquisa.Items.AddRange(new object[] {
            "IdProtesto",
            "IdContrato"});
            this.cmbPesquisa.Location = new System.Drawing.Point(359, 21);
            this.cmbPesquisa.Name = "cmbPesquisa";
            this.cmbPesquisa.Size = new System.Drawing.Size(124, 24);
            this.cmbPesquisa.TabIndex = 66;
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesquisa.Location = new System.Drawing.Point(4, 22);
            this.txtPesquisa.Margin = new System.Windows.Forms.Padding(4);
            this.txtPesquisa.MaxLength = 20;
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(348, 22);
            this.txtPesquisa.TabIndex = 67;
            this.txtPesquisa.TextChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // gbPesquisar
            // 
            this.gbPesquisar.Controls.Add(this.txtPesquisa);
            this.gbPesquisar.Controls.Add(this.cmbPesquisa);
            this.gbPesquisar.Location = new System.Drawing.Point(12, 58);
            this.gbPesquisar.Name = "gbPesquisar";
            this.gbPesquisar.Size = new System.Drawing.Size(507, 54);
            this.gbPesquisar.TabIndex = 68;
            this.gbPesquisar.TabStop = false;
            this.gbPesquisar.Text = "Pesquisar";
            // 
            // gbInformacoes
            // 
            this.gbInformacoes.Controls.Add(this.lbDataEmissao);
            this.gbInformacoes.Controls.Add(this.txtDataVencimento);
            this.gbInformacoes.Controls.Add(this.txtDataEmissao);
            this.gbInformacoes.Controls.Add(this.cmbContrato);
            this.gbInformacoes.Controls.Add(this.txtProtestoId);
            this.gbInformacoes.Controls.Add(this.lblContrato);
            this.gbInformacoes.Controls.Add(this.lblOperacao);
            this.gbInformacoes.Controls.Add(this.lblBancoId);
            this.gbInformacoes.Controls.Add(this.txtOperacao);
            this.gbInformacoes.Controls.Add(this.txtValorProtestar);
            this.gbInformacoes.Controls.Add(this.lblTipoDocumento);
            this.gbInformacoes.Controls.Add(this.lblValorProtestar);
            this.gbInformacoes.Controls.Add(this.txtTipoDocumento);
            this.gbInformacoes.Controls.Add(this.lblDataVencimento);
            this.gbInformacoes.Controls.Add(this.lblDataEmissao);
            this.gbInformacoes.Location = new System.Drawing.Point(12, 128);
            this.gbInformacoes.Name = "gbInformacoes";
            this.gbInformacoes.Size = new System.Drawing.Size(659, 169);
            this.gbInformacoes.TabIndex = 69;
            this.gbInformacoes.TabStop = false;
            this.gbInformacoes.Text = "Informações";
            // 
            // lbDataEmissao
            // 
            this.lbDataEmissao.AutoSize = true;
            this.lbDataEmissao.Location = new System.Drawing.Point(436, 18);
            this.lbDataEmissao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDataEmissao.Name = "lbDataEmissao";
            this.lbDataEmissao.Size = new System.Drawing.Size(216, 17);
            this.lbDataEmissao.TabIndex = 68;
            this.lbDataEmissao.Text = "* Datas no formato DD/MM/AAAA";
            // 
            // txtDataVencimento
            // 
            this.txtDataVencimento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataVencimento.Location = new System.Drawing.Point(537, 75);
            this.txtDataVencimento.Margin = new System.Windows.Forms.Padding(4);
            this.txtDataVencimento.MaxLength = 21;
            this.txtDataVencimento.Name = "txtDataVencimento";
            this.txtDataVencimento.Size = new System.Drawing.Size(113, 22);
            this.txtDataVencimento.TabIndex = 67;
            this.txtDataVencimento.Leave += new System.EventHandler(this.txtDataVencimento_Leave);
            // 
            // txtDataEmissao
            // 
            this.txtDataEmissao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataEmissao.Location = new System.Drawing.Point(537, 44);
            this.txtDataEmissao.Margin = new System.Windows.Forms.Padding(4);
            this.txtDataEmissao.MaxLength = 21;
            this.txtDataEmissao.Name = "txtDataEmissao";
            this.txtDataEmissao.Size = new System.Drawing.Size(113, 22);
            this.txtDataEmissao.TabIndex = 66;
            this.txtDataEmissao.Leave += new System.EventHandler(this.txtDataEmissao_Leave);
            // 
            // cmbContrato
            // 
            this.cmbContrato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbContrato.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbContrato.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbContrato.FormattingEnabled = true;
            this.cmbContrato.Location = new System.Drawing.Point(150, 47);
            this.cmbContrato.Margin = new System.Windows.Forms.Padding(4);
            this.cmbContrato.Name = "cmbContrato";
            this.cmbContrato.Size = new System.Drawing.Size(214, 24);
            this.cmbContrato.TabIndex = 65;
            // 
            // frmProtestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 724);
            this.Controls.Add(this.gbInformacoes);
            this.Controls.Add(this.gbPesquisar);
            this.Controls.Add(this.gbAcoes);
            this.Controls.Add(this.pnCabecalho);
            this.Controls.Add(this.dgvDados);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmProtestos";
            this.Text = "Protestos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.pnCabecalho.ResumeLayout(false);
            this.pnCabecalho.PerformLayout();
            this.gbAcoes.ResumeLayout(false);
            this.gbPesquisar.ResumeLayout(false);
            this.gbPesquisar.PerformLayout();
            this.gbInformacoes.ResumeLayout(false);
            this.gbInformacoes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btIncluir;
        private System.Windows.Forms.Button btAlterar;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Panel pnCabecalho;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOperacao;
        private System.Windows.Forms.TextBox txtOperacao;
        private System.Windows.Forms.Label lblTipoDocumento;
        private System.Windows.Forms.TextBox txtTipoDocumento;
        private System.Windows.Forms.Label lblDataVencimento;
        private System.Windows.Forms.Label lblDataEmissao;
        private System.Windows.Forms.Label lblValorProtestar;
        private System.Windows.Forms.TextBox txtValorProtestar;
        private System.Windows.Forms.Label lblBancoId;
        private System.Windows.Forms.TextBox txtProtestoId;
        private System.Windows.Forms.Label lblContrato;
        private System.Windows.Forms.GroupBox gbAcoes;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.ComboBox cmbPesquisa;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.GroupBox gbPesquisar;
        private System.Windows.Forms.GroupBox gbInformacoes;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.ComboBox cmbContrato;
        private System.Windows.Forms.Label lbDataEmissao;
        private System.Windows.Forms.TextBox txtDataVencimento;
        private System.Windows.Forms.TextBox txtDataEmissao;
    }
}