using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Models
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina() {}

        public AlunoDisciplina(int alunoID, int disciplinaId)
        {
            this.AlunoID = alunoID;
            this.DisciplinaID = disciplinaId;
        }

        public int AlunoID{ get; set; }
        public Aluno Aluno{ get; set; }
        public int DisciplinaID { get; set; }
        public Disciplina Disciplina{ get; set; }
    }
}
