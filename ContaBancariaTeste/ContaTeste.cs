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

        [Test]
        [Ignore("Pendência de implementação")]
        public void testeSacarValorNegativo()
        {
            Conta conta = new Conta("0009", 200);

            bool resultado = conta.Sacar(-100);

            Assert.IsFalse(resultado);
        }

        [Test]
        public void testeDepositar()
        {
            Conta conta = new Conta("0009", 0);

            bool resultado = false;

            conta.Depositar(250);

            if (conta.GetSaldo() > 0)
                resultado = true;

            Assert.IsTrue(resultado);
        }

        [Test]
        public void testAssertStringEmpty()
        {
            string s = "";

            Assert.IsEmpty(s);
        }

        [Test]
        public void testAssertGreater()
        {
            int a = 70;
            int b = 50;

            Assert.Greater(a, b);
        }

        [Test]
        public void testAssertAreSame()
        {
            Conta c1 = new Conta("0001", 200);
            Conta c2 = c1;

            Assert.AreSame(c1, c2);
        }
    }
}