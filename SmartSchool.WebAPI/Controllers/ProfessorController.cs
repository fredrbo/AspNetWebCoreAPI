using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;
using System.Linq;
using SmartSchool.WebAPI.Data;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;

        public ProfessorController(SmartContext context){
            _context = context;

        }
        
        [HttpGet]
        public IActionResult Get()
           {
               return Ok(_context.Professors);
           }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _context.Professors.FirstOrDefault(p => p.Id == id);
            if (professor == null) BadRequest("Professor não encontrado");
            return Ok(professor);
            }

        //api/professor/ByName?nome={NOME}
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome){
            var professor = _context.Professors.FirstOrDefault(p => p.Nome.Contains(nome));

            if (professor == null){
            return BadRequest("Nome não encontrado");
            }
            return Ok(professor);
        }


        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _context.Professors.AsNoTracking().FirstOrDefault(p => professor.Id == id);
            if (prof == null) return BadRequest("Professor não encontrado");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _context.Professors.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (prof == null) return BadRequest("Professor não encontrado");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _context.Professors.FirstOrDefault(p => p.Id == id);
            if (professor == null) return BadRequest("Professor não encontrado");

            _context.Remove(professor);
            _context.SaveChanges();
            return Ok();
        }
        }
    }
