using System;

namespace ponto_digital_SENAI.Models {
    public class Depoimento {
        public ulong ID { get; set; }
        public string NomeUsuario { get; set; }
        public string Conteudo { get; set; }
        public uint Nota { get; set; }
        public char Status { get; set; }
        public DateTime DataEnvio { get; set; }
    }
}