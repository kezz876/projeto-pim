using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIM_3.model
{
    public class Emprestimo
    {
        public int NumLivro { get; set; }
        public int CpfLeitor { get; set; }
        public DateTime Data { get; set; }

         public bool VerifDisponivel(Livros livro)
        {
            return livro != null && livro.Disponivel;
        }

        public bool RegistrarEmprestimo(Livros livro)
        {
            if (VerifDisponivel(livro))
            {
                livro.Disponivel = false;
                Data = DateTime.Now;
                Console.WriteLine("Empréstimo registrado com sucesso.");
                return true;
            }
            else
            {
                Console.WriteLine("Livro não disponível para empréstimo.");
                return false;
            }
        }
    }
}