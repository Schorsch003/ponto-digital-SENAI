using System;

namespace ponto_digital_SENAI.Models {
    public class Pacote {
        public ulong ID { get; set; }
        public string Titulo { get; set; }
        public double Preco { get; set; }
        public int TempoSuporte {get;set;}
        public uint QuantFuncionarios {get;set;}
        public string PrecoString { get; set; }
    }
}