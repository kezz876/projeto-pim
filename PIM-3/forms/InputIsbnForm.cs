using System;
using System.Windows.Forms;
using System.ComponentModel;

public class InputIsbnForm : Form
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string IsbnDigitado { get; private set; }

    private TextBox txtIsbn;
    private Button btnOk;
    private Button btnCancelar;
    private Label lblMensagem;
    private Label lblInstrucao;

    public InputIsbnForm()
    {
        this.Text = "Verificar Disponibilidade";
        this.Size = new Size(450, 180);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterParent;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        lblInstrucao = new Label();
        lblInstrucao.Text = "Digite o ISBN do livro que deseja verificar a disponibilidade:";
        lblInstrucao.Location = new System.Drawing.Point(20, 20);
        lblInstrucao.AutoSize = true;

        txtIsbn = new TextBox();
        txtIsbn.Location = new System.Drawing.Point(20, 50);
        txtIsbn.Width = 400;

        lblMensagem = new Label();
        lblMensagem.ForeColor = System.Drawing.Color.Red;
        lblMensagem.AutoSize = true;
        lblMensagem.Location = new System.Drawing.Point(20, 80);

        btnOk = new Button();
        btnOk.Text = "OK";
        btnOk.Size = new System.Drawing.Size(100, 30);
        btnOk.Location = new System.Drawing.Point(220, 110);
        btnOk.Click += BtnOk_Click;

        btnCancelar = new Button();
        btnCancelar.Text = "Cancelar";
        btnCancelar.Size = new System.Drawing.Size(100, 30);
        btnCancelar.Location = new System.Drawing.Point(330, 110);
        btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

        this.Controls.Add(lblInstrucao);
        this.Controls.Add(txtIsbn);
        this.Controls.Add(lblMensagem);
        this.Controls.Add(btnOk);
        this.Controls.Add(btnCancelar);
    }

    private void BtnOk_Click(object sender, EventArgs e)
    {
        string isbn = txtIsbn.Text.Trim();
        if (string.IsNullOrWhiteSpace(isbn))
        {
            lblMensagem.Text = "Preencha todos os campos.";
            return;
        }

        IsbnDigitado = isbn;
        this.DialogResult = DialogResult.OK;
        this.Close();
    }
}
