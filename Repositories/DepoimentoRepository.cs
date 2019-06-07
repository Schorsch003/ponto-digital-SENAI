using System.Collections.Generic;
using System.IO;
using ponto_digital_SENAI.Models;

namespace ponto_digital_SENAI.Repositories {
    public class DepoimentoRepository {
        private const string PATH = "Database/Depoimentos.csv";
        private List<Depoimento> depoimentos = new List<Depoimento> ();

        public Depoimento Inserir (Depoimento depoimento) {
            if (!File.Exists (PATH)) {
                File.Create (PATH).Close ();
            }
            string dadosDepoimento = $"{depoimento.ID};{depoimento.Nota};{depoimento.Conteudo}\n";
            File.WriteAllText (PATH, dadosDepoimento);
            return depoimento;
        }

        public List<Depoimento> Listar () {
            var registros = File.ReadAllLines (PATH);
            foreach (var item in registros) {
                Depoimento depoimento = new Depoimento ();
                var dados = item.Split (";");
                depoimento.ID = ulong.Parse (dados[0]);
                depoimento.Nota = uint.Parse (dados[1]);
                depoimento.Conteudo = dados[2];
                depoimentos.Add (depoimento);
            }
            return depoimentos;
        }
    }
}