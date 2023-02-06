using WebEstudo.DAO.EntidadesDAO;
using WebEstudo.DAO.Factory;
using WebEstudo.Entidades;

namespace TestWebEstudo
{
    [TestClass]
    public class TestsUsuario
    {
        private readonly DaoContext _context;
        public TestsUsuario(DaoContext contexto)
        {
            _context = contexto;
        }

        [TestMethod]
        public void TestGetUser()
        {

            var Lista = new List<Usuario>();
            Lista.Add(new Usuario() { id_usuario = 1, dt_nascimento = new DateTime(1989, 04, 07), login = "admin", senha = "123456", nm_usuario = "admin" });
            Lista.Add(new Usuario() { id_usuario = 2, dt_nascimento = new DateTime(1989, 04, 07), login = "Sec", senha = "123456", nm_usuario = "secundario" });
            Lista.Add(new Usuario() { id_usuario = 3, dt_nascimento = new DateTime(1989, 04, 07), login = "ter", senha = "123456", nm_usuario = "terciario" });


            Assert.AreNotEqual(0, Lista.Count());
        }

        [TestMethod]
        public void TestGetUserId()
        {
            int id = 1;

            var Lista = new List<Usuario>();
            Lista.Add(new Usuario() { id_usuario = 1, dt_nascimento = new DateTime(1989, 04, 07), login = "admin", senha = "123456", nm_usuario = "admin" });
            Lista.Add(new Usuario() { id_usuario = 2, dt_nascimento = new DateTime(1989, 04, 07), login = "Sec", senha = "123456", nm_usuario = "secundario" });
            Lista.Add(new Usuario() { id_usuario = 3, dt_nascimento = new DateTime(1989, 04, 07), login = "ter", senha = "123456", nm_usuario = "terciario" });

            var ListaUsers = Lista.Where(a => a.id_usuario == id).ToList();
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

            var Users = _context.Add<Usuario>(user).Entity;
            _context.SaveChanges();

            Assert.AreNotEqual(null, Users);
            Assert.IsTrue(Users.id_usuario > 0);
        }

        [TestMethod]
        public void TestPut()
        {
            var usuario = _context.Set<Usuario>().Where(a => a.id_usuario == 2).FirstOrDefault();
            Assert.AreNotEqual(null, usuario);
            if (usuario != null)
            {
                usuario.senha = "12345678";
                usuario.login = "fulano02";


                var Users = _context.Add<Usuario>(usuario).Entity;
                _context.SaveChanges();

                Assert.AreNotEqual(null, Users);

                Assert.IsTrue(Users.senha == "12345678" && Users.login == "fulano02");
            }
        }

        [TestMethod]
        public void TestDelete()
        {
            int id = 3;
            var Lista = new List<Usuario>();
            Lista.Add(new Usuario() { id_usuario = 1, dt_nascimento = new DateTime(1989, 04, 07), login = "admin", senha = "123456", nm_usuario = "admin" });
            Lista.Add(new Usuario() { id_usuario = 2, dt_nascimento = new DateTime(1989, 04, 07), login = "Sec", senha = "123456", nm_usuario = "secundario" });
            Lista.Add(new Usuario() { id_usuario = 3, dt_nascimento = new DateTime(1989, 04, 07), login = "ter", senha = "123456", nm_usuario = "terciario" });

            var usuario = Lista.Where(a => a.id_usuario == id).FirstOrDefault();
            Assert.AreNotEqual(null, usuario);
            if (usuario != null)
            {
                Lista.Remove(usuario);
                var Users = Lista.Where(a => a.id_usuario == id).FirstOrDefault();
                Assert.AreEqual(null, Users);
            }
        }

    }
}