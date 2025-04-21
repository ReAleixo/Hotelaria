namespace Hotelaria.Domain.Entities
{
    public abstract class Pessoa
    {
        public string Nome { get; protected set; }
        public string Documento { get; protected set; }
        public DateTime DataNascimento { get; protected set; }
    }
}
