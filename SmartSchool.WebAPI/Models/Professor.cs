using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Models
{
    public class Professor
    {
        public Professor() { }

        public Professor(int id,int registro, string nome, string sobrenome)
        {
            this.Id = id;
            this.Registro = registro;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
        }

        public int Id{ get; set; }
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;//momento atual do cadastro
        public DateTime? DataFim { get; set; } = null; //pode ser nulo
        public bool Ativo { get; set; } = true; // Ativo será True ao criar cadastro
        public IEnumerable<Disciplina> Disciplinas { get; set; }
        // um professor pode ter mais de uma disciplina, usar IEnumerable
    }
}
