namespace DTO.DTO
{
    public class BoletimAlunoDto
    {
        public string Nome { get; set; }
        public string Curso { get; set; }
        public List<double> Notas { get; set; }
        public double Media { get; set; }
        public string Situacao { get; set; }
    }
}
