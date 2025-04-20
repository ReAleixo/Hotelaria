using Hotelaria.Domain.ValueObject;

namespace Hotelaria.Domain.Entities
{
    public class Hotel
    {
        public Guid Id { get; }
        public string Nome { get; }
        public List<Quarto> Quartos { get; }
        public List<Quarto> QuartosDisponiveis { get; private set; }
        public int NumeroAndares { get; }
        public Endereco Endereco { get; }
        public List<Funcionario> Funcionarios { get; private set; }
        public List<Cliente> Clientes { get; private set; }
        public List<Reserva> Reservas { get; private set; }

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
            AtualizaQuartosDisponiveis();
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

        public void AtualizaQuartosDisponiveis()
        {
            QuartosDisponiveis = Quartos.Where(x => x.EstaDisponivel).ToList();
        }

        public void SetQuartoOcupado(Quarto quarto)
        {
            if (!Quartos.Contains(quarto))
            {
                throw new Exception("Quarto não encontrado no hotel.");
            }

            if (!quarto.EstaDisponivel)
            {
                throw new Exception("Quarto já está ocupado.");
            }

            if (!quarto.EstaLimpo)
            {
                throw new Exception("Quarto não está limpo.");
            }

            quarto.EstaDisponivel = false;
            AtualizaQuartosDisponiveis();
        }

        public void SetQuartoDisponivel(Quarto quarto)
        {
            if (!Quartos.Contains(quarto))
            {
                throw new Exception("Quarto não encontrado no hotel.");
            }

            quarto.EstaDisponivel = true;
            quarto.EstaLimpo = false;
            AtualizaQuartosDisponiveis();
        }

        public void SetQuartoLimpo(Quarto quarto)
        {
            if (!Quartos.Contains(quarto))
            {
                throw new Exception("Quarto não encontrado no hotel.");
            }
            if (quarto.EstaLimpo)
            {
                throw new Exception("Quarto já está limpo.");
            }

            quarto.EstaLimpo = true;
        }

        public void AdicionarFuncionario(Funcionario funcionario)
        {
            if (Funcionarios == null)
            {
                Funcionarios = new List<Funcionario>();
            }
            if (funcionario == null)
            {
                throw new ArgumentNullException("Funcionário não pode ser nulo.");
            }
            funcionario.ValidarDadosCadastro();
            if (Funcionarios.Contains(funcionario))
            {
                throw new Exception("Funcionário já cadastrado.");
            }

            Funcionarios.Add(funcionario);
        }

        public void RemoverFuncionario(Funcionario funcionario)
        {
            if (Funcionarios == null || Funcionarios.Count.Equals(default))
            {
                throw new Exception("Não há funcionários cadastrados.");
            }
            if (funcionario == null)
            {
                throw new ArgumentNullException("Funcionário não pode ser nulo.");
            }
            if (!Funcionarios.Contains(funcionario))
            {
                throw new Exception("Funcionário não encontrado.");
            }
            Funcionarios.Remove(funcionario);
        }

        public void AdicionarCliente(Cliente cliente)
        {
            if (Clientes == null)
            {
                Clientes = new List<Cliente>();
            }
            if (cliente == null)
            {
                throw new ArgumentNullException("Cliente não pode ser nulo.");
            }
            cliente.ValidarDadosCadastro();
            if (Clientes.Contains(cliente))
            {
                throw new Exception("Cliente já cadastrado.");
            }
            Clientes.Add(cliente);
        }

        public void RemoverCliente(Cliente cliente)
        {
            if (Clientes == null || Clientes.Count.Equals(default))
            {
                throw new Exception("Não há clientes cadastrados.");
            }
            if (cliente == null)
            {
                throw new ArgumentNullException("Cliente não pode ser nulo.");
            }
            if (!Clientes.Contains(cliente))
            {
                throw new Exception("Cliente não encontrado.");
            }
            Clientes.Remove(cliente);
        }

        public void CriarReserva(Quarto quarto, Cliente cliente)
        {
            if (QuartosDisponiveis == null || QuartosDisponiveis.Count.Equals(default))
            {
                throw new Exception("O hotel escolhido não possui quartos disponíveis no momento.");
            }
            if (!Quartos.Contains(quarto))
            {
                throw new Exception($"O hotel {Nome} não tem o quarto selecionado.");
            }
            if (!QuartosDisponiveis.Contains(quarto)
                || !quarto.EstaDisponivel)
            {
                throw new Exception($"O quarto {quarto.Numero} não está disponível no momento.");
            }
            if (!quarto.EstaLimpo)
            {
                throw new Exception($"O quarto {quarto.Numero} não está limpo.");
            }

            Reserva reserva = new Reserva(
                cliente,
                quarto,
                DateTime.Now,
                DateTime.Now.AddDays(3));
        }
    }
}
