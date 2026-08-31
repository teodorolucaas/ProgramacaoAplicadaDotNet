using DTO.DTO;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;

namespace DTO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private static List<Aluno> alunos = new List<Aluno>
        {
            new Aluno
            {
                Id = 1,
                Nome = "Ana",
                Matricula = "2026001",
                Curso = "ADS",
                SenhaPortal = "123456",
                Notas = new List<double> { 8.5, 7.0, 9.0 }
            },

            new Aluno
            {
                Id = 2,
                Nome = "Carlos",
                Matricula = "2026002",
                Curso = "Engenharia",
                SenhaPortal = "654321",
                Notas = new List<double> { 7.5, 8.0, 6.5 }
            }
        };

        private static BoletimAlunoDto boletim = new BoletimAlunoDto
        {
            Nome = alunos[0].Nome,
            Curso = alunos[0].Curso,
            Notas = alunos[0].Notas,
            Media = alunos[0].Notas.Average(),
            Situacao = alunos[0].Notas.Average() >= 7 ? "Aprovado" : "Reprovado"
        };

        [HttpGet]
        public ActionResult<List<Aluno>> Get()
        {
            return Ok(alunos);
        }

        [HttpGet("boletim")]
        public ActionResult<BoletimAlunoDto> GetBoletim()
        {
            return Ok(boletim);
        }

        [HttpPost]
        public ActionResult LancarNota(LancarNotaDto dto)
        {
            
            Aluno aluno = alunos.FirstOrDefault(a => a.Id == dto.AlunoId);

            if (aluno == null)
            {
                return NotFound("Aluno não encontrado.");
            }

            aluno.Notas.Add(dto.Nota);
            boletim.Media = alunos[0].Notas.Average();

            return Ok(boletim);
        }
    }
}
