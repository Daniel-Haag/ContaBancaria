using ContaBancaria;

namespace ContaBancariaTeste
{
    public class Tests
    {
        Conta conta;

        [SetUp]
        public void Setup()
        {
            conta = new Conta("0009", 200, new ValidadorCreditoFake());
        }

        [Test]
        public void testeSolicitarEmprestimo()
        {
            bool resultado = conta.SolicitarEmprestimo(5000);

            Assert.IsTrue(resultado);
        }

        [TearDown]
        public void TearDown()
        {
            //Código executado após cada teste unitário
            conta = null;
        }

        [Test]
        [Category("Saques")]
        [TestCase(120, true)]
        //[TestCase(-120, false)]
        public void testeSacar(decimal valor, bool valorEsperado)
        {
            bool resultado = conta.Sacar(valor);

            Assert.IsTrue(resultado == valorEsperado);
        }

        [Test]
        [Category("Saques")]
        public void testeSacarSemSaldo()
        {
            bool resultado = conta.Sacar(250);

            Assert.IsFalse(resultado);
        }

        [Test]
        [Category("Saques")]
        [Ignore("Pendência de implementação")]
        public void testeSacarValorNegativo()
        {
            Assert.Throws<ArgumentOutOfRangeException>(delegate { conta.Sacar(-100); });
        }

        [Test]
        [Category("Depositos")]
        [TestCase(100)]
        [TestCase(200)]
        [TestCase(300)]
        [TestCase(400)]
        [TestCase(500)]
        public void testeDepositar(decimal valor)
        {
            Conta conta = new Conta("0009", 0, new ValidadorCreditoFake());

            bool resultado = false;

            conta.Depositar(valor);

            if (conta.GetSaldo() > 0)
                resultado = true;

            Assert.IsTrue(resultado);
        }

        [Test]
        [Category("Asserts")]
        public void testAssertStringEmpty()
        {
            string s = "";

            Assert.IsEmpty(s);
        }

        [Test]
        [Category("Asserts")]
        public void testAssertGreater()
        {
            int a = 70;
            int b = 50;

            Assert.Greater(a, b);
        }

        [Test]
        [Category("Asserts")]
        public void testAssertAreSame()
        {
            Conta c1 = new Conta("0001", 200, new ValidadorCreditoFake());
            Conta c2 = c1;

            Assert.AreSame(c1, c2);
        }

        [Test]
        [Timeout(4000)]
        [Ignore("")]
        public void testeMetodoLento()
        {
            bool resultado = conta.Sacar(100);

            Assert.IsFalse(resultado);
        }
    }
}