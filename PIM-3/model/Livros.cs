namespace PIM_3.model
{
    public class Livros
    {

        public string NomeLivro { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public int Ano { get; set; }
        public bool Disponivel { get; set; } = true;
        public int Count { get; set; }
        public string ISBN { get; set; }

        public bool EmprestarLivro()
        {
            if (Disponivel)
            {
                Disponivel = false;
                return true;
            }
            return false;
        }
    }
}
