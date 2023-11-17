using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoBHS.Domain.DataTransfer;

namespace TesteTecnicoBHS.Domain.Interfaces.Validacoes
{
    public interface IProdutoValidations
    {
        public bool RequestBodyValidation(ProdutoDataTransfer produto);

    }
}
