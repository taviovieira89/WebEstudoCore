using WebEstudo.DAO.EntidadesDAO;
using WebEstudo.Entidades;

namespace TestWebEstudo
{
    [TestClass]
    public class UnitProduto
    {
        private ProdutoDAO prodDao;
        public UnitProduto(ProdutoDAO _prodDao)
        {
            prodDao = _prodDao;
        }

        [TestMethod]
        public void TestGetUser()
        {
            var Lista = prodDao.GetAll();

            Assert.AreNotEqual(null, Lista);
        }

        [TestMethod]
        public void TestGetUserId()
        {
            int id = 1;
            var ListaUsers = prodDao.GetId(id);

            Assert.AreNotEqual(null, ListaUsers);
        }

        [TestMethod]
        public void TestPost()
        {
            Produtos prod = new Produtos();
            prod.nm_produto = "Caneta bic";
            prod.preco = (decimal)5.99;
            prod.id_usuario_criador = 1;
            prod.dt_criacao = DateTime.Now;

            var Users = prodDao.Salvar(prod);

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

                var Produtos = prodDao.Salvar(produto);

                Assert.AreNotEqual(null, Produtos);

                Assert.IsTrue(Produtos.preco == (decimal)6.85 && Produtos.id_usuario_edicao == 1);
            }
        }

        [TestMethod]
        public void TestDelete()
        {
            var usuario = prodDao.GetAll().Where(a => a.nm_produto.ToLower().Contains("Caneta bic")).FirstOrDefault();
            Assert.AreNotEqual(null, usuario);
            if (usuario != null)
            {
                prodDao.Excluir(usuario);
                var Users = prodDao.GetAll().Where(a => a.nm_produto.ToLower().Contains("Caneta bic")).FirstOrDefault();

                Assert.AreEqual(null, Users);
            }
        }


    }
}
