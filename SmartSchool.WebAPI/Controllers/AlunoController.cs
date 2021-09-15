using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;
using System.Linq;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        //Cria alunos e coloca na lista
        public List<Aluno> Alunos = new List<Aluno>() {
            new Aluno() {
                Id = 1,
                Nome = "Marcos",
                Sobrenome = "Almeida",
                Telefone = "123456"
            },
            new Aluno() {
                Id = 2,
                Nome = "Marta",
                Sobrenome = "Kent",
                Telefone = "5616248"
            },
            new Aluno() {
                Id = 3,
                Nome = "Laura",
                Sobrenome = "Maria",
                Telefone = "0930912"
            }
        };

        public AlunoController(){}
        
        [HttpGet]
        public IActionResult Get()
           {
               return Ok(Alunos);
           }
        //api/aluno/byId/id
        [HttpGet("byId/{id}")]
         public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null){
                return BadRequest("Aluno não encontrado na base de dados.");
            }
            return Ok(aluno);
        }
        //api/aluno/ByName?nome={NOME}&sobrenome={SOBRENOME}
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome){
            var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));

            if (aluno == null){
            return BadRequest("Nome não encontrado");
            }
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno){
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno){
            return Ok(aluno);
        }
        
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno){
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            return Ok();
        }

        }
    }
