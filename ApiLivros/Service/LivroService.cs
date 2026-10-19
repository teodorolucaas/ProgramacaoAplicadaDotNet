using ApiLivros.Models;

namespace ApiLivros.Service
{
    public class LivroService
    {
        private readonly List<Livro> _livros = new()
        {
            new Livro
            {
                Id = 1,
                Titulo = "Dom Casmurro",
                Autor = "Machado de Assis",
                AnoPublicacao = 1899
            },
            new Livro
            {
                Id = 2,
                Titulo = "O Cortico",
                Autor = "Aluisio Azevedo",
                AnoPublicacao = 1890
            }
        };

        public List<Livro> Listar()
        {
            return _livros;
        }
    }
}
