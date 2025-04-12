namespace Hotelaria.Domain.Entities
{
    public class Funcionario : Pessoa
    {
        public Guid Id { get; set; }
        public string Cargo { get; set; }
        public decimal Salario { get; set; }

        public Funcionario(
            string nome,
            string documento,
            DateTime dataNascimento,
            string cargo,
            decimal salario)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Documento = documento;
            DataNascimento = dataNascimento;
            Cargo = cargo;
            Salario = salario;
            ValidarDadosCadastro();
        }

        public void ValidarDadosCadastro()
        {
            if (string.IsNullOrEmpty(Nome))
            {
                throw new ArgumentException("Nome do funcionário não pode ser vazio.");
            }
            if (string.IsNullOrEmpty(Documento))
            {
                throw new ArgumentException("Documento do funcionário não pode ser vazio.");
            }
            if (DataNascimento == default)
            {
                throw new ArgumentException("Data de nascimento do funcionário não pode ser vazia.");
            }
            if (string.IsNullOrEmpty(Cargo))
            {
                throw new ArgumentException("Cargo do funcionário não pode ser vazio.");
            }
            if (Salario <= 0)
            {
                throw new ArgumentException("Salário do funcionário deve ser maior que zero.");
            }
        }
    }
}
