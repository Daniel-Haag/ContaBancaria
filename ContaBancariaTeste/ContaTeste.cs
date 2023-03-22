using ContaBancaria;

namespace ContaBancariaTeste
{
    public class Tests
    {
        Conta conta;

        [SetUp]
        public void Setup()
        {
            conta = new Conta("0009", 200);
        }

        [TearDown]
        public void TearDown()
        {
            //Código executado após cada teste unitário
            conta = null;
        }

        [Test]
        [Category("Saques")]
        public void testeSacar()
        {
            bool resultado = conta.Sacar(120);

            Assert.IsTrue(resultado);
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
            Conta c1 = new Conta("0001", 200);
            Conta c2 = c1;

            Assert.AreSame(c1, c2);
        }
    }
}