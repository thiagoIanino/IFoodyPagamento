﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IFoody.Domain.Entities
{
   public class Cliente
    {
        public Cliente(Guid id, string nome, string email, string idStripe)
        {
            Id = id;
            Nome = nome;
            Email = email;
            IdStripe = idStripe;
        }

        public Guid Id { get; set; }
        public string IdStripe { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    
    }
}
