using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public void AtualizarBiblioteca(List<Livros> livros)
        {
            while (true)
            {
                Console.WriteLine("\n--- MENU ADMINISTRADOR ---");
                Console.WriteLine("1. Cadastrar Livro");
                Console.WriteLine("2. Emprestar Livro");
                Console.WriteLine("3. Consultar Livros");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarLivro(livros);
                        break;
                    case "2":
                        EmprestarLivro(livros);
                        break;
                    case "3":
                        ConsultarLivros(livros);
                        break;
                    case "0":
                        Console.WriteLine("Saindo do menu administrador...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        private void CadastrarLivro(List<Livros> livros)
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

            Console.Write("ID do Livro: ");
            novo.IdLivro = int.Parse(Console.ReadLine());

            novo.Disponivel = true;

            livros.Add(novo);
            Console.WriteLine("Livro cadastrado com sucesso!");
        }

        private void EmprestarLivro(List<Livros> livros)
        {
            Console.Write("Digite o ID do livro a ser emprestado: ");
            int id = int.Parse(Console.ReadLine());

            Livros livro = livros.Find(l => l.IdLivro == id);

            if (livro != null && livro.Disponivel)
            {
                livro.EmprestarLivro();
                Console.WriteLine("Livro emprestado com sucesso!");
            }
            else
            {
                Console.WriteLine("Livro não encontrado ou indisponível.");
            }
        }

        private void ConsultarLivros(List<Livros> livros)
        {
            if (livros.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
                return;
            }

            Console.WriteLine("\n--- Lista de Livros ---");
            foreach (var livro in livros)
            {
                Console.WriteLine($"ID: {livro.IdLivro} | Título: {livro.NomeLivro} | Autor: {livro.Autor} | Disponível: {(livro.Disponivel ? "Sim" : "Não")}");
            }
        }
        public void RealizarEmprestimo(List<Livros> livros, List<Leitores> leitores, List<Emprestimo> emprestimos)
        {
            Console.Write("Digite o CPF do leitor: ");
            int cpf = int.Parse(Console.ReadLine());

            Leitores leitor = leitores.Find(l => l.Cpf == cpf);
            if (leitor == null)
            {
                Console.WriteLine("Leitor não encontrado.");
                return;
            }

            Console.Write("Digite o ID do livro: ");
            int idLivro = int.Parse(Console.ReadLine());

            Livros livro = livros.Find(l => l.IdLivro == idLivro);
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
                NumLivro = livro.IdLivro,
                Data = DateTime.Now
            };

            livro.Disponivel = false;
            emprestimos.Add(emprestimo);

            Console.WriteLine("Empréstimo registrado com sucesso!");
        }

    }
}