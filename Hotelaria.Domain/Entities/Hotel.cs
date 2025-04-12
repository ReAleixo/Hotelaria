using Hotelaria.Domain.ValueObject;

namespace Hotelaria.Domain.Entities
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public List<Quarto> Quartos { get; set; }
        public List<Quarto> QuartosDisponiveis { get; set; }
        public int NumeroAndares { get; set; }
        public Endereco Endereco { get; set; }

        public Hotel(
            string nome,
            Endereco endereco,
            int numeroAndares,
            List<Quarto> quartos)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Endereco = endereco;
            NumeroAndares = numeroAndares;
            Quartos = quartos;
            QuartosDisponiveis = GetQuartosDisponiveis();
            ValidarDadosCadastro();
        }

        public void ValidarDadosCadastro()
        {
            if (string.IsNullOrEmpty(Nome))
            {
                throw new ArgumentException("Nome do hotel não pode ser vazio.");
            }
            if (Endereco == null)
            {
                throw new ArgumentException("Endereço do hotel não pode ser nulo.");
            }
            Endereco.ValidarDadosCadastro();
            if (NumeroAndares <= 0)
            {
                throw new ArgumentException("Número de andares deve ser maior que zero.");
            }
            if (Quartos == null || Quartos.Count.Equals(default))
            {
                throw new ArgumentException("O hotel deve ter pelo menos um quarto.");
            }
        }

        public List<Quarto> GetQuartosDisponiveis()
        {
             return Quartos.Where(x => x.EstaDisponivel).ToList();
        }

        public void SetQuartoOcupado(Quarto quarto)
        {
            if (!Quartos.Contains(quarto))
            {
                throw new Exception("Quarto não encontrado no hotel.");
            }

            if (!quarto.EstaDisponivel)
            {
                throw new Exception("Quarto não está disponível.");
            }

            if (!quarto.EstaLimpo)
            {
                throw new Exception("Quarto não está limpo.");
            }

            quarto.EstaDisponivel = false;
            GetQuartosDisponiveis();
        }

        public void SetQuartoDisponivel(Quarto quarto)
        {
            if (!Quartos.Contains(quarto))
            {
                throw new Exception("Quarto não encontrado no hotel.");
            }

            quarto.EstaDisponivel = true;
            quarto.EstaLimpo = false;
            GetQuartosDisponiveis();
        }
    }
}
