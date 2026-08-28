using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection_Attributes
{
    //Criando um Attribute básico
    [AttributeUsage(AttributeTargets.Property)]
    internal class ExibirAttribute:Attribute
    {
    }
}
