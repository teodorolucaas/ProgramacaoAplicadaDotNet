namespace PatternMatching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Instanciação dos objetos
            Desenvolvedor dev = new Desenvolvedor("Ana Luiza", 23, "C#", 6);
            Gerente ger = new Gerente("Arthur", 35, 11);
            Estagiario est = new Estagiario("Caio", 18, 22);

            // Verifica o tipo do objeto utilizando Pattern Matching com switch.
            //VerificarFuncionario(dev);

            // Verifica o tipo do objeto utilizando switch expression.
            //Console.WriteLine(VerificarFuncionarioSwitchExpression(est));

            // Verifica um valor específico utilizando Constant Pattern.
            //Console.WriteLine(VerificarStatus(300));

            // Classifica os anos de experiência utilizando Relational Pattern.
            //Console.WriteLine(VerificarAnosExperiencia(dev.AnosExperiencia));

            // Classifica os anos de experiência utilizando Relational e Logical Pattern.
            //Console.WriteLine(VerificarExperiencia(dev.AnosExperiencia));

            // Classifica o funcionário utilizando Pattern Matching com a cláusula when.
            //Console.WriteLine(ClassificacaoFuncionario(dev));

            // Classifica o funcionário analisando suas propriedades com Property Pattern.
            //Console.WriteLine(ClassificacaoFuncionarioPropriedade(dev));

            // Analisa uma tupla, verificando o valor da operação e o tipo do segundo elemento.
            Console.WriteLine(Processar("maiusculo", "lucas"));


        }

        // O objetivo desta função é identificar se o objeto passado como parâmetro
        // é do tipo Desenvolvedor. Nesta função, utilizamos casting para converter
        // o objeto para o tipo desejado.
        static void VerificarDesenvolvedor(object obj)
        {
            if (obj is Desenvolvedor)
            {
                // Aqui está sendo realizado um casting, pois obj é do tipo object.
                // Portanto, é necessário convertê-lo para o tipo desejado.
                Desenvolvedor dev = (Desenvolvedor)obj;
                Console.WriteLine("O objeto é do tipo Desenvolvedor.");
                Console.WriteLine("Dados do Desenvolvedor(a):");
                Console.WriteLine($"Nome: {dev.Nome}");
                Console.WriteLine($"Idade: {dev.Idade}");
                Console.WriteLine($"Linguagem: {dev.Linguagem}");
                Console.WriteLine($"ANos de Experiência: {dev.AnosExperiencia}");

            }
            else
            {
                Console.WriteLine("O objeto não é do tipo Desenvolvedor");
            }
        }

        // Esta função executa o mesmo código da função anterior, porém não é necessário
        // realizar o casting, pois utilizamos Pattern Matching para verificar e obter o tipo do objeto.
        static void VerificarDesenvolvedorPm(object obj)
        {
            //Aqui já é verificado e criado o objeto (dev) para acessarmos as propriedades
            if (obj is Desenvolvedor dev)
            {
                Console.WriteLine("O objeto é do tipo Desenvolvedor.");
                Console.WriteLine("Dados do Desenvolvedor(a):");
                Console.WriteLine($"Nome: {dev.Nome}");
                Console.WriteLine($"Idade: {dev.Idade}");
                Console.WriteLine($"Linguagem: {dev.Linguagem}");
                Console.WriteLine($"ANos de Experiência: {dev.AnosExperiencia}");

            }
            else
            {
                Console.WriteLine("O objeto não é do tipo Desenvolvedor");
            }
        }

        // Utiliza Pattern Matching com switch tradicional para verificar o tipo do objeto.
        // Quando um tipo é identificado, uma variável é criada automaticamente
        // permitindo acessar diretamente as propriedades específicas daquele objeto.
        static void VerificarFuncionario(object obj)
        {
            switch (obj)
            {
                //Aqui já é verificado e criado o objeto (dev) para acessarmos as propriedades
                case Desenvolvedor dev:
                    Console.WriteLine($"{dev.Nome} é Desenvolvedor(a)");
                    Console.WriteLine($"Linguagem: {dev.Linguagem}");
                    Console.WriteLine($"Anos de Expreriência: {dev.AnosExperiencia}");
                    break;

                case Gerente ger:
                    Console.WriteLine($"{ger.Nome} é Gerente");
                    Console.WriteLine($"Tamanho da Equipe: {ger.TamanhoEquipe}");
                    break;

                case Estagiario est:
                    Console.WriteLine($"{est.Nome} é Estagiário(a)");
                    Console.WriteLine($"Horas Semanais: {est.HorasSemanais}");
                    break;
                default:
                    Console.WriteLine("Objeto não reconhecido");
                    break;
            }
        }

        // Esta função verifica o tipo do objeto utilizando a sintaxe de
        // switch expression. Nessa sintaxe, é realizado o teste condicional
        // e, para cada caso, uma expressão é executada.
        // Neste exemplo, a expressão monta uma string que será retornada.
        static string VerificarFuncionarioSwitchExpression(Funcionario obj)
        {
            string resuldo = obj switch
            {
                Desenvolvedor dev => $"{dev.Nome} é Desenvolvedor(a)",
                Gerente ger => $"{ger.Nome} é Gerente",
                Estagiario est => $"{est.Nome} é Estagiário", 
                _ => "Objeto não reconhecido"
            };

            return resuldo;
        }

        // Utiliza Constant Pattern para verificar o valor de status
        // e retornar uma mensagem correspondente.
        static string VerificarStatus(int status)
        {
            string resultado = status switch
            {
                0 => "Status nulo",
                1 => "Operação Pendente",
                2 => "Operação Cancelada",
                200 => "Operação concluida com sucesso",
                404 => "Página não encontrada",
                _ => "Status não reconhecido"
            };

            return resultado;       
        }

        // Utiliza Relational Pattern para classificar o desenvolvedor pelos anos de experiência.
        // As condições são avaliadas de cima para baixo. Como valores menores que 2 já foram
        // tratados no primeiro caso, a condição < 5 representa, na prática, valores >= 2 e < 5.
        static string VerificarAnosExperiencia(int anos)
        {
            return anos switch
            {
                < 2 => "Desenvolvedor Iniciante",
                < 5 => "Desenvolvedor Intermediário",
                >= 5 => "Desenvolvedor Experienete"
            };
        }

        // Utiliza Relational Pattern junto com Logical Pattern (and, or e not) para validar
        // e classificar os anos de experiência em diferentes faixas.
        static string VerificarExperiencia(int anos)
        {
            return anos switch
            {
                < 0 or >10 => "Valor fora da faixa esperada",
                >=0 and <2 => "Desenvolvedor Iniciante",
                >=2 and <5 => "Desenvolvedor Intermediário",
                >= 5 and <10 => "Desenvolvedor Experiente"
            };
        }

        // Utiliza Pattern Matching com a cláusula when para adicionar
        // condições específicas após a identificação do tipo do objeto.
        static string ClassificacaoFuncionario(object obj)
        {
            return obj switch
            {
                Desenvolvedor dev when dev.AnosExperiencia is > 0 and <3 =>
                $"{dev.Nome} é um desenvolvedor(a) iniciante",
                Desenvolvedor dev when dev.AnosExperiencia is >= 3 and < 5 =>
                $"{dev.Nome} é um desenvolvedor(a) intermediário",
                Desenvolvedor dev when dev.AnosExperiencia is >= 5 =>
                $"{dev.Nome} é um desenvolvedor(a) experiente",
                Gerente gere when gere.TamanhoEquipe is > 10 =>
                $"{gere.Nome} é um gerente e tem uma equipe grande",
                _ => "Funcionário não classificado"

            };
        }

        // Utiliza Property Pattern para verificar propriedades específicas
        // do objeto. Neste caso, identifica um Desenvolvedor que trabalha com C#
        // e possui 5 anos ou mais de experiência.
        static string ClassificacaoFuncionarioPropriedade (Funcionario fun)
        {
            return fun switch
            {
                Desenvolvedor { Linguagem: "C#", AnosExperiencia: >=5} temp =>
                $"{temp.Nome} é um desenvolvedor(a) experiente de C#",

                _ => "Objeto não classificado"
            };
        }

        // Utiliza Pattern Matching em uma tupla para verificar os valores
        // recebidos. Além de analisar a operação, também verifica o tipo
        // do segundo elemento e armazena seu valor em uma variável.
        static string Processar (object operacao, object valor)
        {
            return (operacao, valor) switch
            {
                ("dobrar", int numero) => $"Dobro = {numero * 2}",
                ("maiusculo", string palavra) => $"{palavra.ToUpper()}",
                _ => "Tupla não reconhecida"
            };
        }
    }
}
