﻿namespace ControlX
{
    partial class formCadastroProd
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
            this.btCadastrar = new System.Windows.Forms.Button();
            this.lbNome = new System.Windows.Forms.Label();
            this.lbPreco = new System.Windows.Forms.Label();
            this.txNome = new System.Windows.Forms.TextBox();
            this.lbId = new System.Windows.Forms.Label();
            this.txPreco = new System.Windows.Forms.TextBox();
            this.pnCadastro = new System.Windows.Forms.Panel();
            this.lbQntd = new System.Windows.Forms.Label();
            this.txQntd = new System.Windows.Forms.TextBox();
            this.lbIdProduto = new System.Windows.Forms.Label();
            this.pnBtCad = new System.Windows.Forms.Panel();
            this.btCancelar = new System.Windows.Forms.Button();
            this.pnCadastro.SuspendLayout();
            this.pnBtCad.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCadastrar
            // 
            this.btCadastrar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCadastrar.Location = new System.Drawing.Point(94, 2);
            this.btCadastrar.Name = "btCadastrar";
            this.btCadastrar.Size = new System.Drawing.Size(75, 23);
            this.btCadastrar.TabIndex = 0;
            this.btCadastrar.Text = "Cadastrar";
            this.btCadastrar.UseVisualStyleBackColor = true;
            this.btCadastrar.Click += new System.EventHandler(this.btCadastrar_Click);
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNome.Location = new System.Drawing.Point(4, 22);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(45, 13);
            this.lbNome.TabIndex = 1;
            this.lbNome.Text = "Nome:";
            // 
            // lbPreco
            // 
            this.lbPreco.AutoSize = true;
            this.lbPreco.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPreco.Location = new System.Drawing.Point(4, 61);
            this.lbPreco.Name = "lbPreco";
            this.lbPreco.Size = new System.Drawing.Size(44, 13);
            this.lbPreco.TabIndex = 2;
            this.lbPreco.Text = "Preço:";
            // 
            // txNome
            // 
            this.txNome.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txNome.Location = new System.Drawing.Point(45, 19);
            this.txNome.Name = "txNome";
            this.txNome.Size = new System.Drawing.Size(278, 21);
            this.txNome.TabIndex = 3;
            this.txNome.TextChanged += new System.EventHandler(this.txNome_TextChanged);
            // 
            // lbId
            // 
            this.lbId.AutoSize = true;
            this.lbId.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbId.Location = new System.Drawing.Point(350, 22);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(26, 13);
            this.lbId.TabIndex = 5;
            this.lbId.Text = "ID:";
            // 
            // txPreco
            // 
            this.txPreco.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txPreco.Location = new System.Drawing.Point(45, 58);
            this.txPreco.Name = "txPreco";
            this.txPreco.Size = new System.Drawing.Size(81, 21);
            this.txPreco.TabIndex = 6;
            this.txPreco.TextChanged += new System.EventHandler(this.txPreco_TextChanged);
            // 
            // pnCadastro
            // 
            this.pnCadastro.Controls.Add(this.lbQntd);
            this.pnCadastro.Controls.Add(this.txQntd);
            this.pnCadastro.Controls.Add(this.lbIdProduto);
            this.pnCadastro.Controls.Add(this.pnBtCad);
            this.pnCadastro.Controls.Add(this.txNome);
            this.pnCadastro.Controls.Add(this.txPreco);
            this.pnCadastro.Controls.Add(this.lbNome);
            this.pnCadastro.Controls.Add(this.lbId);
            this.pnCadastro.Controls.Add(this.lbPreco);
            this.pnCadastro.Location = new System.Drawing.Point(4, 12);
            this.pnCadastro.Name = "pnCadastro";
            this.pnCadastro.Size = new System.Drawing.Size(464, 92);
            this.pnCadastro.TabIndex = 7;
            // 
            // lbQntd
            // 
            this.lbQntd.AutoSize = true;
            this.lbQntd.Location = new System.Drawing.Point(147, 61);
            this.lbQntd.Name = "lbQntd";
            this.lbQntd.Size = new System.Drawing.Size(42, 13);
            this.lbQntd.TabIndex = 11;
            this.lbQntd.Text = "Quant.:";
            // 
            // txQntd
            // 
            this.txQntd.Location = new System.Drawing.Point(194, 58);
            this.txQntd.Name = "txQntd";
            this.txQntd.Size = new System.Drawing.Size(76, 20);
            this.txQntd.TabIndex = 10;
            this.txQntd.TextChanged += new System.EventHandler(this.txQntd_TextChanged);
            // 
            // lbIdProduto
            // 
            this.lbIdProduto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbIdProduto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIdProduto.Location = new System.Drawing.Point(373, 19);
            this.lbIdProduto.Name = "lbIdProduto";
            this.lbIdProduto.Size = new System.Drawing.Size(50, 21);
            this.lbIdProduto.TabIndex = 9;
            this.lbIdProduto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnBtCad
            // 
            this.pnBtCad.Controls.Add(this.btCancelar);
            this.pnBtCad.Controls.Add(this.btCadastrar);
            this.pnBtCad.Location = new System.Drawing.Point(278, 58);
            this.pnBtCad.Name = "pnBtCad";
            this.pnBtCad.Size = new System.Drawing.Size(173, 28);
            this.pnBtCad.TabIndex = 8;
            // 
            // btCancelar
            // 
            this.btCancelar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Location = new System.Drawing.Point(18, 2);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 1;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.button1_Click);
            // 
            // formCadastroProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 111);
            this.Controls.Add(this.pnCadastro);
            this.Name = "formCadastroProd";
            this.ShowIcon = false;
            this.Text = "Cadastrar Produto";
            this.pnCadastro.ResumeLayout(false);
            this.pnCadastro.PerformLayout();
            this.pnBtCad.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbNome;
        private System.Windows.Forms.Label lbPreco;
        private System.Windows.Forms.Label lbId;
        private System.Windows.Forms.Panel pnCadastro;
        private System.Windows.Forms.Panel pnBtCad;
        private System.Windows.Forms.Label lbQntd;
        public System.Windows.Forms.TextBox txNome;
        public System.Windows.Forms.Button btCadastrar;
        public System.Windows.Forms.TextBox txPreco;
        public System.Windows.Forms.Label lbIdProduto;
        public System.Windows.Forms.Button btCancelar;
        public System.Windows.Forms.TextBox txQntd;
    }
}