using ContaBancaria;

namespace ContaBancariaTeste
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void testeSacar()
        {
            Conta conta = new Conta("0009", 200);

            bool resultado = conta.Sacar(120);

            Assert.IsTrue(resultado);
        }

        [Test]
        public void testeSacarSemSaldo()
        {
            Conta conta = new Conta("0009", 200);

            bool resultado = conta.Sacar(250);

            Assert.IsFalse(resultado);
        }
    }
}