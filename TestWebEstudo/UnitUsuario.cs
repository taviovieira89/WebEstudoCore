using WebEstudo.DAO.EntidadesDAO;
using WebEstudo.Entidades;

namespace TestWebEstudo
{
    [TestClass]
    public class UnitUsuario
    {
        private UsuarioDAO usuarioDAO;
        public UnitUsuario(UsuarioDAO _usuarioDAO)
        {
            usuarioDAO = _usuarioDAO;
        }

        [TestMethod]
        public void TestGetUser()
        {
            var ListaUsers = usuarioDAO.GetAll();

            Assert.AreNotEqual(null, ListaUsers);
        }

        [TestMethod]
        public void TestGetUserId()
        {
            int id = 1;
            var ListaUsers = usuarioDAO.GetId(id);

            Assert.AreNotEqual(null, ListaUsers);
        }

        [TestMethod]
        public void TestPost()
        {
            Usuario user = new Usuario();
            user.nm_usuario = "Fulano";
            user.dt_nascimento = new DateTime(1988, 04, 07);
            user.login = "fulano01";
            user.senha = "123456";

            var Users = usuarioDAO.Salvar(user);

            Assert.AreNotEqual(null, Users);
            Assert.IsTrue(Users.id_usuario > 0);
        }

        [TestMethod]
        public void TestPut()
        {
            var usuario = usuarioDAO.GetAll().Where(a => a.nm_usuario.ToLower().Contains("Fulano")).FirstOrDefault();
            Assert.AreNotEqual(null, usuario);
            if (usuario != null)
            {
                usuario.senha = "12345678";
                usuario.login = "fulano02";

                var Users = usuarioDAO.Salvar(usuario);

                Assert.AreNotEqual(null, Users);

                Assert.IsTrue(Users.senha == "12345678" && Users.login == "fulano02");
            }
        }

        [TestMethod]
        public void TestDelete()
        {
            var usuario = usuarioDAO.GetAll().Where(a => a.nm_usuario.ToLower().Contains("Fulano")).FirstOrDefault();
            Assert.AreNotEqual(null, usuario);
            if (usuario != null)
            {
                usuarioDAO.Excluir(usuario);
                var Users = usuarioDAO.GetAll().Where(a => a.nm_usuario.ToLower().Contains("Fulano")).FirstOrDefault();

                Assert.AreEqual(null, Users);
            }
        }

    }
}