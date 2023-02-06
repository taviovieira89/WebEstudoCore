using WebEstudo.DAO.EntidadesDAO;
using WebEstudo.DAO.Factory;
using WebEstudo.Entidades;

namespace TestWebEstudo
{
    [TestClass]
    public class TestsProduto
    {
        private ProdutoRepository prodDao;
        private readonly DaoContext _context;
        public TestsProduto(DaoContext contexto)
        {
            _context = contexto;
        }

        [TestMethod]
        public void TestGetUser()
        {
            var Lista = new List<Produtos>();
            Lista.Add(new Produtos() { id_produto = 1, nm_produto = "Caneta Bic", preco = (decimal)5.99, id_usuario_criador = 1, dt_criacao = DateTime.Now });
            Lista.Add(new Produtos() { id_produto = 2, nm_produto = "Lápis de Cor", preco = (decimal)3.20, id_usuario_criador = 1, dt_criacao = DateTime.Now });
            Lista.Add(new Produtos() { id_produto = 3, nm_produto = "Canetinha", preco = (decimal)8.99, id_usuario_criador = 1, dt_criacao = DateTime.Now });

            Assert.AreNotEqual(0, Lista.Count);
        }

        [TestMethod]
        public void TestGetUserId()
        {
            int id = 1;
            var Lista = new List<Produtos>();
            Lista.Add(new Produtos() { id_produto = 1, nm_produto = "Caneta Bic", preco = (decimal)5.99, id_usuario_criador = 1, dt_criacao = DateTime.Now });
            Lista.Add(new Produtos() { id_produto = 2, nm_produto = "Lápis de Cor", preco = (decimal)3.20, id_usuario_criador = 1, dt_criacao = DateTime.Now });
            Lista.Add(new Produtos() { id_produto = 3, nm_produto = "Canetinha", preco = (decimal)8.99, id_usuario_criador = 1, dt_criacao = DateTime.Now });

            var retorno = Lista.Where(a => a.id_produto == id).FirstOrDefault();

            Assert.AreNotEqual(null, retorno);
        }

        [TestMethod]
        public void TestPost()
        {
            Produtos prod = new Produtos();
            prod.nm_produto = "Caneta preta";
            prod.preco = (decimal)5.99;
            prod.id_usuario_criador = 1;
            prod.dt_criacao = DateTime.Now;

            var Users = _context.Add<Produtos>(prod).Entity;
            _context.SaveChanges(); 

            Assert.AreNotEqual(null, Users);
            Assert.IsTrue(Users.id_produto > 0);
        }

        [TestMethod]
        public void TestPut()
        {
            var produto = prodDao.GetAll().Where(a => a.nm_produto.ToLower().Contains("Caneta bic")).FirstOrDefault();
            Assert.AreNotEqual(null, produto);
            if (produto != null)
            {
                produto.preco = (decimal)6.85;
                produto.id_usuario_edicao = 1;

                var Produtos = _context.Add<Produtos>(produto).Entity;
                _context.SaveChanges();

                Assert.AreNotEqual(null, Produtos);

                Assert.IsTrue(Produtos.preco == (decimal)6.85 && Produtos.id_usuario_edicao == 1);
            }
        }

        [TestMethod]
        public void TestDelete()
        {
            int id=1;
            var Lista = new List<Produtos>();
            Lista.Add(new Produtos() { id_produto = 1, nm_produto = "Caneta Bic", preco = (decimal)5.99, id_usuario_criador = 1, dt_criacao = DateTime.Now });
            Lista.Add(new Produtos() { id_produto = 2, nm_produto = "Lápis de Cor", preco = (decimal)3.20, id_usuario_criador = 1, dt_criacao = DateTime.Now });
            Lista.Add(new Produtos() { id_produto = 3, nm_produto = "Canetinha", preco = (decimal)8.99, id_usuario_criador = 1, dt_criacao = DateTime.Now });

            var retorno = Lista.Where(a => a.id_produto == id).FirstOrDefault();
            Assert.AreNotEqual(null, retorno);
            if (retorno != null)
            {
                Lista.Remove(retorno);
                var Prods = Lista.Where(a => a.id_produto == id).FirstOrDefault();

                Assert.AreEqual(null, Prods);
            }
        }


    }
}
