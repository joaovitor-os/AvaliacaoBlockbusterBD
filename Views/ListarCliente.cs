using System;
using System.Collections.Generic;
using Controllers;
using Models;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace InterfaceFaseUm
{
    public class ListarCliente : Form
    {

        Form parent;
        ListView lvListaCliente;
        Button btnSair;

        public ListarCliente(Form parent)
        {
            this.parent = parent;

            this.Text = "Lista Cliente";
            this.BackColor = Color.Azure;

            lvListaCliente = new ListView();
            lvListaCliente.Location = new Point(20, 100);
            lvListaCliente.Size = new Size(440, 400);
            lvListaCliente.View = View.Details;
            ListViewItem clientes = new ListViewItem();
            foreach (Cliente cliente in ClienteController.GetClientes())
            {
                ListViewItem lvListaClientes = new ListViewItem(cliente.ClienteId.ToString());
                lvListaClientes.SubItems.Add(cliente.Nome);
                lvListaClientes.SubItems.Add(cliente.Cpf);
                lvListaClientes.SubItems.Add(cliente.DiasPDevolucao.ToString());
                lvListaCliente.Items.Add(lvListaClientes);
            }
            lvListaCliente.FullRowSelect = true;
            lvListaCliente.GridLines = true;
            lvListaCliente.AllowColumnReorder = true;
            lvListaCliente.Sorting = SortOrder.Ascending;
            lvListaCliente.Columns.Add("ID", -2, HorizontalAlignment.Center);
            lvListaCliente.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            lvListaCliente.Columns.Add("CPF", -2, HorizontalAlignment.Center);
            lvListaCliente.Columns.Add("Dias Devolução", -2, HorizontalAlignment.Center);
            this.Controls.Add(lvListaCliente);

            btnSair = new Button();
            btnSair.Text = "Sair";
            btnSair.Size = new Size(100, 30);
            btnSair.Location = new Point(300, 260);
            btnSair.Click += new EventHandler(this.btnSairClick);

            this.Controls.Add(lvListaCliente);
            this.Controls.Add(btnSair);
            this.Size = new Size(1000, 450);
        }

        private void btnSairClick(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }
    }
}