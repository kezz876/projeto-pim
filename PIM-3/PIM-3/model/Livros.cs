using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIM_3.model
{
    public class Livros
    {
        public string NomeLivro { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public int Ano { get; set; }
        public int IdLivro { get; set; }
        public bool Disponivel { get; set; }

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
