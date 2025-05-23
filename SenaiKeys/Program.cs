using SenaiKeys.Usuarios;
using SenaiKeys.Menus;

namespace SenaiKeys {
    internal class Program {
        static void Main(string[] args)
        {
            // Inicializa o gerenciador de usuários
            UsuarioManager manager = new UsuarioManager();

            // Cadastro do primeiro Adm fixo
            Adm adm = new Adm("dannys", 1234, "Adm", "asdf");
            manager.AdicionarUsuario(adm);

            // Inicia o menu principal
            Menu menu = new Menu(manager);
            menu.Exibir();
        }
    }
}
