using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imutabilidade
{
    internal class AlunoResumo
    {
        public string Nome { get; private set; }
        public string Curso { get; private set; }
        public double Media { get; private set; }

        public AlunoResumo(string nome, string curso, double media)
        {
            Nome = nome;
            Curso = curso;
            Media = media;
        }

        public void AlterarMedia(double media)
        {
            Media = media;
        }

    }
}
