using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection_Attributes
{
    internal class Cliente
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        [Exibir]
        public double Saldo { get; set; }
    }
}
