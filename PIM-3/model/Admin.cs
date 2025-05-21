using System.Dynamic;

namespace PIM_3.model
{
    public class Admin
    {
        public string Nome { get; set; }
        public string Senha { get; set; }

        public bool VerifLogin(string nomeDigitado, string senhaDigitada)
        {
            return nomeDigitado == Nome && senhaDigitada == Senha;
        }

        internal Livros CadastrarLivroConsole()
        {
            Livros novo = new Livros();

            Console.Write("Nome do Livro: ");
            novo.NomeLivro = Console.ReadLine();

            Console.Write("Autor: ");
            novo.Autor = Console.ReadLine();

            Console.Write("Gênero: ");
            novo.Genero = Console.ReadLine();

            Console.Write("Ano: ");
            novo.Ano = int.Parse(Console.ReadLine());

            novo.Disponivel = true;

            // Gerar ISBN de 13 dígitos
            novo.ISBN = GerarISBN13();

            Console.WriteLine($"ISBN: {novo.ISBN}");
            return novo;
        }
        public Livros ConsultarLivros(List<Livros> livros)
        {
            if (livros.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
                return null;
            }

            Console.Write("Digite o ISBN do livro que deseja consultar: ");
            string isbnBusca = Console.ReadLine();

            var livroEncontrado = livros.Find(l => l.ISBN == isbnBusca);

            if (livroEncontrado != null)
            {
                Console.WriteLine("\n--- Livro Encontrado ---");
                Console.WriteLine($"Título: {livroEncontrado.NomeLivro}");
                Console.WriteLine($"Autor: {livroEncontrado.Autor}");
                Console.WriteLine($"Gênero: {livroEncontrado.Genero}");
                Console.WriteLine($"Ano: {livroEncontrado.Ano}");
                Console.WriteLine($"ISBN: {livroEncontrado.ISBN}");
                Console.WriteLine($"Disponível: {(livroEncontrado.Disponivel ? "Sim" : "Não")}");
                return livroEncontrado;
            }
            else
            {
                Console.WriteLine("Livro não encontrado com o ISBN informado.");
                return null;
            }
        }


        public void RealizarEmprestimo(List<Livros> livros, List<Leitores> leitores, List<Emprestimo> emprestimos)
        {
            Console.Write("Digite o CPF do leitor: ");
            string cpf = Console.ReadLine();

            Leitores leitor = leitores.Find(l => l.Cpf == cpf);
            if (leitor == null)
            {
                Console.WriteLine("Leitor não encontrado.");
                return;
            }

            Console.Write("Digite o ISBN do livro: ");
            string isbnLivro = Console.ReadLine();

            Livros livro = livros.Find(l => l.ISBN == isbnLivro);
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            if (!livro.Disponivel)
            {
                Console.WriteLine("Livro indisponível.");
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

            Console.WriteLine("Empréstimo registrado com sucesso!");
        }

        // Método auxiliar para gerar ISBN de 13 dígitos
        private string GerarISBN13()
        {
            Random random = new Random();
            string isbn = "";

            for (int i = 0; i < 13; i++)
            {
                isbn += random.Next(0, 10).ToString();
            }

            return isbn;
        }

    }
}