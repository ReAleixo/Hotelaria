using System.Runtime.CompilerServices;

namespace Hotelaria.Domain.Entities
{
    public class Funcionario : Pessoa
    {
        public Guid Id { get; private set; }
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
                throw new ArgumentNullException("Nome do funcionário não pode ser vazio.");
            }
            if (Nome.Split().Count() < 2)
            {
                throw new ArgumentException("O nome do funcionário deve conter pelo menos um sobrenome");
            }
            if (string.IsNullOrEmpty(Documento))
            {
                throw new ArgumentNullException("Documento do funcionário não pode ser vazio.");
            }
            if (Documento.Length < 11)
            {
                throw new ArgumentException("O documento do funcionário deve ter pelo menos 11 caracteres");
            }
            if (DataNascimento == default)
            {
                throw new ArgumentException("Data de nascimento do funcionário é inválida.");
            }
            if (DataNascimento > DateTime.Now)
            {
                throw new ArgumentException("A data de nascimento do funcionário não pode ser maior que a data atual");
            }
            if (string.IsNullOrEmpty(Cargo))
            {
                throw new ArgumentNullException("Cargo do funcionário não pode ser vazio.");
            }
            if (Salario <= decimal.Zero)
            {
                throw new ArgumentException("Salário do funcionário deve ser maior que zero.");
            }
        }
    }
}
