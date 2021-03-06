﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlX
{
    public partial class formCadastroUser : Form
    {

        private IDao db1 = new DAO.UsuarioDao();
        private Usuario user = new Usuario();
        bool loginValido = false;

        public bool LoginValido
        {
            get
            {
                return loginValido;
            }

            set
            {
                loginValido = value;
            }
        }

        public formCadastroUser()
        {            
            InitializeComponent();
            btComplete();
        }

        private void btComplete()
        {
            if (txNome.Text.Trim() == "" || txRua.Text.Trim() == ""
                || txBairro.Text.Trim() == "" || txCidade.Text.Trim() == "" || txEstado.Text.Trim() == ""
                    || txNum.Text.Trim() == "" || !txCPF.MaskCompleted || !txTel1.MaskCompleted || txLogin.Text.Trim() == ""
                        || txSenha.Text.Trim() == "" || cbCargo.Text.Trim() == "" || cbSexo.Text.Trim() == "" || !LoginValido) //O IF ACABA AQUI, KRAI
                btCadastrar.Enabled = false;
            else
                btCadastrar.Enabled = true;

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void MaskOff()
        {
            //Tirando a Mascara dos TextBox
            txCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            txTel1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            txTel2.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            txCEP.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            MaskOff();  //Tira a máscara para mandar ao Banco somente os valores
            user.Nome = txNome.Text;
            user.Cpf = long.Parse(txCPF.Text);
            user.Sexo = char.Parse(cbSexo.Text);
            user.DataNasc = dtpDataNasc.Value;
            user.Cep = long.Parse(txCEP.Text);
            user.Rua = txRua.Text;
            user.Bairro = txBairro.Text;
            user.Num = long.Parse(txNum.Text);
            user.Cidade = txCidade.Text;
            user.Estado = txEstado.Text;
            user.Comp = txCompl.Text;
            user.Cargo = cbCargo.Text;
            user.Login = txLogin.Text;
            user.Senha = txSenha.Text;
            user.Telefone1 = long.Parse(txTel1.Text);
            user.Telefone2 = (txTel2.Text == "") ? 0 : long.Parse(txTel2.Text);
            //Se o botão estiver com o nome de 'Cadastrar', salvaremos tudo no Banco de Dados

            if (pbImagemUser.ImageLocation != null)
            {
                string pasta = @"C:\\ControlX\\Images\\Usuarios\\";
                //nome do diretorio a ser criado

                if (!Directory.Exists(pasta)) //Se o diretório não existir...
                {
                    //Criamos um com o nome folder
                    Directory.CreateDirectory(pasta);
                }

                pbImagemUser.Image.Save(pasta + lbIdUser.Text + ".jpg", ImageFormat.Jpeg);
                user.LocalPic = pasta + lbIdUser.Text + ".jpg";
            }
            else
                user.LocalPic = null;


            if (btCadastrar.Text == "Cadastrar")
                db1.Adicionar(user);
            //Se estiver 'Salvar', pegamos o ID no label, referente ao produto que será editado
            //e mandamos ao banco novamente
            else if (btCadastrar.Text == "Salvar")
            {
               user.Id = int.Parse(lbIdUser.Text);
               db1.Atualizar(user);
            }
            this.Close();
        }

        private void BuscaCEP()
        {
            try
            {

                var ws = new WsCorreios.AtendeClienteClient();
                //Criamos uma variavel para receber o valor que o método consultaCEP retornará.
                //Ela já é um método que vem pronto com o WS dos correios, precisamos simplesmente passar
                //O CEP
                var consulta = ws.consultaCEP(txCEP.Text);

                //Exibindo os valores retornados em seus respectivos 'TextBox'
                txRua.Text = consulta.end;
                txCompl.Text = consulta.complemento;
                txBairro.Text = consulta.bairro;
                txCidade.Text = consulta.cidade;
                txEstado.Text = consulta.uf;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao efetuar busca do CEP: " + txCEP.Text + "\n" + ex.Message, "BUSCA DO CEP INVÁLIDA");
            }
        }

        private void txCEP_Leave(object sender, EventArgs e)
        {
            if (txCEP.MaskFull)
                BuscaCEP();
        }

        private void txLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se o que foi digitado NÃO for um Digito(numeral) E NÃO for do tipo controle(backspace por exemplo) 
            //E NÃO for do tipo Letter(Alfabeto)
            //o e.Handled praticamente ira ignorar o que foi inserido
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void txLogin_Leave(object sender, EventArgs e)
        {
            if (txLogin.Text != "")
            {
                DAO.UsuarioDao uDAO = new DAO.UsuarioDao();
                bool verifica = uDAO.Verificar(txLogin.Text);
                lbMensagem.Visible = true;

                if (verifica)
                {
                    lbMensagem.ForeColor = Color.Red;                 
                    lbMensagem.Text = "Usuário já está em uso!";
                    LoginValido = false;
                    btComplete();
                }
                else
                {
                    lbMensagem.ForeColor = Color.Green;
                    lbMensagem.Text = "Usuário disponivel para uso!";
                    LoginValido = true;
                    btComplete();
                }
            }
            else
                lbMensagem.Visible = false;
        }

        private void txSenha_TextChanged(object sender, EventArgs e)
        {
            btComplete();
        }

        private void btImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog imagem = new OpenFileDialog();
            imagem.Filter = "jpg|*.jpg";
            if (imagem.ShowDialog() == DialogResult.OK)
            {
                FileInfo arquivo = new FileInfo(imagem.FileName);
                //testa se tem menos de 1MB (1MB em bytes = 1048576)
                if (arquivo.Length <= 1048576)
                {
                    pbImagemUser.ImageLocation = imagem.FileName;
                }
                else
                    MessageBox.Show("O Tamanho da imagem não pode exceder 1MB!", "Tamanho de arquivo inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
