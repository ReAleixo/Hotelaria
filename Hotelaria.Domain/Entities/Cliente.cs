namespace Hotelaria.Domain.Entities
{
    public class Cliente : Pessoa
    {
        public Guid Id { get; private set; }

        public Cliente(
            string nome,
            string documento,
            DateTime dataNascimento)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Documento = documento;
            DataNascimento = dataNascimento;
            ValidarDadosCadastro();
        }

        public void ValidarDadosCadastro()
        {
            if (string.IsNullOrEmpty(Nome))
            {
                throw new ArgumentNullException("O nome do cliente não pode ser vazio");
            }
            if (Nome.Split().Count() < 2)
            {
                throw new ArgumentException("O nome do cliente deve conter pelo menos um sobrenome");
            }
            if (string.IsNullOrEmpty(Documento))
            {
                throw new ArgumentNullException("O documento do cliente não pode ser vazio");
            }
            if (Documento.Length < 11)
            {
                throw new ArgumentNullException("O documento do cliente deve ter pelo menos 11 caracteres");
            }
            if (DataNascimento > DateTime.Now)
            {
                throw new ArgumentException("A data de nascimento não pode ser maior que a data atual");
            }
        }
    }
}
