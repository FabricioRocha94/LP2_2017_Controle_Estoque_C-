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
    public partial class formCadastroProd : Form
    {
        private static Dictionary <int, Produto> produtos = new Dictionary<int, Produto>();
        private Database db1 = new Database();
        private Produto nProduto = new Produto();
       

        public formCadastroProd()
        {
            InitializeComponent();
            int count = 0;
            foreach (KeyValuePair<int, Produto> k in produtos)
            {
                count++;
            }
            lbIdProduto.Text = "" + (count+=1);
            btComplete();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        
        private void btComplete()
        {
            if (txNome.Text.Trim() == "" || txPreco.Text.Trim() == "" || txQntd.Text.Trim() == "")
                btCadastrar.Enabled = false;
            else
                btCadastrar.Enabled = true;
        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
                nProduto.Nome = txNome.Text;
                nProduto.Preco = double.Parse(txPreco.Text);
                nProduto.Id = int.Parse(lbIdProduto.Text);
                nProduto.Qntd = int.Parse(txQntd.Text);
                btComplete();
                if (btCadastrar.Text != "Salvar")
                {
                    db1.Adicionar(nProduto);
                    produtos.Add(nProduto.Id, nProduto);
                }
                else if (btCadastrar.Text == "Salvar")
                    db1.Atualizar(nProduto);
            
            
            this.Dispose();           
        }

        private void txNome_TextChanged(object sender, EventArgs e)
        {
            btComplete();
        }

        private void txPreco_TextChanged(object sender, EventArgs e)
        {
            btComplete();
        }

        private void txQntd_TextChanged(object sender, EventArgs e)
        {
            btComplete();
        }
    }
}
