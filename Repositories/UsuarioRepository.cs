using System;
using System.Collections.Generic;
using System.IO;
using ponto_digital_final.Models;

namespace ponto_digital_final.Repositories {
    public class UsuarioRepository {
        private const string PATH = "Database/Usuarios.csv";

        private List<Usuario> usuarios;
        private List<Usuario> admins = new List<Usuario> ();

        public Usuario InserirUsuario (Usuario user) {

            if (!File.Exists (PATH)) {
                File.Create (PATH).Close ();
            }
            user.ID = (ulong) File.ReadAllLines (PATH).Length + 1;
            string info_usuario = $"{user.ID};{user.Nome} ;{user.Email};{user.Senha};{user.DataNascimento.ToShortDateString()};{user.EhAdmin.ToString()}\n";
            File.AppendAllText (PATH, info_usuario);

            return user;
        }

        public List<Usuario> Listar () {
            usuarios = new List<Usuario> ();
            var registros = File.ReadAllLines (PATH);
            foreach (var item in registros) {
                if (string.IsNullOrEmpty (item)) {
                    continue;
                }
                var user = ConverterEmObjeto (item);
                usuarios.Add (user);
            }
            return usuarios;
        }

        public Usuario ObterPor (string email) {
            var listaUsuarios = Listar ();
            if (!listaUsuarios.Equals (null)) {
                foreach (var item in listaUsuarios) {
                    if (!item.Equals (null) && email.Equals (item.Email)) {
                        return item;
                    }
                }
            }

            return null;
        }

        public Usuario ObterPor (ulong id) {
            var listaUsuarios = Listar ();
            if (!listaUsuarios.Equals (null)) {
                foreach (var item in listaUsuarios) {
                    if (!item.Equals (null) && id.Equals (item.ID)) {
                        return item;
                    }
                }
            }
            return null;
        }
        public Usuario ConverterEmObjeto (string registro) {

            var dados = registro.Split (";");

            Usuario user = new Usuario ();

            user.ID = ulong.Parse (dados[0]);
            user.Nome = dados[1];
            user.Email = dados[2];
            user.Senha = dados[3];
            user.DataNascimento = DateTime.Parse (dados[4]);
            user.EhAdmin = bool.Parse (dados[5]);
            return user;
        }
        public Usuario ConverterEmObjeto (string registro, bool admin) {

            var dados = registro.Split (";");

            Usuario user = new Usuario ();

            user.ID = ulong.Parse (dados[0]);
            user.Nome = dados[1];
            user.Email = dados[2];
            user.Senha = dados[3];
            user.DataNascimento = DateTime.Parse (dados[4]);
            user.EhAdmin = bool.Parse (dados[5]);

            return user;
        }

        public Usuario AlterarPermissao (Usuario user) {
            var registros = File.ReadAllLines (PATH);
            string linha = "";
            for (int i = 0; i < registros.Length; i++) {
                var dados = registros[i].Split (";");
                if (bool.Parse (dados[5]) && ulong.Parse (dados[0]) == user.ID) {
                    dados[5] = "false";
                    linha = $"{dados[0]};{dados[1]};{dados[2]};{dados[3]};{dados[4]};{dados[5]}";
                    System.Console.WriteLine ("virou falso");
                    registros[i] = linha;
                } else if (!bool.Parse (dados[5]) && ulong.Parse (dados[0]) == user.ID) {
                    dados[5] = "true";
                    System.Console.WriteLine ("virou true");
                    linha = $"{dados[0]};{dados[1]};{dados[2]};{dados[3]};{dados[4]};{dados[5]}";
                    registros[i] = linha;
                }
            }
            File.WriteAllLines (PATH, registros);
            return user;
        }
        public Usuario RemoverUsuario (Usuario user) {
            var registros = File.ReadAllLines (PATH);
            Console.WriteLine ("AAAA");
            for (int j = 0; j < registros.Length; j++) {
                var dados = registros[j].Split (";");
                if (user.ID == ulong.Parse (dados[0])) {
                    registros[j] = "";
                    System.Console.WriteLine ("BBBBBB");
                    break;  
                }
            }
            System.Console.WriteLine ("CCCC");
            File.WriteAllLines (PATH, registros);

            return user;
        }

    }
}