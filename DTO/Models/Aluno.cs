namespace DTO.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Curso { get; set; }
        public string SenhaPortal { get; set; }
        public List<double> Notas { get; set; }

    }
}
