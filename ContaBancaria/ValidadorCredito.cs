using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria
{
    public class ValidadorCredito : IValidadorCredito
    {
        private readonly string cpf;

        public ValidadorCredito(string cpf)
        {
            this.cpf = cpf;
        }

        public bool ValidarCredito(string cpf, decimal valor)
        {
            bool StatusSerasa = VerificarSituacaoSerasa(cpf);
            bool StatusSPC = VerificarSituacaoSPC(cpf);

            return (StatusSerasa && StatusSPC);
        }

        private bool VerificarSituacaoSPC(string cpf)
        {
            //ToDo: Chamada a um webservice para verificar situação SPC
            return true;
        }

        private bool VerificarSituacaoSerasa(string cpf)
        {
            //ToDo: Chamada a um webservice para verificar situação Serasa
            return true;
        }
    }
}
