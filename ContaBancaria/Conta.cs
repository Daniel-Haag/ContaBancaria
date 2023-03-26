using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria
{
    public class Conta
    {
        private string _cpf;
        private decimal _saldo;
        private IValidadorCredito? _validadorCredito;


        public Conta(string cpf, decimal saldo, IValidadorCredito validadorCredito)
        {
            this._cpf = cpf;
            this._saldo = saldo;
            this._validadorCredito = validadorCredito;
        }

        public decimal GetSaldo()
        {
            return _saldo;
        }

        public void Depositar(decimal valor)
        {
            this._saldo += valor;
        }

        public bool Sacar(decimal valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (_saldo < valor)
            {
                return false;
            }

            this._saldo -= valor;
            return true;
        }

        public bool SolicitarEmprestimo(decimal valor)
        {
            bool resultado = _validadorCredito.ValidarCredito(this._cpf, valor);

            if (resultado)
            {
                this._saldo += valor;
            }

            return resultado;
        }
    }
}
