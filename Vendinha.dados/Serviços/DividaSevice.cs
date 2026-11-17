using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Npgsql;
using Vendinha.Dados.Repositorios;
using Vendinha.Negocio;

namespace Vendinha.Dados.Serviços
{
    public class DividaSevice
    {
        private readonly DividaRepositorio repositorio;

        public DividaSevice(DividaRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public bool Validar(Divida divida, out List<ValidationResult> erros)
        {
            erros = new List<ValidationResult>();

            if (divida.ClienteId <= 0) { erros.Add(new ValidationResult("O cliente informado é inválido.")); }

            if (divida.Valor <= 0) { erros.Add(new ValidationResult("O valor da dívida deve ser maior que zero.")); }

            if (divida.Valor > 99999999.99m) { erros.Add(new ValidationResult("O valor da dívida é muito alto.")); }

            if (decimal.Round(divida.Valor, 2) != divida.Valor) { erros.Add(new ValidationResult("O valor deve ter no máximo duas casas decimais.")); }

            return erros.Count == 0;
        }

        public bool Criar(Divida divida, out List<ValidationResult> erros)
        {
            if (!Validar(divida, out erros)) { return false; }

            try
            {
                repositorio.Cadastrar(divida);
                return true;
            }
            catch (PostgresException ex) 
            when ( ex.SqlState == PostgresErrorCodes.UniqueViolation &&
                ex.ConstraintName == "ind_divida_aberta") { erros.Add(new ValidationResult("Este cliente já possui uma dívida em aberto."));

                return false;
            }
            catch (PostgresException ex) when ( ex.SqlState == PostgresErrorCodes.ForeignKeyViolation) 
            { erros.Add(new ValidationResult("O cliente informado não existe no banco."));

                return false;
            }
        }

        public List<Divida> ConsultarPorCliente(int clienteId)
        {
            return repositorio.ConsultarPorCliente(clienteId);
        }

        public bool MarcarComoPaga(int dividaId, int clienteId)
        {
            if (dividaId <= 0 || clienteId <= 0)
            {
                return false;
            }

            return repositorio.MarcarComoPaga(dividaId, clienteId);
        }
    }
}

