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
    internal class ClienteSevice
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

            return valido;
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
