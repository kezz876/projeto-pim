namespace PIM_3.model
{
    public class Emprestimo
    {
        public string ISBN { get; set; }
        public string CpfLeitor { get; set; }
        public DateTime Data { get; set; }

        public bool EscolherELancarEmprestimo(List<Livros> listaLivros)
        {
            var livrosDisponiveis = listaLivros.Where(l => l.Disponivel).ToList();

            if (livrosDisponiveis.Count == 0)
            {
                Console.WriteLine("Nenhum livro disponível para empréstimo.");
                return false;
            }

            Console.WriteLine("Livros disponíveis para empréstimo:");
            for (int i = 0; i < livrosDisponiveis.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {livrosDisponiveis[i].NomeLivro} - {livrosDisponiveis[i].Autor}");
            }

            Console.Write("Digite o número do livro que deseja emprestar: ");
            if (int.TryParse(Console.ReadLine(), out int opcao) && opcao > 0 && opcao <= livrosDisponiveis.Count)
            {
                var livroEscolhido = livrosDisponiveis[opcao - 1];
                return RegistrarEmprestimo(livroEscolhido);
            }
            else
            {
                Console.WriteLine("Opção inválida.");
                return false;
            }
        }


        public bool RegistrarEmprestimo(Livros livro)
        {
            if (livro != null && livro.Disponivel)
            {
                livro.Disponivel = false;
                Data = DateTime.Now;
                ISBN = livro.ISBN;
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