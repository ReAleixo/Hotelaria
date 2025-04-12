namespace Hotelaria.Domain.Entities
{
    public abstract class Pessoa
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
