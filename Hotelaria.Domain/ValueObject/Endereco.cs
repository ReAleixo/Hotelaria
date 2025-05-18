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
            string bairro,
            string cidade,
            string estado,
            string cep,
            string complemento = null)
        {
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
            Complemento = complemento;
            ValidarDadosCadastro();
        }

        public void ValidarDadosCadastro()
        {
            if (string.IsNullOrEmpty(Logradouro))
            {
                throw new ArgumentNullException("Logradouro não pode ser vazio.");
            }
            if (Numero <= 0)
            {
                throw new ArgumentException("Número deve ser maior que zero.");
            }
            if (string.IsNullOrEmpty(Bairro))
            {
                throw new ArgumentNullException("Bairro não pode ser vazio.");
            }
            if (string.IsNullOrEmpty(Cidade))
            {
                throw new ArgumentNullException("Cidade não pode ser vazia.");
            }
            if (string.IsNullOrEmpty(Estado))
            {
                throw new ArgumentNullException("Estado não pode ser vazio.");
            }
            if (string.IsNullOrEmpty(CEP))
            {
                throw new ArgumentNullException("CEP não pode ser vazio.");
            }
        }

        public override string ToString()
        {
            return $"{Logradouro}, {Numero}, {Bairro}, {Cidade} - {Estado}, {CEP}";
        }
    }
}