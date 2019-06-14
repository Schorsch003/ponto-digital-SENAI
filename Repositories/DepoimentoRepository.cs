using System;
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

            string dadosDepoimento = $"{depoimento.ID};{depoimento.NomeUsuario};{depoimento.Nota};{depoimento.Conteudo};{depoimento.Status};{depoimento.DataEnvio}\n";
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
                depoimento.Status = char.Parse (dados[4]);
                depoimento.DataEnvio = DateTime.Parse(dados[5]);
                depoimentos.Add (depoimento);
            }
            return depoimentos;
        }

        public Depoimento AprovarDepoimento (Depoimento depoimento) {
            var registros = File.ReadAllLines (PATH);
            for (int i = 0; i < registros.Length; i++) {
                if (registros[i] == null) {
                    continue;
                }
                var dados = registros[i].Split (';');
                if (ulong.Parse (dados[0]) == depoimento.ID) {
                    registros[i] = $"{depoimento.ID};{depoimento.NomeUsuario};{depoimento.Nota};{depoimento.Conteudo};a;{depoimento.DataEnvio}";
                }
            }
            System.Console.WriteLine("foi certinho");
            File.WriteAllLines (PATH, registros);
            return depoimento;
        }

        public Depoimento ReprovarDepoimento (Depoimento depoimento) {
            var registros = File.ReadAllLines (PATH);
            for (int i = 0; i < registros.Length; i++) {
                if (registros[i] == null) {
                    continue;
                }
                var dados = registros[i].Split (';');
                if (ulong.Parse (dados[0]) == depoimento.ID) {
                    registros[i] = $"{depoimento.ID};{depoimento.NomeUsuario};{depoimento.Nota};{depoimento.Conteudo};r;{depoimento.DataEnvio}";
                }
            }
            System.Console.WriteLine("foi certinho");
            File.WriteAllLines (PATH, registros);
            return depoimento;
        }

        public Depoimento ObterPor (ulong id) {
            var lista = Listar ();
            foreach (var item in lista) {
                if (item.ID == id) {
                    return item;
                }
            }
            return null;
        }
    }
}