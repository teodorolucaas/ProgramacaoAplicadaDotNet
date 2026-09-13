namespace Imutabilidade
{
    internal class Program
    {

        //public record AlunoResumoRecord(string Nome, string Curso, double Media);

        static void Main(string[] args)
        {
            AlunoResumo ar = new AlunoResumo("Larissa", "ADM", 5);

            // AlunoResumo ar2 = new AlunoResumo("Larissa", "ADM", 5);

            Console.WriteLine("Classe comum");
            Console.WriteLine(ar.ToString());

            AlunoResumoRecord arr = new AlunoResumoRecord("Matheus", "Letras", 8.9);

            //AlunoResumoRecord arr2 = new AlunoResumoRecord("Matheus", "Letras", 8.9);

           
            Console.WriteLine("Record");
            Console.WriteLine(arr.ToString());

            /* AlunoResumoRecord arr = new AlunoResumoRecord("Matheus", "Letras", 8.9);

             var arr2 = arr with
             {
                 Media = 10
             };

             Console.WriteLine(arr.Nome);
             Console.WriteLine(arr.Curso);
             Console.WriteLine(arr.Media);

             Console.WriteLine("==========================");

             Console.WriteLine(arr2.Nome);
             Console.WriteLine(arr2.Curso);
             Console.WriteLine(arr2.Media);*/


        }
    }
}
