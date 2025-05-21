using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIM_3.model
{
    public class Leitores
    {

        public string NomeLeitor { get; set; }
        public int Cpf { get; set; }
        public string Email { get; set; }

        public bool VerifCPF()
        {
            // Verificação de CPF (simples)
            return Cpf.ToString().Length == 11;
        }

        public bool VerifEmail()
        {
            return Email.Contains("@") && Email.IndexOf(".", Email.IndexOf("@")) > Email.IndexOf("@");
        }

        public Emprestimo SolicitarEmprestimo(Livros livro)
        {
            if (!VerifCPF())
            {
                Console.WriteLine("CPF inválido.");
                return null;
            }

            if (!VerifEmail())
            {
                Console.WriteLine("Email inválido.");
                return null;
            }

            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return null;
            }

            if (!livro.Disponivel)
            {
                Console.WriteLine("Livro indisponível.");
                return null;
            }

            // Registrar empréstimo
            livro.Disponivel = false;

            Emprestimo novoEmprestimo = new Emprestimo
            {
                CpfLeitor = this.Cpf,
                NumLivro = livro.IdLivro,
                Data = DateTime.Now
            };

            Console.WriteLine($"Empréstimo realizado com sucesso por {NomeLeitor} para o livro \"{livro.NomeLivro}\".");
            return novoEmprestimo;
        }


    }
}