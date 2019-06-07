using System.Collections.Generic;
using System.IO;
using ponto_digital_SENAI.Models;

namespace ponto_digital_SENAI.Repositories {
    public class DepoimentoRepository {
        private const string PATH = "Database/Depoimentos.csv";
        private List<Depoimento> depoimentos = new List<Depoimento> ();

        public Depoimento Inserir (Depoimento depoimento) {
            if(!File.Exists(PATH)){
                File.Create(PATH).Close();
            }
            return depoimento;
        }
    }
}