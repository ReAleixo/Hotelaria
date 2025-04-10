namespace Hotelaria.Domain.Entities
{
    public class Cliente : Pessoa
    {
        public Guid Id { get; set; }
        public Reserva Reserva { get; set; }

        public Cliente(string nome, string documento, DateTime dataNascimento)
        {
            Nome = ValidarNome(nome);
            Documento = ValidarDocumento(documento);
            DataNascimento = ValidarDataNascimento(dataNascimento);
            Id = Guid.NewGuid();
        }

        public string ValidarNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentNullException("O nome do cliente não pode ser vazio");
            }
            if (Nome.Split().Count() < 2)
            {
                throw new ArgumentException("O nome do cliente deve conter pelo menos um sobrenome");
            }
            return nome;
        }

        public string ValidarDocumento(string documento)
        {
            if (string.IsNullOrEmpty(documento))
            {
                throw new ArgumentNullException("O documento do cliente não pode ser vazio");
            }
            if (documento.Length < 11)
            {
                throw new ArgumentNullException("O documento do cliente deve ter pelo menos 11 caracteres");
            }
            return documento;
        }

        public DateTime ValidarDataNascimento(DateTime dataNascimento)
        {
            if (dataNascimento > DateTime.Now)
            {
                throw new ArgumentException("A data de nascimento não pode ser maior que a data atual");
            }
            return dataNascimento;
        }
    }
}
