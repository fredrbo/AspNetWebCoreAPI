using System;

namespace SmartSchool.WebAPI.Dtos
{
    public class AlunoRegistrarDto
    {
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;//momento atual do cadastro
        public DateTime? DataFim { get; set; } = null; //pode ser nulo
        public bool Ativo { get; set; } = true; // Ativo será True ao criar cadastro
    }
}