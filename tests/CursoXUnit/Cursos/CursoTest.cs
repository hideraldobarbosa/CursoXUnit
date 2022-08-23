using Bogus;
using CursoXUnit.Dominio.Cursos;
using CursoXUnit.Dominio.Cursos.Entitys;
using CursoXUnit.Dominio.Cursos.Enums;
using CursoXUnit.DominioTest._Util;
using CursoXUnit.DominioTest.Builders;
using ExpectedObjects;
using Xunit.Abstractions;

namespace CursoXUnit.DominioTest.Cursos
{
    public class CursoTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly string _nome;
        private readonly decimal _cargaHoraria;
        private readonly PublicoAlvo _publicoAlvo;
        private readonly decimal _valorCurso;
        private readonly string _descricao;

        public CursoTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _testOutputHelper.WriteLine("Construtor sendo executado");

            var faker = new Faker();
            _testOutputHelper.WriteLine($"decimal : {faker.Random.Decimal(1,100)}.");
            _testOutputHelper.WriteLine($"Company : {faker.Company.CompanyName()}.");
            _testOutputHelper.WriteLine($"Email   : {faker.Person.Email}.");


            _nome = "Curso de "+faker.Random.Word();
            _cargaHoraria = faker.Random.Decimal(50,360);
            _publicoAlvo = PublicoAlvo.Estudante;
            _valorCurso = faker.Random.Decimal(100, 1000); ;
            _descricao = faker.Lorem.Paragraph();
        }

        public void Dispose()
        {
            _testOutputHelper.WriteLine("Disposible sendo executado");
        }

        [Fact]
        public void DeveCriarCurso()
        {
            //Arrange
            var cursoEsperado = new
            {
                Nome = _nome,
                CargaHoraria = _cargaHoraria,
                PublicoAlvo = _publicoAlvo,
                ValorCurso = _valorCurso,
                Descricao = _descricao

            };

            //Action
            var curso = new Curso(cursoEsperado.Nome,cursoEsperado.Descricao, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.ValorCurso);

            //Analise
            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerUmNomeInvalido(string nomeInvalido)
        {
            //Arrange    

            //Action

            //Analise
            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.Novo().ComNome(nomeInvalido).Build())
                .ComMensagem("Nome do curso inválido");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveOCursoTerCargaHorariaMenorQue1(decimal cargaHorariaInvalida)
        {
            //Arrange

            //Action

            //Analise
            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.Novo().ComCargaHoraria(cargaHorariaInvalida).Build())
                .ComMensagem("Carga horária do curso inválida");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmValorMenorQue1(decimal valorInvalido)
        {
            //Arrange

            //Action

            //Analise
            Assert.Throws<ArgumentException>(() =>
               CursoBuilder.Novo().ComValorCurso(valorInvalido).Build())
               .ComMensagem("Valor do curso inválido");
        }
    }
}
