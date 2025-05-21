using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PIM_3.model;

public partial class EmprestimoForm : Form
{
    private List<Livros> livros;
    private List<Leitores> leitores;
    private List<Emprestimo> emprestimos;

    private MaskedTextBox txtCpf;
    private TextBox txtIsbn;
    private Button btnEmprestar;
    private Label lblMensagem;
    private Button btnFechar;

    public EmprestimoForm(List<Livros> livros, List<Leitores> leitores, List<Emprestimo> emprestimos)
    {
        InitializeComponent();
        this.livros = livros;
        this.leitores = leitores;
        this.emprestimos = emprestimos;
    }

    private void InitializeComponent()
    {
        this.txtCpf = new MaskedTextBox();
        this.txtCpf.Mask = "000.000.000-00";
        this.txtCpf.Location = new Point(30, 30);
        this.txtCpf.Name = "txtCpf";
        this.txtCpf.Size = new Size(200, 23);

        this.txtIsbn = new TextBox();
        this.txtIsbn.Location = new Point(30, 70);
        this.txtIsbn.Name = "txtIsbn";
        this.txtIsbn.PlaceholderText = "ISBN do Livro";
        this.txtIsbn.Size = new Size(200, 23);

        this.btnEmprestar = new Button();
        this.btnEmprestar.Location = new Point(30, 110);
        this.btnEmprestar.Name = "btnEmprestar";
        this.btnEmprestar.Size = new Size(200, 30);
        this.btnEmprestar.Text = "Realizar Empréstimo";
        this.btnEmprestar.Click += new EventHandler(this.btnEmprestar_Click);

        // Agora o botão "Fechar" fica logo abaixo do botão "Realizar Empréstimo"
        this.btnFechar = new Button();
        this.btnFechar.Text = "Fechar";
        this.btnFechar.Location = new Point(30, 150); // mais próximo do btnEmprestar
        this.btnFechar.Size = new Size(200, 30);
        this.btnFechar.Click += new EventHandler(btnFechar_Click);

        // A label de mensagem fica agora por último, abaixo de tudo
        this.lblMensagem = new Label();
        this.lblMensagem.Location = new Point(30, 190);
        this.lblMensagem.Size = new Size(300, 40);
        this.lblMensagem.ForeColor = Color.Red;

        this.ClientSize = new Size(350, 250); // aumente se necessário
        this.Controls.Add(this.txtCpf);
        this.Controls.Add(this.txtIsbn);
        this.Controls.Add(this.btnEmprestar);
        this.Controls.Add(this.btnFechar);
        this.Controls.Add(this.lblMensagem);
        this.Name = "TelaEmprestimo";
        this.Text = "Empréstimo de Livro";
    }

    private void btnEmprestar_Click(object sender, EventArgs e)
    {
        if (!txtCpf.MaskCompleted)
        {
            lblMensagem.ForeColor = Color.Red;
            lblMensagem.Text = "CPF incompleto. Use o formato 000.000.000-00.";
            return;
        }

        string cpfDigitado = txtCpf.Text.Replace(".", "").Replace("-", "").Trim();

        Leitores leitor = leitores.Find(l => l.Cpf.Replace(".", "").Replace("-", "").Trim() == cpfDigitado);
        if (leitor == null)
        {
            lblMensagem.ForeColor = Color.Red;
            lblMensagem.Text = "Leitor não encontrado.";
            return;
        }

        string isbn = txtIsbn.Text.Trim();
        Livros livro = livros.Find(l => l.ISBN == isbn);
        if (livro == null)
        {
            lblMensagem.ForeColor = Color.Red;
            lblMensagem.Text = "Livro não encontrado.";
            return;
        }

        if (!livro.Disponivel)
        {
            lblMensagem.ForeColor = Color.Red;
            lblMensagem.Text = "Livro indisponível.";
            return;
        }

        Emprestimo emprestimo = new Emprestimo
        {
            CpfLeitor = leitor.Cpf,
            ISBN = livro.ISBN,
            Data = DateTime.Now
        };

        livro.Disponivel = false;
        emprestimos.Add(emprestimo);

        lblMensagem.ForeColor = Color.Green;
        lblMensagem.Text = "Empréstimo registrado com sucesso!";
    }

    private void btnFechar_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
