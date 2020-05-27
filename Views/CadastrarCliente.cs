using System;
using System.Collections.Generic;
using Controllers;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace InterfaceFaseUm
{
    public class CadastrarCliente : Form
    {

        Form parent;
        Label lb_nome;
        Label lb_Dtnasc;
        Label lb_CPF;
        Label lb_Diaspdev;

        TextBox txtNome;
        TextBox txtDtnasc;

        MaskedTextBox txtCPF;

        NumericUpDown numDiasdev;

        Button btnConfirmar;
        Button btnCancelar;

        public CadastrarCliente(Form parent)
        {
            this.parent = parent;

            this.Text = "Cadastro Cliente";
            this.BackColor = Color.Azure;

            lb_nome = new Label();
            lb_nome.Text = "Nome: ";
            lb_nome.Location = new Point(20, 20);

            lb_Dtnasc = new Label();
            lb_Dtnasc.Text = "Data de Nascimento: ";
            lb_Dtnasc.AutoSize = true;
            lb_Dtnasc.Location = new Point(20, 60);

            lb_CPF = new Label();
            lb_CPF.Text = "CPF: ";
            lb_CPF.Location = new Point(20, 100);

            lb_Diaspdev = new Label();
            lb_Diaspdev.Text = "Dias de Devolução: ";
            lb_Diaspdev.AutoSize = true;
            lb_Diaspdev.Location = new Point(20, 140);

            txtNome = new TextBox();
            txtNome.Location = new Point(180, 20);
            txtNome.Size = new Size(220, 18);

            txtDtnasc = new TextBox();
            txtDtnasc.Location = new Point(180, 60);
            txtDtnasc.Size = new Size(100, 18);

            txtCPF = new MaskedTextBox();
            txtCPF.Location = new Point(180, 100);
            txtCPF.Size = new Size(100, 18);
            txtCPF.Mask = "000,000,000-00";

            numDiasdev = new NumericUpDown();
            numDiasdev.Location = new Point(130, 110);
            numDiasdev.Size = new Size(110, 20);
            numDiasdev.Maximum = 20;
            numDiasdev.Minimum = 5;
            numDiasdev.Increment = 5;
            numDiasdev.ReadOnly = true;
            this.Controls.Add(numDiasdev);

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

            this.Controls.Add(lb_nome);
            this.Controls.Add(lb_Dtnasc);
            this.Controls.Add(lb_CPF);
            this.Controls.Add(lb_Diaspdev);
            this.Controls.Add(txtNome);
            this.Controls.Add(txtDtnasc);
            this.Controls.Add(txtCPF);
            this.Controls.Add(numDiasdev);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
            this.Size = new Size(1000, 450);
        }

        private void btnConfirmarClick(object sender, EventArgs e)
        {
            try
            {
                ClienteController.CadastrarCliente(this.txtNome.Text, this.txtDtnasc.Text, this.txtCPF.Text, (int)this.numDiasdev.Value);
                MessageBox.Show(
                $"Nome: {txtNome.Text}\n" +
                $"Data Nasci: {txtDtnasc.Text}\n" +
                $"C.P.F: {txtCPF.Text}\n" +
                $"Dias Dev: {numDiasdev.Value}\n",
                "Cliente",
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