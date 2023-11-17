using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoBHS.Domain.DataTransfer;
using TesteTecnicoBHS.Domain.Interfaces.Validacoes;

namespace TesteTecnicoBHS.Services.Validations
{
    public class ProdutoValidation : IProdutoValidations
    {
        public bool RequestBodyValidation(ProdutoDataTransfer produto)
        {
            if (produto.Name == null || produto.Name == "" ||produto.Name == "string")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
