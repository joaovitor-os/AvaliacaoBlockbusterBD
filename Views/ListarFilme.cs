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
    public class ListarFilme : Form
    {

        Form parent;
        ListView lvListaFilme;
        Button btnSair;

        public ListarFilme(Form parent)
        {
            this.parent = parent;

            this.Text = "Lista Filme";
            this.BackColor = Color.Azure;

            lvListaFilme = new ListView();
            lvListaFilme.Location = new Point(20, 100);
            lvListaFilme.Size = new Size(440, 400);
            lvListaFilme.View = View.Details;
            ListViewItem filmes = new ListViewItem();
            foreach (Filme filme in FilmeController.GetFilmes())
            {
                ListViewItem lvListaFilmes = new ListViewItem(filme.FilmeId.ToString());
                lvListaFilmes.SubItems.Add(filme.NomeFilme);
                lvListaFilmes.SubItems.Add(filme.Sinopse);
                lvListaFilmes.SubItems.Add(filme.Valor.ToString());
                lvListaFilme.Items.Add(lvListaFilmes);
            }
            lvListaFilme.FullRowSelect = true;
            lvListaFilme.GridLines = true;
            lvListaFilme.AllowColumnReorder = true;
            lvListaFilme.Sorting = SortOrder.Ascending;
            lvListaFilme.Columns.Add("ID", -2, HorizontalAlignment.Center);
            lvListaFilme.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            lvListaFilme.Columns.Add("Sinopse", -2, HorizontalAlignment.Left);
            lvListaFilme.Columns.Add("Valor", -2, HorizontalAlignment.Center);
            this.Controls.Add(lvListaFilme);

            btnSair = new Button();
            btnSair.Text = "Sair";
            btnSair.Size = new Size(100, 30);
            btnSair.Location = new Point(300, 260);
            btnSair.Click += new EventHandler(this.btnSairClick);

            this.Controls.Add(lvListaFilme);
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