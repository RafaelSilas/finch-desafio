namespace WF_ModerUI
{
    partial class frmImportacaoProtestos
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
            this.pnCabecalho = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.gbImportacao = new System.Windows.Forms.GroupBox();
            this.btnImportarArquivo = new System.Windows.Forms.Button();
            this.btnSelecionarArquivo = new System.Windows.Forms.Button();
            this.txtCaminhoArquivo = new System.Windows.Forms.TextBox();
            this.lblCaminhoArquivo = new System.Windows.Forms.Label();
            this.pbImportacao = new System.Windows.Forms.ProgressBar();
            this.pnCabecalho.SuspendLayout();
            this.gbImportacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnCabecalho
            // 
            this.pnCabecalho.BackColor = System.Drawing.Color.IndianRed;
            this.pnCabecalho.Controls.Add(this.label1);
            this.pnCabecalho.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnCabecalho.Location = new System.Drawing.Point(0, 0);
            this.pnCabecalho.Margin = new System.Windows.Forms.Padding(4);
            this.pnCabecalho.Name = "pnCabecalho";
            this.pnCabecalho.Size = new System.Drawing.Size(974, 51);
            this.pnCabecalho.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Importação de Protestos ";
            // 
            // gbImportacao
            // 
            this.gbImportacao.Controls.Add(this.btnImportarArquivo);
            this.gbImportacao.Controls.Add(this.btnSelecionarArquivo);
            this.gbImportacao.Controls.Add(this.txtCaminhoArquivo);
            this.gbImportacao.Controls.Add(this.lblCaminhoArquivo);
            this.gbImportacao.Location = new System.Drawing.Point(12, 58);
            this.gbImportacao.Name = "gbImportacao";
            this.gbImportacao.Size = new System.Drawing.Size(950, 77);
            this.gbImportacao.TabIndex = 11;
            this.gbImportacao.TabStop = false;
            this.gbImportacao.Text = "Selecione o Arquivo";
            // 
            // btnImportarArquivo
            // 
            this.btnImportarArquivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportarArquivo.Enabled = false;
            this.btnImportarArquivo.Location = new System.Drawing.Point(800, 35);
            this.btnImportarArquivo.Margin = new System.Windows.Forms.Padding(4);
            this.btnImportarArquivo.Name = "btnImportarArquivo";
            this.btnImportarArquivo.Size = new System.Drawing.Size(143, 28);
            this.btnImportarArquivo.TabIndex = 14;
            this.btnImportarArquivo.Text = "Iniciar Importacao";
            this.btnImportarArquivo.UseVisualStyleBackColor = true;
            this.btnImportarArquivo.Click += new System.EventHandler(this.btnImportarArquivo_Click);
            // 
            // btnSelecionarArquivo
            // 
            this.btnSelecionarArquivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelecionarArquivo.Location = new System.Drawing.Point(756, 36);
            this.btnSelecionarArquivo.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelecionarArquivo.Name = "btnSelecionarArquivo";
            this.btnSelecionarArquivo.Size = new System.Drawing.Size(36, 28);
            this.btnSelecionarArquivo.TabIndex = 13;
            this.btnSelecionarArquivo.Text = ". . .";
            this.btnSelecionarArquivo.UseVisualStyleBackColor = true;
            this.btnSelecionarArquivo.Click += new System.EventHandler(this.btnSelecionarArquivo_Click);
            // 
            // txtCaminhoArquivo
            // 
            this.txtCaminhoArquivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCaminhoArquivo.Location = new System.Drawing.Point(170, 38);
            this.txtCaminhoArquivo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCaminhoArquivo.Name = "txtCaminhoArquivo";
            this.txtCaminhoArquivo.ReadOnly = true;
            this.txtCaminhoArquivo.Size = new System.Drawing.Size(578, 22);
            this.txtCaminhoArquivo.TabIndex = 12;
            // 
            // lblCaminhoArquivo
            // 
            this.lblCaminhoArquivo.AutoSize = true;
            this.lblCaminhoArquivo.Location = new System.Drawing.Point(22, 42);
            this.lblCaminhoArquivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCaminhoArquivo.Name = "lblCaminhoArquivo";
            this.lblCaminhoArquivo.Size = new System.Drawing.Size(139, 17);
            this.lblCaminhoArquivo.TabIndex = 11;
            this.lblCaminhoArquivo.Text = "Caminho do Arquivo:";
            // 
            // pbImportacao
            // 
            this.pbImportacao.Location = new System.Drawing.Point(12, 155);
            this.pbImportacao.Name = "pbImportacao";
            this.pbImportacao.Size = new System.Drawing.Size(950, 23);
            this.pbImportacao.TabIndex = 12;
            // 
            // frmImportacaoProtestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 190);
            this.Controls.Add(this.pbImportacao);
            this.Controls.Add(this.gbImportacao);
            this.Controls.Add(this.pnCabecalho);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmImportacaoProtestos";
            this.Text = "Importar Protestos";
            this.pnCabecalho.ResumeLayout(false);
            this.pnCabecalho.PerformLayout();
            this.gbImportacao.ResumeLayout(false);
            this.gbImportacao.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnCabecalho;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbImportacao;
        private System.Windows.Forms.Button btnImportarArquivo;
        private System.Windows.Forms.Button btnSelecionarArquivo;
        private System.Windows.Forms.TextBox txtCaminhoArquivo;
        private System.Windows.Forms.Label lblCaminhoArquivo;
        private System.Windows.Forms.ProgressBar pbImportacao;
    }
}