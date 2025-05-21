using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PIM_3.model;
using System.ComponentModel;
using System.Linq;

namespace PIM_3.Forms
{
    public partial class CadastrarLivroForm : Form
    {
        private List<Livros> livros;

        public CadastrarLivroForm(List<Livros> livros)
        {
            this.livros = livros;
            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Livros LivroCadastrado { get; private set; }

        private TextBox txtNome;
        private TextBox txtAutor;
        private TextBox txtGenero;
        private TextBox txtAno;
        private Button btnSalvar;
        private Button btnCopiarISBN;
        private Button btnFechar;
        private Label lblISBN;

        public CadastrarLivroForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtNome = new TextBox();
            this.txtAutor = new TextBox();
            this.txtGenero = new TextBox();
            this.txtAno = new TextBox();
            this.btnSalvar = new Button();

            // lblISBN
            this.lblISBN = new Label();
            this.lblISBN.Location = new System.Drawing.Point(30, 220);
            this.lblISBN.Size = new System.Drawing.Size(200, 20);
            this.lblISBN.Visible = false;

            // btnCopiarISBN
            this.btnCopiarISBN = new Button();
            this.btnCopiarISBN.Text = "Copiar ISBN";
            this.btnCopiarISBN.Location = new System.Drawing.Point(30, 250);
            this.btnCopiarISBN.Click += new EventHandler(this.btnCopiarISBN_Click);
            this.btnCopiarISBN.Visible = false;

            // btnFechar
            this.btnFechar = new Button();
            this.btnFechar.Text = "Fechar";
            this.btnFechar.Location = new System.Drawing.Point(150, 250);
            this.btnFechar.Click += new EventHandler(this.btnFechar_Click);
            this.btnFechar.Visible = false;

            this.SuspendLayout();

            // txtNome
            this.txtNome.PlaceholderText = "Nome do Livro";
            this.txtNome.Location = new System.Drawing.Point(30, 20);
            this.txtNome.Width = 200;

            // txtAutor
            this.txtAutor.PlaceholderText = "Autor";
            this.txtAutor.Location = new System.Drawing.Point(30, 60);
            this.txtAutor.Width = 200;

            // txtGenero
            this.txtGenero.PlaceholderText = "Gênero";
            this.txtGenero.Location = new System.Drawing.Point(30, 100);
            this.txtGenero.Width = 200;

            // txtAno
            this.txtAno.PlaceholderText = "Ano";
            this.txtAno.Location = new System.Drawing.Point(30, 140);
            this.txtAno.Width = 200;

            // btnSalvar
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Location = new System.Drawing.Point(30, 180);
            this.btnSalvar.Click += new EventHandler(this.btnSalvar_Click);

            // Formulário
            this.ClientSize = new System.Drawing.Size(270, 300);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtAutor);
            this.Controls.Add(this.txtGenero);
            this.Controls.Add(this.txtAno);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.lblISBN);
            this.Controls.Add(this.btnCopiarISBN);
            this.Controls.Add(this.btnFechar);
            this.Text = "Cadastrar Livro";

            this.ResumeLayout(false);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                string.IsNullOrWhiteSpace(txtAutor.Text) ||
                string.IsNullOrWhiteSpace(txtGenero.Text) ||
                !int.TryParse(txtAno.Text, out int ano))
            {
                MessageBox.Show("Preencha todos os campos corretamente.");
                return;
            }

            // Verificação de duplicidade (por nome, ignorando maiúsculas/minúsculas e espaços extras)
            string nomeLivro = txtNome.Text.Trim().ToLower();

            bool jaExiste = livros.Any(l =>
                l.NomeLivro.Trim().ToLower().Contains(nomeLivro) ||
                nomeLivro.Contains(l.NomeLivro.Trim().ToLower()));

            if (jaExiste)
            {
                MessageBox.Show("Livro já cadastrado! Verifique o nome informado.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cadastro do livro
            LivroCadastrado = new Livros
            {
                NomeLivro = txtNome.Text,
                Autor = txtAutor.Text,
                Genero = txtGenero.Text,
                Ano = ano,
                Disponivel = true,
                ISBN = GerarISBN13()
            };

            // Adiciona à lista
            livros.Add(LivroCadastrado);

            MessageBox.Show($"Livro cadastrado com ISBN: {LivroCadastrado.ISBN}");

            // Mostrar ISBN e botões
            lblISBN.Text = $"ISBN: {LivroCadastrado.ISBN}";
            lblISBN.Visible = true;
            btnCopiarISBN.Visible = true;
            btnFechar.Visible = true;

            // Limpar campos e desabilitar salvar
            txtNome.Text = "";
            txtAutor.Text = "";
            txtGenero.Text = "";
            txtAno.Text = "";
            btnSalvar.Enabled = false;
        }

        private string GerarISBN13()
        {
            Random rand = new Random();
            string isbn = "";
            for (int i = 0; i < 13; i++)
            {
                isbn += rand.Next(0, 10).ToString();
            }
            return isbn;
        }

        private void btnCopiarISBN_Click(object sender, EventArgs e)
        {
            if (LivroCadastrado != null)
            {
                Clipboard.SetText(LivroCadastrado.ISBN);
                MessageBox.Show("ISBN copiado para a área de transferência!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
