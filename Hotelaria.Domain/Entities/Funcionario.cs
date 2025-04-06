namespace Hotelaria.Domain.Entities
{
    public class Funcionario : Pessoa
    {
        public string Cargo { get; set; }
        public double Salario { get; set; }

        public Funcionario()
        {

        }

        public void LimparQuarto(Quarto quarto)
        {
            quarto.EstaLimpo = true;
        }
    }
}
