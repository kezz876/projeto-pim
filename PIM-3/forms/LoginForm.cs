using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PIM_3.model;

namespace PIM_3.Forms
{
    public partial class LoginForm : Form
    {

        private Admin admin;
        private List<Livros> livros;
        private TextBox txtUsuario;
        private TextBox txtSenha;
        private Button btnLogin;
        private Label lblUsuario;
        private Label lblSenha;

        private void InitializeComponent()
        {
            this.txtUsuario = new TextBox();
            this.txtSenha = new TextBox();
            this.btnLogin = new Button();
            this.lblUsuario = new Label();
            this.lblSenha = new Label();
            this.SuspendLayout();

            // Label Usuario
            this.lblUsuario.Text = "Usuário:";
            this.lblUsuario.Location = new System.Drawing.Point(30, 30);
            this.lblUsuario.Size = new System.Drawing.Size(60, 20);

            // TextBox Usuario
            this.txtUsuario.Location = new System.Drawing.Point(100, 25);
            this.txtUsuario.Size = new System.Drawing.Size(150, 20);

            // Label Senha
            this.lblSenha.Text = "Senha:";
            this.lblSenha.Location = new System.Drawing.Point(30, 70);
            this.lblSenha.Size = new System.Drawing.Size(60, 20);

            // TextBox Senha
            this.txtSenha.Location = new System.Drawing.Point(100, 65);
            this.txtSenha.Size = new System.Drawing.Size(150, 20);
            this.txtSenha.UseSystemPasswordChar = true;

            // Button Login
            this.btnLogin.Text = "Login";
            this.btnLogin.Location = new System.Drawing.Point(100, 110);
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // Form Login
            this.ClientSize = new System.Drawing.Size(280, 180);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.btnLogin);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string nome = txtUsuario.Text;
            string senha = txtSenha.Text;

            if (!admin.VerifLogin(nome, senha))
            {
                MessageBox.Show("Nome de usuário ou senha incorretos.");
                return;
            }

            MessageBox.Show("Login realizado com sucesso!");

            MenuForm menuForm = new MenuForm(admin, livros);
            menuForm.Show();
            this.Hide(); // Esconde a tela de login
        }

        public LoginForm(Admin admin, List<Livros> livros)
        {
            this.admin = admin;
            this.livros = livros;
            InitializeComponent();
        }

        private void RodarMenu()
        {
            MenuForm menuForm = new MenuForm(admin, livros);
            menuForm.Show();
            this.Hide(); // Oculta o formulário de login

        }

    }
}