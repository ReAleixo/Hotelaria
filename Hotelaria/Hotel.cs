using Hotelaria.ValueObject;

namespace Hotelaria
{
    public class Hotel
    {
        public string Nome { get; set; }
        public List<Quarto> Quartos { get; set; }
        public List<Quarto>? QuartosDisponiveis { get; set; }
        public int NumeroAndares { get; set; }
        public Endereco Endereco { get; set; }

        public Hotel(string nome, Endereco endereco, int numeroAndares, List<Quarto> quartos)
        {
            Nome = nome;
            Endereco = endereco;
            NumeroAndares = numeroAndares;
            Quartos = quartos;
            AtualizaQuartosDisponiveis();
        }

        public void AtualizaQuartosDisponiveis()
        {
            QuartosDisponiveis = Quartos.Where(x => x.Disponivel).ToList();
        }

        public string ConfereQuartosDisponiveis()
        {
            if (QuartosDisponiveis == null || QuartosDisponiveis.Count.Equals(default))
            {
                return "O hotel escolhido não possui quartos disponíveis no momento.";
            }

            if (QuartosDisponiveis.Count.Equals(1))
            {
                return $"O hotel {Nome} possui disponível apenas o quarto {QuartosDisponiveis}.";
            }

            return $"O hotel {Nome} possui os seguintes quartos dísponíveis: {QuartosDisponiveis}";
        }

        public void SetQuartoOcupado(Quarto quarto)
        {
            if (Quartos.Contains(quarto))
            {
                quarto.Disponivel = false;
                AtualizaQuartosDisponiveis();
                return;
            }
            throw new Exception("Quarto não encontrado no hotel.");
        }

        public void SetQuartoDisponivel(Quarto quarto)
        {
            if (Quartos.Contains(quarto))
            {
                quarto.Disponivel = true;
                AtualizaQuartosDisponiveis();
                return;
            }
            throw new Exception("Quarto não encontrado no hotel.");
        }

    }
}
