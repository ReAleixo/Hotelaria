using Hotelaria.Domain.Entities;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;

namespace Hotelaria.Tests.Domain
{
    public class FuncionarioTests
    {
        [Fact]
        public void InstanceCreatesSuccessfully()
        {
            string nome = "Maria Oliveira";
            string cpf = "98765432100";
            DateTime dataNascimento = new DateTime(1985, 5, 15);
            string cargo = "Gerente";
            decimal salario = 5000;
            Funcionario funcionario = new Funcionario(nome, cpf, dataNascimento, cargo, salario);
            Assert.NotNull(funcionario);
        }

        [Theory]
        [InlineData("Maria", "98765432100", "1985-05-15", "Gerente", "5000")]
        [InlineData("Maria Oliveira", "9876543210", "1985-05-15", "Gerente", "5000")]
        [InlineData("Maria Oliveira", "98765432100", "", "Gerente", "5000")]
        [InlineData("Maria Oliveira", "98765432100", "2025-12-31", "Gerente", "5000")]
        [InlineData("Maria Oliveira", "98765432100", "1985-05-15", "Gerente", "")]

        public void InstanceThrowsArgumentException(string nome, string cpf, string dataNascimento, string cargo, string salario)
        {
            if (!DateTime.TryParse(dataNascimento, out DateTime dataNascimentoConvertida))
            {
                dataNascimentoConvertida = default;
            }

            if (!decimal.TryParse(salario, out decimal salarioConvertido))
            {
                salarioConvertido = default;
            }

            Assert.Throws<ArgumentException>(() => new Funcionario(nome, cpf, dataNascimentoConvertida, cargo, salarioConvertido));
        }

        [Theory]
        [InlineData("", "98765432100", "1985-05-15", "Gerente", "5000")]
        [InlineData("Maria Oliveira", "", "1985-05-15", "Gerente", "5000")]
        [InlineData("Maria Oliveira", "98765432100", "1985-05-15", "", "5000")]
        public void InstanceThrowsArgumentNullException(string nome, string cpf, string dataNascimento, string cargo, string salario)
        {
            DateTime dataNascimentoConvertida = DateTime.Parse(dataNascimento);
            decimal salarioConvertido = decimal.Parse(salario);
            Assert.Throws<ArgumentNullException>(() => new Funcionario(nome, cpf, dataNascimentoConvertida, cargo, salarioConvertido));
        }
    }
}
