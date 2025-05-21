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

        public void RegistrarDevolucao(Livros livro)
{
    if (!livro.Disponivel)
    {
        livro.Disponivel = true;
        Console.WriteLine($"Livro {livro.NomeLivro} devolvido com sucesso.");
    }
    else
    {
        Console.WriteLine("O livro já está disponível. Nenhuma ação necessária.");
    }
}

public void AtualizarDisponibilidade(Livros livro)
{
    // Se ainda está pendente, o livro não está disponível
    livro.Disponivel = false;
}
    }
}