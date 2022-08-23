using CursoXUnit.Dominio.Cursos.Enums;

namespace CursoXUnit.Dominio.Cursos.Entitys
{
    public class Curso
    {

        public Curso(string nome,string descricao, decimal cargaHoraria, PublicoAlvo publicoAlvo, decimal valorCurso)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome do curso inválido");

            if (cargaHoraria < 1)
                throw new ArgumentException("Carga horária do curso inválida");

            if (valorCurso < 1)
                throw new ArgumentException("Valor do curso inválido");

            Nome = nome;
            Descricao = descricao;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            ValorCurso = valorCurso;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }   
        public decimal CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public decimal ValorCurso { get; private set; }
    }
}