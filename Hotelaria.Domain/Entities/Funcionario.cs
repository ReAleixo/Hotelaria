namespace Hotelaria.Domain.Entities
{
    public class Funcionario : Pessoa
    {
        public Guid Id { get; set; }
        public string Cargo { get; set; }
        public decimal Salario { get; set; }

        public Funcionario()
        {

        }

        public void LimparQuarto(Quarto quarto)
        {
            quarto.EstaLimpo = true;
        }
    }
}
