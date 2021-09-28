using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;
using System.Linq;
using SmartSchool.WebAPI.Data;
using System.Collections.Generic;
using SmartSchool.WebAPI.V2.Dtos;
using AutoMapper;

namespace SmartSchool.WebAPI.V2.Controllers
{
    ///<summary>
    /// Versão 2.0 controlador
    ///</summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AlunoController : ControllerBase
    {

        public readonly IRepository _repo;

        public readonly IMapper _mapper;

        public AlunoController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        //api/aluno retorna todos alunos
        /// <summary>
        /// Método responsavel para retornar todos meus alunoa
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repo.GetAllAlunos(true);
           
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }

        //api/aluno/id
        /// <summary>
        /// Método responsavel para retornar apenas um Aluno por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno =_repo.GetAlunoById(id, false);
            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado na base de dados.");
            }
            var alunoDto = _mapper.Map<AlunoDto>(aluno);

            return Ok(alunoDto);
        }

        [HttpPost]
        public IActionResult Post(AlunoRegistrarDto model)
        {
            var aluno = _mapper.Map<Aluno>(model);

            _repo.Add(aluno);
            if(_repo.SaveChanges()){
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }
            return BadRequest("Aluno não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoRegistrarDto model)
        {
            // AsNoTracking busca informação no banco sem bloquear
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            _mapper.Map(model, aluno);

            _repo.Update(aluno);
            if(_repo.SaveChanges()){
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }
            return BadRequest("Aluno não atualizado");
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            _repo.Delete(aluno);
            if(_repo.SaveChanges()){
                return Ok("Aluno deleteado");
            }
            return BadRequest("Aluno não localizado");
        }

    }
}
