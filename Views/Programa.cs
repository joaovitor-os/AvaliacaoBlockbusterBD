using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace InterfaceFaseUm
{
    static class Programa
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Tela());
        }
    }

    public class Tela : Form
    {
        Button btnCadastrarCliente;
        Button btnCadastrarFilme;
        Button btnCadastrarLocacao;
        Button btnConsultarCliente;
        Button btnConsultarFilme;
        Button btnConsultarLocacao;
        Button btnListarCliente;
        Button btnListarFilme;
        Button btnSair;

        public Tela()
        {
            this.Text = "Locadora";
            this.BackColor = Color.Azure;

            btnCadastrarCliente = new Button();
            btnCadastrarCliente.Text = "Cadastrar Cliente";
            btnCadastrarCliente.Size = new Size(100, 30);
            btnCadastrarCliente.Location = new Point(40, 40);
            btnCadastrarCliente.Click += new EventHandler(this.btnCadastrarClienteClick);

            btnCadastrarFilme = new Button();
            btnCadastrarFilme.Text = "Cadastrar Filme";
            btnCadastrarFilme.Size = new Size(100, 30);
            btnCadastrarFilme.Location = new Point(40, 80);
            btnCadastrarFilme.Click += new EventHandler(this.btnCadastrarFilmeClick);

            btnCadastrarLocacao = new Button();
            btnCadastrarLocacao.Text = "Cadastrar Locacao";
            btnCadastrarLocacao.Size = new Size(100, 30);
            btnCadastrarLocacao.Location = new Point(40, 120);
            btnCadastrarLocacao.Click += new EventHandler(this.btnCadastrarLocacaoClick);

            btnConsultarCliente = new Button();
            btnConsultarCliente.Text = "Consultar Cliente";
            btnConsultarCliente.Size = new Size(100, 30);
            btnConsultarCliente.Location = new Point(40, 160);
            btnConsultarCliente.Click += new EventHandler(this.btnConsultarClienteClick);

            btnConsultarFilme = new Button();
            btnConsultarFilme.Text = "Cadastrar Filme";
            btnConsultarFilme.Size = new Size(100, 30);
            btnConsultarFilme.Location = new Point(40, 200);
            btnConsultarFilme.Click += new EventHandler(this.btnConsultarFilmeClick);

            btnConsultarLocacao = new Button();
            btnConsultarLocacao.Text = "Consultar Locacao";
            btnConsultarLocacao.Size = new Size(100, 30);
            btnConsultarLocacao.Location = new Point(40, 240);
            btnConsultarLocacao.Click += new EventHandler(this.btnConsultarLocacaoClick);

            btnListarCliente = new Button();
            btnListarCliente.Text = "Listar Cliente";
            btnListarCliente.Size = new Size(100, 30);
            btnListarCliente.Location = new Point(40, 280);
            btnListarCliente.Click += new EventHandler(this.btnListarClienteClick);

            btnListarFilme = new Button();
            btnListarFilme.Text = "Listar Filme";
            btnListarFilme.Size = new Size(100, 30);
            btnListarFilme.Location = new Point(40, 320);
            btnListarFilme.Click += new EventHandler(this.btnListarFilmeClick);

            btnSair = new Button();
            btnSair.Text = "Sair";
            btnSair.Size = new Size(100, 30);
            btnSair.Location = new Point(300, 360);
            btnSair.Click += new EventHandler(this.btnSairClick);

            this.Controls.Add(btnCadastrarCliente);
            this.Controls.Add(btnCadastrarFilme);
            this.Controls.Add(btnCadastrarLocacao);
            this.Controls.Add(btnConsultarCliente);
            this.Controls.Add(btnConsultarFilme);
            this.Controls.Add(btnConsultarLocacao);
            this.Controls.Add(btnListarCliente);
            this.Controls.Add(btnListarFilme);
            this.Controls.Add(btnSair);
            this.Size = new Size(450, 450);
        }

        public void btnCadastrarClienteClick(object sender, EventArgs e)
        {
            CadastrarCliente cadastrarCliente = new CadastrarCliente(this);
            cadastrarCliente.Show();
            this.Hide();
        }

        public void btnCadastrarFilmeClick(object sender, EventArgs e)
        {
            CadastrarFilme cadastrarFilme = new CadastrarFilme(this);
            cadastrarFilme.Show();
            this.Hide();
        }

        public void btnCadastrarLocacaoClick(object sender, EventArgs e)
        {
            CadastrarLocacao cadastrarLocacao = new CadastrarLocacao(this);
            cadastrarLocacao.Show();
            this.Hide();
        }

        public void btnConsultarClienteClick(object sender, EventArgs e)
        {
            ConsultarCliente consultarCliente = new ConsultarCliente(this);
            consultarCliente.Show();
            this.Hide();
        }

        public void btnConsultarFilmeClick(object sender, EventArgs e)
        {
            ConsultarFilme consultarFilme = new ConsultarFilme(this);
            consultarFilme.Show();
            this.Hide();
        }

        public void btnConsultarLocacaoClick(object sender, EventArgs e)
        {
            ConsultarLocacao consultarLocacao = new ConsultarLocacao(this);
            consultarLocacao.Show();
            this.Hide();
        }

        public void btnListarClienteClick(object sender, EventArgs e)
        {
            ListarCliente listarCliente = new ListarCliente(this);
            listarCliente.Show();
            this.Hide();
        }

        public void btnListarFilmeClick(object sender, EventArgs e)
        {
            ListarFilme listarFilme = new ListarFilme(this);
            listarFilme.Show();
            this.Hide();
        }

        private void btnSairClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}