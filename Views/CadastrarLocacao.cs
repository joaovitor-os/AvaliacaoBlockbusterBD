using System;
using System.Collections.Generic;
using Controllers;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace InterfaceFaseUm
{

    public class CadastrarLocacao : Form
    {

        Form parent;
        Label lb_idClinte;
        Label lb_idFilme;
        Label lb_dtLocacao;

        TextBox txtidCliente;
        TextBox txtidFilme;
        TextBox txtDtLocacao;

        Button btnConfirmar;
        Button btnCancelar;

        public CadastrarLocacao(Form parent)
        {
            this.Text = "Cadastro Locação";
            this.BackColor = Color.Azure;

            lb_idClinte = new Label();
            lb_idClinte.Text = "ID do Cliente: ";
            lb_idClinte.Location = new Point(20, 20);

            lb_idFilme = new Label();
            lb_idFilme.Text = "ID do Filme: ";
            lb_idFilme.Location = new Point(20, 100);

            lb_dtLocacao = new Label();
            lb_dtLocacao.Text = "Data de Locação: ";
            lb_dtLocacao.AutoSize = true;
            lb_dtLocacao.Location = new Point(20, 60);

            txtidCliente = new TextBox();
            txtidCliente.Location = new Point(180, 20);
            txtidCliente.Size = new Size(220, 18);

            txtidFilme = new TextBox();
            txtidFilme.Location = new Point(180, 60);
            txtidFilme.Size = new Size(100, 18);

            txtDtLocacao = new TextBox();
            txtDtLocacao.Location = new Point(180, 60);
            txtDtLocacao.Size = new Size(100, 18);

            btnConfirmar = new Button();
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.Size = new Size(100, 30);
            btnConfirmar.Location = new Point(180, 260);
            btnConfirmar.Click += new EventHandler(this.btnConfirmarClick);

            btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Size = new Size(100, 30);
            btnCancelar.Location = new Point(300, 260);
            btnCancelar.Click += new EventHandler(this.btnCancelarClick);

            this.Controls.Add(lb_idClinte);
            this.Controls.Add(lb_idFilme);
            this.Controls.Add(lb_dtLocacao);
            this.Controls.Add(txtidCliente);
            this.Controls.Add(txtidFilme);
            this.Controls.Add(txtDtLocacao);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
            this.Size = new Size(1000, 450);
        }

        private void btnConfirmarClick(object sender, EventArgs e)
        {
            try
            {
                LocacaoController.CadastrarLocacao(this.txtidCliente, this.txtDtLocacao.Text);
                MessageBox.Show(
                $"ID Locacao: {txtidCliente.Text}\n" +
                $"ID Filme: {txtidFilme.Text}\n" +
                $"Data Locacao: {txtDtLocacao.Text}\n",
                "Locacao",
                MessageBoxButtons.OK
            );
                this.Close();
                this.parent.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarClick(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }
    }
}