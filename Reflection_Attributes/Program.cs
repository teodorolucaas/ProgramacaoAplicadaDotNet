using System.Reflection;

namespace Reflection_Attributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Cria objetos de classes diferentes para demonstrar que os métodos
            // com reflection podem trabalhar com qualquer tipo de objeto.
            Produto produto = new Produto
            {
                Nome = "Notebook",
                Preco = 3500,
                Estoque = 15
            };

            Cliente cliente = new Cliente
            {
                Nome = "Luiza",
                Idade = 25,
                Saldo = 50.0
            };

            Console.WriteLine("===== OBTENDO INFORMAÇÕES COM TYPE =====");

            // GetType() obtém o Type a partir de um objeto já instanciado.
            // O Type permite consultar a estrutura da classe durante a execução.
            Type t1 = produto.GetType();

            Console.WriteLine($"Classe obtida com GetType(): {t1.Name}");

            // typeof() obtém o Type diretamente da classe, sem a necessidade
            // de criar um objeto Produto.
            Type t2 = typeof(Produto); //Se mudar a classe, mudará o comportamento das saídas do console.

            Console.WriteLine($"Classe obtida com typeof(): {t2.Name}");

            Console.WriteLine("\n===== PROPRIEDADES DA CLASSE =====");

            // GetProperties() utiliza reflection para obter as propriedades
            // públicas da classe representada por t2.
            foreach (var propriedade in t2.GetProperties())
            {
                // Name representa o nome da propriedade.
                // PropertyType.Name representa o nome de seu tipo.
                Console.WriteLine(
                    $"Propriedade: {propriedade.Name} | " +
                    $"Tipo: {propriedade.PropertyType.Name}");
            }

            Console.WriteLine("\n===== MÉTODOS DA CLASSE =====");

            // GetMethods() utiliza reflection para obter os métodos públicos
            // disponíveis na classe, incluindo métodos criados por nós,
            // métodos get_ e set_ das propriedades e métodos herdados de object.
            foreach (var metodo in t2.GetMethods())
            {
                // Cada item representa um método encontrado na classe.
                Console.WriteLine($"Método: {metodo.Name}");
            }

            Console.WriteLine("\n===== REFLECTION ABERTA =====");

            // Na reflection aberta, todas as propriedades públicas encontradas
            // no objeto são exibidas.
            ListarDados(produto);
            Console.WriteLine();

            ListarDados(cliente);

            Console.WriteLine("\n===== REFLECTION CONTROLADA =====");

            // Na reflection controlada, são exibidas somente as propriedades
            // marcadas com o attribute [Exibir].
            ListarDados_ReflectionControlada(produto);
            Console.WriteLine();

            ListarDados_ReflectionControlada(cliente);
        }

        // Método genérico que utiliza reflection aberta para exibir
        // todas as propriedades públicas do objeto recebido.
        public static void ListarDados(object objeto)
        {
            // Obtém o Type da classe real do objeto recebido.
            Type tipo = objeto.GetType();

            Console.WriteLine($"Classe: {tipo.Name}");

            // Percorre todas as propriedades públicas encontradas na classe.
            foreach (var propriedade in tipo.GetProperties())
            {
                // Obtém o valor da propriedade atual no objeto.
                // O retorno é object porque a propriedade pode ter tipos diferentes,
                // como string, int, decimal ou double.
                object valor = propriedade.GetValue(objeto);

                // Exibe o nome da propriedade e o valor armazenado nela.
                Console.WriteLine($"- {propriedade.Name}: {valor}");
            }
        }

        // Método genérico que utiliza reflection controlada para exibir apenas
        // as propriedades que possuem o attribute [Exibir].
        public static void ListarDados_ReflectionControlada(object objeto)
        {
            // Obtém o Type da classe real do objeto recebido.
            Type tipo = objeto.GetType();

            Console.WriteLine($"Classe: {tipo.Name}");

            // Percorre todas as propriedades públicas encontradas na classe.
            foreach (var propriedade in tipo.GetProperties())
            {
                // Verifica se a propriedade atual possui o attribute [Exibir].
                // Caso não possua, o resultado será null.
                var atributo = propriedade.GetCustomAttribute<ExibirAttribute>() != null;

                // Exibe somente as propriedades autorizadas pelo attribute.
                if (atributo)
                {
                    // Obtém o valor da propriedade atual no objeto.
                    object valor = propriedade.GetValue(objeto);

                    Console.WriteLine($"- {propriedade.Name}: {valor}");
                }
            }
        }
    }
}