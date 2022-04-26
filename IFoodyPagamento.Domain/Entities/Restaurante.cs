using System;
using System.Collections.Generic;
using System.Text;

namespace IFoody.Domain.Entities.Restaurantes
{
    public class Restaurante
    {
        public Restaurante(Guid id, string nomeRestaurante, string idStripe)
        {
            Id = id;
            IdStripe = idStripe;
            NomeRestaurante = nomeRestaurante;
        }

        public Guid Id { get; set; }
        public string IdStripe { get; set; }
        public string NomeRestaurante { get; set;}

    }
}
