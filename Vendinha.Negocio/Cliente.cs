using System.ComponentModel.DataAnnotations;

namespace Vendinha.Negocio
{
    public class Cliente
    {

        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [StringLength(150)]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(11, MinimumLength = 11)]
        [RegularExpression("^[a-zA-Z ]+$")]
        public string CPF { get; set; }


        public DateTime DataNascimento { get; set; }


        [EmailAddress(ErrorMessage = "O email não é válido.")]
        public string? Email { get; set; }
        public int Id { get; set; }

        public int Idade
        {
            get
            {
                var hoje = DateTime.Today;
                
                var idade = hoje.Year - DataNascimento.Year;

                var hojeAnoNascimento = hoje.AddYears(-idade);

                if (DataNascimento.Date > hojeAnoNascimento)
                {
                    idade--;
                }

                return idade;
            }
        }

        public Cliente(string nomeCompleto, string cpf, DateTime dataNascimento)
        {
            this.NomeCompleto = nomeCompleto;
            this.CPF = cpf;
            this.DataNascimento = dataNascimento;
        }

    }
}
