using System;
using System.Collections.Generic;
using Controllers;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace InterfaceFaseUm
{
    public class CadastrarFilme : Form
    {

        Form parent;
        Label lb_nomeFilme;
        Label lb_DtLancamento;
        Label lb_Sinopse;
        Label lb_Valor;
        Label lb_QntEstoque;

        TextBox txtnomeFilme;
        TextBox txtDtLancamento;
        TextBox txtSinopse;

        NumericUpDown numValor;
        NumericUpDown numQntEstoque;

        Button btnConfirmar;
        Button btnCancelar;

        public CadastrarFilme(Form parent)
        {
            this.Text = "Cadastro Filme";
            this.BackColor = Color.Azure;

            lb_nomeFilme = new Label();
            lb_nomeFilme.Text = "Nome do Filme: ";
            lb_nomeFilme.Location = new Point(20, 20);

            lb_DtLancamento = new Label();
            lb_DtLancamento.Text = "Data de Lançamento: ";
            lb_DtLancamento.AutoSize = true;
            lb_DtLancamento.Location = new Point(20, 60);

            lb_Sinopse = new Label();
            lb_Sinopse.Text = "Sinopse: ";
            lb_Sinopse.Location = new Point(20, 100);

            lb_Valor = new Label();
            lb_Valor.Text = "Valor: ";
            lb_Valor.Location = new Point(20, 100);

            lb_QntEstoque = new Label();
            lb_QntEstoque.Text = "Quantidade Estoque: ";
            lb_QntEstoque.AutoSize = true;
            lb_QntEstoque.Location = new Point(20, 140);

            txtnomeFilme = new TextBox();
            txtnomeFilme.Location = new Point(180, 20);
            txtnomeFilme.Size = new Size(220, 18);

            txtDtLancamento = new TextBox();
            txtDtLancamento.Location = new Point(180, 60);
            txtDtLancamento.Size = new Size(100, 18);

            txtSinopse = new TextBox();
            txtSinopse.Location = new Point(180, 60);
            txtSinopse.Size = new Size(100, 18);

            numValor = new NumericUpDown();
            numValor.Location = new Point(180, 100);
            numValor.Size = new Size(100, 18);
            numValor.Maximum = 10;
            numValor.Minimum = 2;
            numValor.ReadOnly = true;
            this.Controls.Add(numValor);

            numQntEstoque = new NumericUpDown();
            numQntEstoque.Location = new Point(130, 110);
            numQntEstoque.Size = new Size(110, 20);
            numQntEstoque.Maximum = 5;
            numQntEstoque.Minimum = 1;
            numQntEstoque.ReadOnly = true;
            this.Controls.Add(numQntEstoque);

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

            this.Controls.Add(lb_nomeFilme);
            this.Controls.Add(lb_DtLancamento);
            this.Controls.Add(lb_Sinopse);
            this.Controls.Add(lb_Valor);
            this.Controls.Add(lb_QntEstoque);
            this.Controls.Add(txtnomeFilme);
            this.Controls.Add(txtDtLancamento);
            this.Controls.Add(txtSinopse);
            this.Controls.Add(numValor);
            this.Controls.Add(numQntEstoque);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
            this.Size = new Size(1000, 450);
        }

        private void btnConfirmarClick(object sender, EventArgs e)
        {
            try
            {
                FilmeController.CadastrarFilme(this.txtnomeFilme.Text, this.txtDtLancamento.Text, this.txtSinopse.Text, (double)this.numValor.Value, (int)this.numQntEstoque.Value);
                MessageBox.Show(
                $"Nome: {txtnomeFilme.Text}\n" +
                $"Data Lançamento: {txtDtLancamento.Text}\n" +
                $"Sinopse: {txtSinopse.Text}\n" +
                $"Valor: {numValor.Value}\n" +
                $"Estoque: {numQntEstoque.Value}\n",
                "Filme",
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