using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
        // T sempre recebe uma classe no parametro. entity pode ser o aluno, professor, etc
         void Add<T>(T entity) where T: class;
         void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         bool SaveChanges();

        //Alunos
         Aluno[] GetAllAlunos(bool includeProfessor);
         Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessor);
         Aluno GetAlunoById(int alunoId, bool includeProfessor); 
   
        //Professores
         Professor[] GetAllProfessores(bool includeAlunos);
         Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAlunos);
         Professor GetProfessorById(int alunoId, bool includeAlunos); 
         Professor GetProfessoresByAlunoId(int alunoId, bool includeAlunos); 
   
    }
}