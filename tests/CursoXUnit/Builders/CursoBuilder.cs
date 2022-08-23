using CursoXUnit.Dominio.Cursos.Entitys;
using CursoXUnit.Dominio.Cursos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoXUnit.DominioTest.Builders
{
    public class CursoBuilder
    {
        private string  _nome = "Informática Basica";
        private decimal _cargaHoraria = 80;
        private PublicoAlvo _publicoAlvo = PublicoAlvo.Estudante;
        private decimal _valorCurso = 950;
        private string _descricao = "Uma descrição do curso";

        public static CursoBuilder Novo()
        {
            return new CursoBuilder();
        }

        public CursoBuilder ComNome(string nome) 
        {
            _nome = nome;
            return this;
        }
        public CursoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public CursoBuilder ComPublicoALvo(PublicoAlvo publicoAlvo)
        {
            _publicoAlvo = publicoAlvo;
            return this;
        }

        public CursoBuilder ComCargaHoraria(decimal cargaHoraria)
        {
            _cargaHoraria = cargaHoraria;
            return this;
        }

        public CursoBuilder ComValorCurso(decimal valorCurso)
        {
            _valorCurso = valorCurso;
            return this;
        }
        public Curso Build()
        {
            return new Curso(_nome, _descricao, _cargaHoraria, _publicoAlvo, _valorCurso );
        }
    }
}
