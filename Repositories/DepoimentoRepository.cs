using System.Collections.Generic;
using System.IO;
using ponto_digital_final.Models;
using ponto_digital_final.Repositories;
using ponto_digital_SENAI.Models;

namespace ponto_digital_SENAI.Repositories {
    public class DepoimentoRepository {
        private const string PATH = "Database/Depoimentos.csv";
        private List<Depoimento> depoimentos = new List<Depoimento> ();
        private UsuarioRepository usuarioRepository = new UsuarioRepository ();

        public Depoimento Inserir (Depoimento depoimento) {
            if (!File.Exists (PATH)) {
                File.Create (PATH).Close ();
            }
            depoimento.ID = (ulong) File.ReadAllLines (PATH).Length + 1;

            string dadosDepoimento = $"{depoimento.ID};{depoimento.NomeUsuario};{depoimento.Nota};{depoimento.Conteudo}\n";
            File.AppendAllText (PATH, dadosDepoimento);
            return depoimento;
        }

        public List<Depoimento> Listar () {
            var registros = File.ReadAllLines (PATH);
            foreach (var item in registros) {
                Depoimento depoimento = new Depoimento ();
                var dados = item.Split (";");
                depoimento.ID = ulong.Parse (dados[0]);
                depoimento.NomeUsuario = dados[1];
                depoimento.Nota = uint.Parse (dados[2]);
                depoimento.Conteudo = dados[3];
                depoimentos.Add (depoimento);
            }
            return depoimentos;
        }
    }
}