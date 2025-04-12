namespace Hotelaria.Domain.Entities
{
    public class Quarto
    {
        public Guid Id { get; set; }
        public int Numero { get; set; }
        public int MetrosQuadrados { get; set; }
        public int NumeroComodos { get; set; }
        public int NumeroCamas { get; set; }
        public decimal Preco { get; set; }
        public bool EstaDisponivel { get; set; }
        public bool EstaLimpo { get; set; }

        public Quarto(
            int numero,
            int metrosQuadrados,
            int numeroComodos,
            int numeroCamas,
            decimal preco)
        {
            Id = Guid.NewGuid();
            Numero = numero;
            MetrosQuadrados = metrosQuadrados;
            NumeroComodos = numeroComodos;
            NumeroCamas = numeroCamas;
            Preco = preco;
            EstaDisponivel = true;
            EstaLimpo = true;
            ValidarDadosCadastro();
        }

        public void ValidarDadosCadastro()
        {
            if (Numero <= 0)
            {
                throw new ArgumentException("Número do quarto deve ser maior que zero.");
            }
            if (MetrosQuadrados <= 0)
            {
                throw new ArgumentException("Metros quadrados do quarto deve ser maior que zero.");
            }
            if (NumeroComodos <= 0)
            {
                throw new ArgumentException("Número de cômodos do quarto deve ser maior que zero.");
            }
            if (NumeroCamas <= 0)
            {
                throw new ArgumentException("Número de camas do quarto deve ser maior que zero.");
            }
            if (Preco <= 0)
            {
                throw new ArgumentException("Preço do quarto deve ser maior que zero.");
            }
        }
    }
}
