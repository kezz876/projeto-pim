using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PIM_3.model;

namespace PIM_3.Forms
{
    public partial class MenuForm : Form
    {
        private Admin admin;
        private List<Livros> livros;
        private List<Leitores> leitores;
        private List<Emprestimo> emprestimos;


        // Elementos da Interface
        private Button btnCadastrarLivro;
        private Button btnEmprestarLivro;
        private Button btnConsultarLivros;
        private Button btnVerificarDisponibilidade;
        private Button btnRegistrarDevolucao;
        private Button btnCadastrarLeitor;
        private Button btnSair;

        public MenuForm(Admin admin, List<Livros> livros)
        {
            this.admin = admin;
            this.livros = livros;
            this.leitores = new List<Leitores>();        // <--- INICIALIZA AQUI
            this.emprestimos = new List<Emprestimo>();   // <--- INICIALIZA AQUI
            InitializeComponent();
        }


        private void InitializeComponent()
        {
            this.btnCadastrarLivro = new Button();
            this.btnEmprestarLivro = new Button();
            this.btnConsultarLivros = new Button();
            this.btnVerificarDisponibilidade = new Button();
            this.btnRegistrarDevolucao = new Button();
            this.btnCadastrarLeitor = new Button();
            this.btnSair = new Button();

            this.SuspendLayout();

            // Botão Cadastrar Livro
            this.btnCadastrarLivro.Text = "Cadastrar Livro";
            this.btnCadastrarLivro.Location = new System.Drawing.Point(50, 30);
            this.btnCadastrarLivro.Size = new System.Drawing.Size(200, 30);
            this.btnCadastrarLivro.Click += new EventHandler(this.BtnCadastrarLivro_Click);

            // Botão Emprestar Livro
            this.btnEmprestarLivro.Text = "Emprestar Livro";
            this.btnEmprestarLivro.Location = new System.Drawing.Point(50, 70);
            this.btnEmprestarLivro.Size = new System.Drawing.Size(200, 30);
            this.btnEmprestarLivro.Click += new EventHandler(this.btnEmprestarLivro_Click);

            // Botão Consultar Livros
            this.btnConsultarLivros.Text = "Consultar Livros";
            this.btnConsultarLivros.Location = new System.Drawing.Point(50, 110);
            this.btnConsultarLivros.Size = new System.Drawing.Size(200, 30);
            this.btnConsultarLivros.Click += new EventHandler(this.btnConsultarLivros_Click);

            // Botão Verificar Disponibilidade
            this.btnVerificarDisponibilidade.Text = "Verificar Disponibilidade";
            this.btnVerificarDisponibilidade.Location = new System.Drawing.Point(50, 150);
            this.btnVerificarDisponibilidade.Size = new System.Drawing.Size(200, 30);
            this.btnVerificarDisponibilidade.Click += new EventHandler(this.btnVerificarDisponibilidade_Click);

            // Botão Registrar Devolução
            this.btnRegistrarDevolucao.Text = "Registrar Devolução";
            this.btnRegistrarDevolucao.Location = new System.Drawing.Point(50, 190);
            this.btnRegistrarDevolucao.Size = new System.Drawing.Size(200, 30);
            this.btnRegistrarDevolucao.Click += new EventHandler(this.btnRegistrarDevolucao_Click);

            // Botão Registrar Leitor
            this.btnCadastrarLeitor.Text = "Registrar Leitor";
            this.btnCadastrarLeitor.Location = new System.Drawing.Point(50, 230);
            this.btnCadastrarLeitor.Size = new System.Drawing.Size(200, 30);
            this.btnCadastrarLeitor.Click += new EventHandler(this.btnCadastrarLeitor_Click);

            // Botão Sair
            this.btnSair.Text = "Sair";
            this.btnSair.Location = new System.Drawing.Point(50, 270);
            this.btnSair.Size = new System.Drawing.Size(200, 30);
            this.btnSair.Click += new EventHandler(this.btnSair_Click);

            // Configuração do Formulário
            this.ClientSize = new System.Drawing.Size(300, 350);
            this.Controls.Add(this.btnCadastrarLivro);
            this.Controls.Add(this.btnEmprestarLivro);
            this.Controls.Add(this.btnConsultarLivros);
            this.Controls.Add(this.btnVerificarDisponibilidade);
            this.Controls.Add(this.btnRegistrarDevolucao);
            this.Controls.Add(this.btnCadastrarLeitor);
            this.Controls.Add(this.btnSair);
            this.Name = "MenuForm";
            this.Text = "Menu Principal";
            this.ResumeLayout(false);
        }

        private void BtnCadastrarLivro_Click(object sender, EventArgs e)
        {
            var form = new CadastrarLivroForm(livros);
            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Livro cadastrado com sucesso!");
            }
        }

        private void btnEmprestarLivro_Click(object sender, EventArgs e)
        {
            EmprestimoForm tela = new EmprestimoForm(livros, leitores, emprestimos);
            tela.ShowDialog();
        }

        private void btnConsultarLivros_Click(object sender, EventArgs e)
        {
            var formLivros = new FormLivros(livros); // Passa a lista
            formLivros.ShowDialog(); // Abre a nova janela
        }


        private void btnVerificarDisponibilidade_Click(object sender, EventArgs e)
        {
            using (InputIsbnForm form = new InputIsbnForm())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string isbn = form.IsbnDigitado;

                    Pendentes pendentes = new Pendentes();
                    string resultado = pendentes.VerificarDisponibilidadeLivro(isbn, livros);

                    MessageBox.Show(resultado, "Resultado da Verificação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Se cancelar, nada acontece (fecha normalmente)
            }
        }

        private void btnRegistrarDevolucao_Click(object sender, EventArgs e)
        {
            string isbnDevolucao = Microsoft.VisualBasic.Interaction.InputBox("Digite o ISBN do livro que deseja devolver:", "Registrar Devolução");
            Pendentes pendentes = new Pendentes();
            pendentes.RealizarDevolucaoPorISBN(isbnDevolucao, livros);
        }

        private void btnCadastrarLeitor_Click(object sender, EventArgs e)
        {
            LeitorCadastroForm cadastroForm = new LeitorCadastroForm(leitores);
            cadastroForm.ShowDialog(); // ou .Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Fecha a aplicação
        }
    }
}
