using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PIM_3.model;

public class FormLivros : Form
{
    private List<Livros> livros;
    private TextBox textBoxISBN;
    private Button btnBuscar;
    private DataGridView dataGridViewLivros;
    private Button btnFechar;

    public FormLivros(List<Livros> livros)
    {
        this.livros = livros;
        InitializeComponent();
        AtualizarGrid();
    }

    private void InitializeComponent()
    {
        this.Text = "Consulta de Livros";
        this.Width = 800;
        this.Height = 400;
        this.StartPosition = FormStartPosition.CenterScreen;

        // TextBox ISBN
        textBoxISBN = new TextBox();
        textBoxISBN.Top = 20;
        textBoxISBN.Left = 20;
        textBoxISBN.Width = 200;
        this.Controls.Add(textBoxISBN);

        // Botão Buscar
        btnBuscar = new Button();
        btnBuscar.Text = "Buscar por ISBN";
        btnBuscar.Top = 20;
        btnBuscar.Left = 230;
        btnBuscar.Click += new EventHandler(BtnBuscar_Click);
        this.Controls.Add(btnBuscar);

        // Botão Fechar
        btnFechar = new Button();
        btnFechar.Text = "Fechar";
        btnFechar.Top = 20;
        btnFechar.Left = 310;
        btnFechar.Click += new EventHandler(btnFechar_Click);
        this.Controls.Add(btnFechar);

        // DataGridView
        dataGridViewLivros = new DataGridView();
        dataGridViewLivros.Top = 60;
        dataGridViewLivros.Left = 20;
        dataGridViewLivros.Width = 740;
        dataGridViewLivros.Height = 280;
        dataGridViewLivros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dataGridViewLivros.ReadOnly = true;
        dataGridViewLivros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.Controls.Add(dataGridViewLivros);
    }

    private void BtnBuscar_Click(object sender, EventArgs e)
    {
        string isbnBusca = textBoxISBN.Text.Trim();
        var livroEncontrado = livros.Find(l => l.ISBN == isbnBusca);

        if (livroEncontrado != null)
        {
            dataGridViewLivros.DataSource = new List<Livros> { livroEncontrado };
        }
        else
        {
            MessageBox.Show("Livro não encontrado com o ISBN informado.");
            AtualizarGrid(); // Volta à lista completa
        }
    }


    private void AtualizarGrid()
    {
        dataGridViewLivros.DataSource = null;
        dataGridViewLivros.DataSource = livros;
    }

            private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

}
