namespace Vendinha.Negocio
{
    public class Cliente
    {
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Email { get; set; }
        public int Id { get; set; }

        public Cliente(string nomeCompleto, string cpf, DateTime dataNascimento)
        {
            this.NomeCompleto = nomeCompleto;
            this.CPF = cpf;
            this.DataNascimento = dataNascimento;
        }

    }
}
