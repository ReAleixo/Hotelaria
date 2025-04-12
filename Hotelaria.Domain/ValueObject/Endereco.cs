namespace Hotelaria.Domain.ValueObject
{
    public class Endereco
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }

        public Endereco(
            string logradouro,
            int numero,
            string complemento,
            string bairro,
            string cidade,
            string estado,
            string cep)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
            ValidarDadosCadastro();
        }

        public void ValidarDadosCadastro()
        {
            if (string.IsNullOrEmpty(Logradouro))
            {
                throw new ArgumentException("Logradouro não pode ser vazio.");
            }
            if (Numero <= 0)
            {
                throw new ArgumentException("Número deve ser maior que zero.");
            }
            if (string.IsNullOrEmpty(Bairro))
            {
                throw new ArgumentException("Bairro não pode ser vazio.");
            }
            if (string.IsNullOrEmpty(Cidade))
            {
                throw new ArgumentException("Cidade não pode ser vazia.");
            }
            if (string.IsNullOrEmpty(Estado))
            {
                throw new ArgumentException("Estado não pode ser vazio.");
            }
            if (string.IsNullOrEmpty(CEP))
            {
                throw new ArgumentException("CEP não pode ser vazio.");
            }
        }
    }
}