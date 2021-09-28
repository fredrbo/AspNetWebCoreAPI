using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Models
{
    public class Aluno
    {
        public Aluno() { }
        //construtor
        public Aluno(int id,
                    int matricula,
                    string nome,
                    string sobrenome,
                    string telefone,
                    DateTime dataNasc
                    )
        {

            this.Id = id;
            this.Matricula = Matricula;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Telefone = telefone;
            this.DataNasc = DataNasc;
        }
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;//momento atual do cadastro
        public DateTime? DataFim { get; set; } = null; //pode ser nulo
        public bool Ativo { get; set; } = true; // Ativo será True ao criar cadastro
        public IEnumerable<AlunoDisciplina> AlunoDisciplinas { get; set; }

    }
}
