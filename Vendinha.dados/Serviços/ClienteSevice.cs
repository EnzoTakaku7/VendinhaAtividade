using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendinha.Dados.Repositorios;
using Vendinha.Negocio;
namespace Vendinha.Dados.Serviços
{
    public class ClienteSevice
    {
        private ClienteRepositorio repositorio;

        public ClienteSevice(ClienteRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public bool Validar(Cliente cliente, out List<ValidationResult> erros)
        {
            var contexto = new ValidationContext(cliente);

            erros = new List<ValidationResult>();

            var valido = Validator.TryValidateObject(cliente, contexto, erros, true);
            
            
            if (cliente.DataNascimento == default(DateTime) || cliente.DataNascimento > DateTime.Today)
            {
                erros.Add(new ValidationResult("A data de nascimento é inválida."));
                
                valido = false;
            }
            
            if (!CPFValidado(cliente.CPF))
            {
                erros.Add(new ValidationResult("O CPF é inválido."));
                valido = false;
            }

            return valido;
        }

        private bool CPFValidado(string cpf)
        {
            if (string.IsNullOrEmpty(cpf) || cpf.Length != 11)
            {
                return false;
            }

            for (int i = 0; i < 11; i++)
            {
                if (cpf[i] < '0' || cpf[i] > '9')
                {
                    return false;
                }
            }

            bool Igual = true;
            for (int i = 1; i < 11 && Igual; i++)
            {
                if (cpf[i] != cpf[0])
                {
                    Igual = false;
                    break;
                }
            }
            if (Igual) { return false; }
            
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += (cpf[i] - '0') * (10 - i);
            }
            int resto = soma % 11;
            
            int digito1 = 0;
            if (resto >= 2)
            {
                digito1 = 11 - resto;
            }

            if (digito1 != (cpf[9] - '0'))
            {
                return false;
            }

            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += (cpf[i] - '0') * (11 - i);
            }
            resto = soma % 11;
            
            int digito2 = 0;
            if (resto >= 2)
            {
                digito2 = 11 - resto;
            }

            return digito2 == (cpf[10] - '0');

        }

        public bool Criar(Cliente cliente, out List<ValidationResult> erros)
        {
            if (!Validar(cliente, out erros))
            {
                return false;
            }
            
            repositorio.Cadastrar(cliente);
            return true;
        }
    }

}
