﻿using Hotelaria;

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

hotel.QuartosDisponiveis = hotel.Quartos.Where(x => x.QuartoDisponivel).ToList();


Reserva reserva = new Reserva(hotel, hotel.QuartosDisponiveis.First(), DateTime.Now, DateTime.Now.AddDays(3), 2);
Console.WriteLine(reserva.ConferirQuartosDisponiveis(hotel));

hotel.Quartos[default].QuartoDisponivel = false;
hotel.QuartosDisponiveis = hotel.Quartos.Where(x => x.QuartoDisponivel).ToList();
Console.WriteLine(reserva.ConferirQuartosDisponiveis(hotel));

Console.ReadKey();

