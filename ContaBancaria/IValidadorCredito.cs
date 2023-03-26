using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria
{
    public interface IValidadorCredito
    {
        bool ValidarCredito(string cpf, decimal valor);
    }
}
