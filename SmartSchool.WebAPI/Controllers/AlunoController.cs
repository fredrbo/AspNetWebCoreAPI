using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;
using System.Linq;
using SmartSchool.WebAPI.Data;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext _context;
        public AlunoController(SmartContext context){

            _context = context;
        }
        //api/aluno retorna todos alunos
        [HttpGet]
        public IActionResult Get()
           {
               return Ok(_context.Alunos);
           }
        //api/aluno/byId/id
        [HttpGet("byId/{id}")]
         public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id); //pega aluno por ID
            if (aluno == null){
                return BadRequest("Aluno não encontrado na base de dados.");
            }
            return Ok(aluno);
        }
        //api/aluno/ByName?nome={NOME}&sobrenome={SOBRENOME}
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome){
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));

            if (aluno == null){
            return BadRequest("Nome não encontrado");
            }
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno){
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno){
            // AsNoTracking busca informação no banco sem bloquear
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(alu == null) return BadRequest("Aluno não encontrado");

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }
        
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno){
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(alu == null) return BadRequest("Aluno não encontrado");

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if(aluno == null) return BadRequest("Aluno não encontrado");

            _context.Remove(aluno);
            _context.SaveChanges();
            return Ok();
        }

        }
    }
