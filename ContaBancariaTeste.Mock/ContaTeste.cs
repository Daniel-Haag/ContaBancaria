using ContaBancaria;
using Moq;

namespace ContaBancariaTeste.Mock
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void testeSolicitarEmprestimoMoq()
        {
            var mock = new Mock<IValidadorCredito>();
            mock.Setup(x => x.ValidarCredito(It.IsAny<string>(), It.IsAny<decimal>())).Returns(true);

            var conta = new Conta("0001", 100, mock.Object);

            int resultadoEsperado = 5100;

            conta.SolicitarEmprestimo(5000);

            Assert.IsTrue(conta.GetSaldo() == resultadoEsperado);
        }
    }
}