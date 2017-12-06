using System;

namespace ExemploCRUD
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public string EmailCliente { get; set; }
        public string CPF { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}