using System;

namespace ponto_digital_final.Models {
    public class Usuario {
        public ulong ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}