﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlX
{
    class Produto
    {
        private string nome;
        private int id;
        private double preco;
        private int qntd;
        private int idFornecedor;
        //private Fornecedor fornecedor = new Fornecedor();

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public double Preco
        {
            get
            {
                return preco;
            }

            set
            {
                preco = value;
            }
        }

        public int Qntd
        {
            get
            {
                return qntd;
            }

            set
            {
               qntd = value;
            }
        }

        public int IdFornecedor
        {
            get
            {
                return idFornecedor;
            }

            set
            {
                idFornecedor = value;
            }
        }

        public Produto()
        {

        }

        public Produto(string nome, int id, double preco, int qntd, int idFornecedor)
        {
            this.nome = nome;
            this.id = id;
            this.preco = preco;
            this.qntd = qntd;
            this.idFornecedor = idFornecedor;
        }
    }
}
