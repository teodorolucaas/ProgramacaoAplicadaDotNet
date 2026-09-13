using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imutabilidade
{
    public record AlunoResumoRecord(string Nome, string Curso, double Media);


    /*public record AlunoResumoRecord
    {
        public string Nome { get; init; }
        public string Curso { get; init; }
        public double Media { get; init; }
    }*/

}
