using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PIM_3.model;

public class LeitorCadastroForm : Form
{
    private List<Leitores> leitores;

    private TextBox txtNome;
    private MaskedTextBox txtCpf;
    private TextBox txtEmail;
    private Button btnCadastrar;
    private Label lblMensagem;
    private Button btnFechar;

    public LeitorCadastroForm(List<Leitores> leitores)
    {
        this.leitores = leitores;
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.txtNome = new TextBox();
        this.txtCpf = new MaskedTextBox();
        this.txtEmail = new TextBox();
        this.btnCadastrar = new Button();
        this.lblMensagem = new Label();

        this.txtNome.Location = new Point(30, 20);
        this.txtNome.Size = new Size(200, 23);
        this.txtNome.PlaceholderText = "Nome";

        this.txtCpf.Location = new Point(30, 60);
        this.txtCpf.Size = new Size(200, 23);
        this.txtCpf.Mask = "000.000.000-00";

        this.txtEmail.Location = new Point(30, 100);
        this.txtEmail.Size = new Size(200, 23);
        this.txtEmail.PlaceholderText = "Email";

        this.btnCadastrar.Text = "Cadastrar Leitor";
        this.btnCadastrar.Location = new Point(30, 140);
        this.btnCadastrar.Size = new Size(200, 30);
        this.btnCadastrar.Click += new EventHandler(this.btnCadastrar_Click);

        // Botão Fechar
        btnFechar = new Button();
        btnFechar.Text = "Fechar";
        this.btnFechar.Location = new Point(30, 200);
        this.btnFechar.Size = new Size(200, 30);
        btnFechar.Click += new EventHandler(btnFechar_Click);
        this.Controls.Add(btnFechar);

        this.lblMensagem.Location = new Point(30, 180);
        this.lblMensagem.Size = new Size(300, 40);
        this.lblMensagem.ForeColor = Color.Red;

        this.ClientSize = new Size(350, 250);
        this.Controls.Add(this.txtNome);
        this.Controls.Add(this.txtCpf);
        this.Controls.Add(this.txtEmail);
        this.Controls.Add(this.btnCadastrar);
        this.Controls.Add(this.lblMensagem);
        this.Text = "Cadastro de Leitor";
    }

    private void btnCadastrar_Click(object sender, EventArgs e)
    {
        string nome = txtNome.Text.Trim();
        string email = txtEmail.Text.Trim();

        if (!txtCpf.MaskCompleted)
        {
            lblMensagem.Text = "CPF incompleto ou inválido.";
            return;
        }

        string cpf = txtCpf.Text.Replace(".", "").Replace("-", "").Trim();

        if (!email.Contains("@") || !email.Contains("."))
        {
            lblMensagem.Text = "Email inválido.";
            return;
        }

        leitores.Add(new Leitores
        {
            NomeLeitor = nome,
            Cpf = cpf,
            Email = email
        });

        lblMensagem.ForeColor = Color.Green;
        lblMensagem.Text = "Leitor cadastrado com sucesso!";
        ClearForm();
    }
    private void ClearForm()
    {
        txtNome.Text = "";
        txtCpf.Text = "";
        txtEmail.Text = "";
    }

    private void btnFechar_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
