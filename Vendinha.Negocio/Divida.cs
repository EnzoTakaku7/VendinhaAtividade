using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Vendinha.Negocio
{
    public class Divida
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public decimal Valor { get; set; }

        public bool Paga { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataPagamento { get; set; }

        public Divida(int clienteId, decimal valor)
        {
            this.ClienteId = clienteId;
            this.Valor = valor;
        }
    }
}

