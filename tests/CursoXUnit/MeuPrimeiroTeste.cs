namespace CursoXUnit
{
    public class MeuPrimeiroTeste
    {
        [Fact(DisplayName = "DeveAsVariaveisTeremOMesmoValor")]
        public void DeveAsVariaveisTeremOMesmoValor()
        {
            //Arrange - Organiza��o
            var variavel1 = 2;
            var variavel2 = 1;

            //Action - A��o
            variavel1 = variavel2;

            //Assert - Avali���o
            Assert.Equal(variavel1, variavel2);  
        }
    }
}