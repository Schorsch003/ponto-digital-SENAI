using System;
using System.Collections.Generic;
using System.IO;
using ponto_digital_final.Models;

namespace ponto_digital_final.Repositories {
    public class UsuarioRepository {
        private const string PATH = "Database/Usuarios.csv";
        private const string PATH_ADMIN = "Database/Admins.csv";

        private List<Usuario> usuarios;
        private List<Usuario> admins = new List<Usuario> ();

        public Usuario InserirUsuario (Usuario user) {

            if (!File.Exists (PATH)) {
                File.Create (PATH).Close ();
            }
            user.ID = (ulong) File.ReadAllLines (PATH).Length + 1;
            string info_usuario = $"{user.ID};{user.Nome} ;{user.Email};{user.Senha};{user.DataNascimento.ToShortDateString()};{user.EhAdmin}";
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

        public List<Usuario> ListarAdmins () {
            var lista = Listar ();
            foreach (var item in lista) {
                if (item.EhAdmin) {
                    admins.Add (item);
                }

            }
            return admins;
        }

        public Usuario ObterPor (string email) {
            var listaUsuarios = Listar ();
            var listaAdmins = ListarAdmins ();
            if (!listaUsuarios.Equals (null)) {
                foreach (var item in listaUsuarios) {
                    if (!item.Equals (null) && email.Equals (item.Email)) {
                        return item;
                    }
                }
                foreach (var item in listaAdmins) {
                    if (!item.Equals (null) && email.Equals (item.Email)) {
                        return item;
                    }
                }
            }

            return null;
        }

        public Usuario ObterPor (ulong id) {
            var listaUsuarios = Listar ();
            var listaAdmins = ListarAdmins ();
            if (!listaUsuarios.Equals (null)) {
                foreach (var item in listaUsuarios) {
                    if (!item.Equals (null) && id.Equals (item.ID)) {
                        return item;
                    }
                }
            }

            return null;
        }

        public Usuario ObterAdmPor (ulong id) {
            var listaAdmins = ListarAdmins ();
            if (!listaAdmins.Equals (null)) {
                foreach (var item in listaAdmins) {
                    if (!item.Equals (null) && id.Equals (item.ID)) {
                        return item;
                    }
                }
            }

            return null;
        }
        public Usuario ObterAdmPor (string email) {
            var listaAdmins = ListarAdmins ();
            if (!listaAdmins.Equals (null)) {
                foreach (var item in listaAdmins) {
                    if (!item.Equals (null) && email.Equals (item.ID)) {
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
            if (user.EhAdmin) {
                user.EhAdmin = false;
            } else {
                user.EhAdmin = true;
            }
            return user;
        }
        public Usuario RemoverUsuario (Usuario user) {
            var registros = File.ReadAllLines (PATH);
            Console.WriteLine ("AAAA");

            for (int i = 0; i < registros.Length; i++) {
                if (string.IsNullOrEmpty (registros[i])) {
                    Console.WriteLine ("BBBB");
                    continue;
                }
                var dados = registros[i].Split (";");
                if (user.ID.Equals (ulong.Parse (dados[0]))) {
                    registros[i] = null;
                    Console.WriteLine ("CCCC");
                    File.WriteAllLines (PATH_ADMIN, registros);
                    return user;
                }
            }
            return user;
        }

    }
}