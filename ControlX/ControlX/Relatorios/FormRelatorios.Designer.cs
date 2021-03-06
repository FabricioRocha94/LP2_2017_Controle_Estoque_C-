﻿namespace ControlX
{
    partial class FormRelatorios
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
        /// 

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRelatorios));
            this.crvRelatorio = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.Compras_Rel1 = new ControlX.Relatorios.Compras_Rel();
            this.Vendas_Rel1 = new ControlX.Relatorios.Vendas_Rel();
            this.EstoqueMin_Rel1 = new ControlX.Relatorios.EstoqueMin_Rel();
            this.NotaFiscal1 = new ControlX.Relatorios.NotaFiscal();
            this.Func_Rel1 = new ControlX.Relatorios.Func_Rel();
            this.Inventario_Rel1 = new ControlX.Relatorios.Inventario_Rel();
            this.Compras_NF1 = new ControlX.Relatorios.Compras_NF();
            this.SuspendLayout();
            // 
            // crvRelatorio
            // 
            this.crvRelatorio.ActiveViewIndex = 0;
            this.crvRelatorio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvRelatorio.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvRelatorio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvRelatorio.Location = new System.Drawing.Point(0, 0);
            this.crvRelatorio.Name = "crvRelatorio";
            this.crvRelatorio.ReportSource = this.Compras_Rel1;
            this.crvRelatorio.Size = new System.Drawing.Size(704, 521);
            this.crvRelatorio.TabIndex = 0;
            this.crvRelatorio.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FormRelatorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 521);
            this.Controls.Add(this.crvRelatorio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRelatorios";
            this.Text = "ControlX - Relatorios";
            this.Load += new System.EventHandler(this.RelatorioCompras_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvRelatorio;
        private Relatorios.EstoqueMin_Rel EstoqueMin_Rel1;
        private Relatorios.Vendas_Rel Vendas_Rel1;
        private Relatorios.Compras_Rel Compras_Rel1;
        private Relatorios.NotaFiscal NotaFiscal1;
        private Relatorios.Func_Rel Func_Rel1;
        private Relatorios.Inventario_Rel Inventario_Rel1;
        private Relatorios.Compras_NF Compras_NF1;
    }
}