using System;
using PIM_3.model;

namespace BibliotecaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Livros livro = new Livros
            {
                NomeLivro = "1984",
                Autor = "George Orwell",
                Genero = "Ficção",
                Ano = 1949,
                IdLivro = 1,
                Disponivel = true
            };

            Leitores leitor = new Leitores
            {
                NomeLeitor = "João",
                Cpf = 123456789,
                Email = "joao@email.com"
            };

            Emprestimo emprestimo = new Emprestimo
            {
                NumLivro = livro.IdLivro,
                CpfLeitor = leitor.Cpf,
                Data = DateTime.Now
            };

            Pendentes pendente = new Pendentes
            {
                NumLivro = livro.IdLivro,
                NumLeitor = leitor.Cpf,
                DataEmprestimo = DateTime.Now
            };

            Admin admin = new Admin
            {
                Nome = "admin",
                Senha = "1234"
            };

            Console.Write("Digite o nome de usuário: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a senha: ");
            string senha = Console.ReadLine();

            if (!admin.VerifLogin(nome, senha))
            {
                Console.WriteLine("Nome de usuário ou senha incorretos.");
                return;
            }

            Console.WriteLine("\nLogin realizado com sucesso!");

            int opcao;
            do
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1 - Verificar disponibilidade do livro");
                Console.WriteLine("2 - Realizar empréstimo");
                Console.WriteLine("3 - Registrar devolução");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine(livro.Disponivel
                            ? $"O livro \"{livro.NomeLivro}\" está disponível."
                            : $"O livro \"{livro.NomeLivro}\" está indisponível.");
                        break;

                    case 2:
                        if (emprestimo.RegistrarEmprestimo(livro))
                        {
                            pendente.AtualizarDisponibilidade(livro);
                            Console.WriteLine("Livro emprestado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Livro indisponível para empréstimo.");
                        }
                        break;

                    case 3:
                        pendente.RegistrarDevolucao(livro);
                        Console.WriteLine("Devolução registrada com sucesso!");
                        break;

                    case 0:
                        Console.WriteLine("Saindo do sistema...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

            } while (opcao != 0);
        }
    }
}
