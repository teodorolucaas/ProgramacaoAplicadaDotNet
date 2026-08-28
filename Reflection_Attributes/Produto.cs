using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection_Attributes
{
    internal class Produto
    {
        //Colocando o Attribute na propriedade Nome
        [Exibir]
        public string Nome { get; set; }
        //Colocando o Attribute na propriedade Preco
        [Exibir]
        public decimal Preco { get; set; }
        public int Estoque { get; set; }

        public void ExibirResumo()
        {
            Console.WriteLine($"{Nome}-{Preco:C}");
        }
    }
}
