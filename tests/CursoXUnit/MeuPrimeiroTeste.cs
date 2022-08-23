namespace CursoXUnit
{
    public class MeuPrimeiroTeste
    {
        [Fact(DisplayName = "DeveAsVariaveisTeremOMesmoValor")]
        public void DeveAsVariaveisTeremOMesmoValor()
        {
            //Arrange - Organização
            var variavel1 = 2;
            var variavel2 = 1;

            //Action - Ação
            variavel1 = variavel2;

            //Assert - Avaliãção
            Assert.Equal(variavel1, variavel2);  
        }
    }
}