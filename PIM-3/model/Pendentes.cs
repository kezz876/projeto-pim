using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIM_3.model
{
    public class Pendentes
    {
        public int NumLivro { get; set; }
        public int NumLeitor { get; set; }
        public DateTime DataEmprestimo { get; set; }

        public void RealizarDevolucaoPorISBN(string isbn, List<Livros> listaLivros)
        {
            var livro = listaLivros.FirstOrDefault(l => l.ISBN == isbn);

            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            if (!livro.Disponivel)
            {
                livro.Disponivel = true;
                Console.WriteLine($"Livro \"{livro.NomeLivro}\" devolvido com sucesso.");
            }
            else
            {
                Console.WriteLine("O livro já está disponível. Nenhuma ação necessária.");
            }
        }


        public string VerificarDisponibilidadeLivro(string isbn, List<Livros> listaLivros)
        {
            var livro = listaLivros.FirstOrDefault(l => l.ISBN == isbn);

            if (livro == null)
            {
                return "Livro não encontrado.";
            }

            return livro.Disponivel
                ? $"O livro \"{livro.NomeLivro}\" está disponível para empréstimo."
                : $"O livro \"{livro.NomeLivro}\" está atualmente emprestado.";
        }

    }
}