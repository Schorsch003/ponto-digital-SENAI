using System;
using System.Collections.Generic;
using System.IO;
using ponto_digital_final.Models;

namespace ponto_digital_final.Repositories {
    public class UsuarioRepository {
        private const string PATH = "Database/Usuarios.csv";
        private const string PATH_ADMIN = "Database/Admins.csv";

        private List<Usuario> usuarios = new List<Usuario> ();
        private List<Usuario> admins = new List<Usuario> ();

        public Usuario InserirUsuario (Usuario user) {
            if (!File.Exists (PATH)) {
                File.Create (PATH).Close ();
            }
            user.ID = (ulong) File.ReadAllLines (PATH).Length + 1;
            string info_usuario = $"{user.ID};{user.Nome} ;{user.Email};{user.Senha};{user.DataNascimento.ToShortDateString()}";
            File.AppendAllText (PATH, info_usuario);

            return user;
        }

        public List<Usuario> Listar () {
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
            var registros = File.ReadAllLines (PATH_ADMIN);
            foreach (var item in registros) {
                var user = ConverterEmObjeto (item, true);
                admins.Add (user);
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
                if (!listaAdmins.Equals (null)) {
                    foreach (var item in listaAdmins) {
                        if (!item.Equals (null) && email.Equals (item.Email)) {
                            return item;
                        }
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

            return user;
        }

        public Usuario RemoverUsuario (Usuario user) {
            var registros = File.ReadAllLines (PATH);
            string[] registrosAdmin = File.ReadAllLines (PATH_ADMIN);
            Console.WriteLine ("AAAA");
            Console.WriteLine (registrosAdmin[0]);

            for (int i = 0; i < registrosAdmin.Length; i++) {
                if (string.IsNullOrEmpty (registrosAdmin[i])) {
                    Console.WriteLine ("BBBB");
                    continue;
                }
                var dados = registrosAdmin[i].Split (";");
                if (user.ID.Equals (ulong.Parse (dados[0]))) {
                    registrosAdmin[i] = null;
                    Console.WriteLine ("CCCC");
                    File.WriteAllLines (PATH_ADMIN, registrosAdmin);
                    return user;
                }
            }

            for (int i = 0; i < registros.Length; i++) {
                if (string.IsNullOrEmpty (registros[i])) {
                    Console.WriteLine ("BBBB");
                    continue;
                }
                var dados = registros[i].Split (";");
                if (user.ID.Equals (ulong.Parse (dados[0]))) {
                    registros[i] = null;
                    Console.WriteLine ("CCCC");
                    File.WriteAllLines (PATH, registros);
                    return user;
                }
            }
            return user;
        }

        public Usuario RetirarAdm (Usuario user) {
            if (ListarAdmins ().Contains (user)) {
                MoverUsuario (user, ListarAdmins (), Listar ());
                return user;
            }
            return null;
        }
        public void MoverUsuario (Usuario user, List<Usuario> lista1, List<Usuario> lista2) {
            if (lista1.Contains (user)) {
                lista2.Add (user);
                lista1.Remove (user);
            }
        }
    }
}