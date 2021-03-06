﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlX
{
    public partial class FormVender : Form
    {

        static IDao db = new DAO.ProdutoDao();
        static List<Object> ps = db.ListAll();
        VenderDao vd = new VenderDao();
        Usuario user = new Usuario();
        double qntdEstoque;

        public FormVender()
        {
            InitializeComponent();
            Auto_Complete();
            BtComplete();
        }

        public FormVender(Usuario u)
        {
            InitializeComponent();
            user = u;
            Auto_Complete();
            BtComplete();
        }

        private void BtComplete()
        {
            if (dgvVendas.RowCount <= 0)
            {
                btVender.Enabled = false;
                btDelItemVenda.Enabled = false;
                btCancelar.Enabled = false;
                txValorPago.Enabled = false;
            }
            else
            {
                btVender.Enabled = true;
                btDelItemVenda.Enabled = true;
                btCancelar.Enabled = true;
                txValorPago.Enabled = true;
            }
            if (txId.Text.Trim() == "" || txNome.Text.Trim() == "" || txQntdVenda.Text.Trim() == "")
                btAdd.Enabled = false;
            else
                btAdd.Enabled = true;
        }

        private void Auto_Complete()
        {
            txNome.AutoCompleteMode = AutoCompleteMode.Suggest;
            txNome.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            //Adiciona sugestão de nomes ao digitar no TextBox
            foreach (Produto p in ps)
            {
                col.Add(p.Nome);
            }

            txNome.AutoCompleteCustomSource = col;
        }

        private void btMenu_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void Limpar()
        {
            txNome.Text = "";
            txId.Text = "";
            lbPrecoShow.Text = "";
            lbQntdEstoqueShow.Text = "";
            txQntdVenda.Text = "";
            txValorPago.Text = "";
            txCategoria.Text = "";
            txFornecedor.Text = "";
            lbTrocoShow.Text = "";
            txValorTotalItem.Text = "";
            pbImagemProd.Image = Properties.Resources.product;

        }
        private void btLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void txNome_TextChanged(object sender, EventArgs e)
        {
            BtComplete();
            foreach (Produto p in ps)
                if (txNome.Text.Trim() == p.Nome)
                {
                    txId.Text = Convert.ToString(p.Id);
                    txFornecedor.Text = p.Fornecedor.Nome;
                    txCategoria.Text = p.Cat.Nome;
                    lbPrecoShow.Text = Convert.ToString(p.Preco);
                    lbQntdEstoqueShow.Text = Convert.ToString(p.Qntd) + " " + p.TipoUn;
                    txQntdVenda.Text = "1";
                    qntdEstoque = p.Qntd;
                    if (p.LocalPic == null)
                        pbImagemProd.Image = Properties.Resources.product;
                    else
                        pbImagemProd.ImageLocation = p.LocalPic;
                }

        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {

            formEstoque formSearch = new formEstoque();
            formSearch.categoriasToolStripMenuItem.Enabled = false;
            formSearch.adicionarToolStripMenuItem.Enabled = false;
            formSearch.editarToolStripMenuItem.Enabled = false;
            formSearch.removerToolStripMenuItem.Enabled = false;
            formSearch.ShowDialog(this);

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            dgvVendas.Rows.Clear();
            ps = db.ListAll();
            Limpar();
            lbValorTotal.Text = "";
            BtComplete();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            double qVenda = double.Parse(txQntdVenda.Text); //Quantidade que sera vendida
            //double qEstoque = double.Parse(lbQntdEstoqueShow.Text);//Quantidade no estoque
            int idProd = int.Parse(txId.Text);//Id do produto a ser adicionado a venda

            for (int i = 0; i < dgvVendas.RowCount; i++)
            {
                if (idProd == int.Parse(dgvVendas.Rows[dgvVendas.Rows[i].Index].Cells[0].Value.ToString()))
                {
                    MessageBox.Show("Este mesmo produto já consta na lista de venda, remova-o e reinsira com a quantidade correta!","Erro! Produto já existente na lista!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }

            }

            if (qVenda > qntdEstoque || qVenda <= 0)
            {
                MessageBox.Show("Item não adicionado !\nVerifique se a quantidade de venda é maior que a do estoque ou maior que 0(zero)!", "Quantidade inválida!",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                foreach (Produto p in ps)
                {
                    if (p.Id == idProd)
                    {
                        //Preço da venda (QTD * PREÇO UNITARIO)
                        double pVenda = qVenda * p.Preco;
                        //Adicionando ao Data Grid View
                        dgvVendas.Rows.Add(p.Id, p.Nome, qVenda, p.TipoUn, p.Preco, pVenda);
                        //Valor Total Recebe o valor ja existente, caso esteja NULL, recebe 0
                        double vTotal = lbValorTotal.Text == "" ? 0 : double.Parse(lbValorTotal.Text);
                        //O Label com o Valor Total recebe ele mesmo, mais o Preço de Venda do item em questão
                        lbValorTotal.Text = Convert.ToString(vTotal + pVenda);

                        p.Qntd = p.Qntd - qVenda;

                        Limpar();
                        BtComplete();

                    }
                }
            }
        }

        private void lbId_Click(object sender, EventArgs e)
        {

        }

        private void pnForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btDelItemVenda_Click(object sender, EventArgs e)
        {
            if (dgvVendas.RowCount > 0)
            {
                int idProd = int.Parse(dgvVendas.Rows[dgvVendas.CurrentRow.Index].Cells[0].Value.ToString());
                double qntdProd = double.Parse(dgvVendas.Rows[dgvVendas.CurrentRow.Index].Cells[2].Value.ToString());
                double precoTotalProd = double.Parse(dgvVendas.Rows[dgvVendas.CurrentRow.Index].Cells[5].Value.ToString());
                double vTotal = double.Parse(lbValorTotal.Text);

                foreach (Produto p in ps)
                {
                    if (p.Id == idProd)
                    {
                        p.Qntd += qntdProd;
                        lbValorTotal.Text = Convert.ToString(vTotal - precoTotalProd);
                        dgvVendas.Rows.RemoveAt(dgvVendas.CurrentRow.Index);
                        BtComplete();
                        Limpar();
                    }
                }
            }
        }

        private void txId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txQntdVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
                e.Handled = true;

            if (e.KeyChar == ',')   //Se o usuario inserir uma virgula
                if (txQntdVenda.Text.Contains(",") || txQntdVenda.Text.Equals(""))//Checa se o usuario ja inseriu uma virgula previamente
                    e.Handled = true; // Caso ja exista uma virgula, outra não será aceita   
  
        }

        private void btVender_Click(object sender, EventArgs e)
        {
            try
            {
                List<Object> produtos = db.ListAll();
                Vender vender = new Vender();
                for (int i = 0; i < dgvVendas.RowCount; i++)
                {
                    int idProduto = int.Parse(dgvVendas.Rows[dgvVendas.Rows[i].Index].Cells[0].Value.ToString());
                    foreach (Produto p in produtos)
                    {
                        if (p.Id == idProduto)
                        {
                            p.Preco = double.Parse(dgvVendas.Rows[dgvVendas.Rows[i].Index].Cells[4].Value.ToString());
                            p.Qntd = double.Parse(dgvVendas.Rows[i].Cells[2].Value.ToString());
                            vender.Itens.Add(p);            
                        }
                    }
                }

                
                vender.Id = vd.GetId();
                vender.Nome_usuario = user.Nome;
                vender.Valor = double.Parse(lbValorTotal.Text.ToString());
                vender.Data = DateTime.Now;
                vd.Adicionar(vender);

                int numProd = dgvVendas.RowCount;
                for (int i = 0; i < numProd; i++)
                {
                    int idProd = int.Parse(dgvVendas.Rows[i].Cells[0].Value.ToString());
                    double qtdVenda = double.Parse(dgvVendas.Rows[i].Cells[2].Value.ToString());

                    foreach (Produto p in ps)
                    {
                        if (p.Id == idProd)
                        {
                            db.Atualizar(p);
                        }
                    }
                }
                DialogResult result = MessageBox.Show("Venda Concluida com Sucesso !!!\n Deseja imprimir o Recibo do Cliente? ",
                    "Venda Realizada",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //Caso clique em sim
                if (result == DialogResult.Yes)
                {
                    FormRelatorios form = new FormRelatorios(user.Nome, vender.Data, vender.Id, vender.Nome_usuario);
                    form.Text = "ControlX - Nota Fiscal ID: " + txId.Text;
                    form.tipoRelatorio = 5;
                    form.Show();
                }
                else if (result == DialogResult.No)
                {
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("ERRO:" + x, "Venda não concluida!");
            }
            finally
            {
                this.Refresh();
                dgvVendas.Rows.Clear();
                ps = db.ListAll();
                Limpar();
                lbValorTotal.Text = "";
                BtComplete();

            }
        }



        private void txTroco_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double Troco = double.Parse(txValorPago.Text) - double.Parse(lbValorTotal.Text);
                lbTrocoShow.Text = Convert.ToString(Troco);
            }
            catch (System.Exception)
            {

            }
        }

        private void txId_TextChanged(object sender, EventArgs e)
        {
            BtComplete();
            foreach (Produto p in ps)
                if (txId.Text.Trim() == Convert.ToString(p.Id))
                {
                    txNome.Text = p.Nome;
                    txId.Text = Convert.ToString(p.Id);
                    lbPrecoShow.Text = Convert.ToString(p.Preco);
                    lbQntdEstoqueShow.Text = Convert.ToString(p.Qntd) + " " + p.TipoUn;                    
                    qntdEstoque = p.Qntd;
                    txValorTotalItem.Text = (p.Preco * (txQntdVenda.Text != "" ? double.Parse(txQntdVenda.Text) : 1)).ToString();
                }
            
        }
    }
}
