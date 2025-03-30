using Hotelaria;

Hotel hotel = new Hotel
{
    Nome = "Hotel Teste",
    NumeroAndares = 3,
    Endereco = new Endereco
    {
        Logradouro = "Rua Teste",
        Numero = 123,
        Bairro = "Bairro Teste",
        Cidade = "Cidade Teste",
        Estado = "Estado Teste",
        CEP = "12345-678"
    }
};

List<Quarto> quartos = new List<Quarto>
{
    new Quarto
    {
        Numero = 1,
        Preco = 100,
        QuartoDisponivel = true
    },
    new Quarto
    {
        Numero = 2,
        Preco = 200,
        QuartoDisponivel = false
    },
    new Quarto
    {
        Numero = 3,
        Preco = 300,
        QuartoDisponivel = false
    }
};

hotel.Quartos = quartos;

