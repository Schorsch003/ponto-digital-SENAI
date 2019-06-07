using System;
using System.Collections.Generic;
using System.IO;
using ponto_digital_SENAI.Models;

namespace ponto_digital_SENAI.Repositories {
    public class PacotesRepository {
        private List<Pacote> pacotes = new List<Pacote> ();
        private const string PATH = "Database/Pacotes.csv";

        public List<Pacote> Listar () {
            if (!File.Exists (PATH)) {
                File.Create (PATH);
                string[] linhas = {
                    "1;Pacote simples;29,99\n"
                };
                File.WriteAllLines (PATH, linhas);
            }
            var registros = File.ReadAllLines (PATH);
            foreach (var item in registros) {
                Pacote pacote = new Pacote ();
                var dados = item.Split (";");
                pacote.ID = ulong.Parse (dados[0]);
                pacote.Titulo = dados[1];
                pacote.Preco = double.Parse(dados[2]);
                pacote.TempoSuporte = int.Parse(dados[3]);
                pacote.QuantFuncionarios = uint.Parse(dados[4]);

                pacotes.Add (pacote);

            }
            return pacotes;
        }

    }
}