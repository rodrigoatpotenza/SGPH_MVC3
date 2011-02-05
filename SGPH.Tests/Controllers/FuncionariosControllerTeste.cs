using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGPH.Controllers;
using SGPH.Models;

namespace SGPH.Tests.Controllers
{
    /// <summary>
    /// Summary description for FuncionariosControllerTeste
    /// </summary>
    [TestClass]
    public class FuncionariosControllerTeste
    {
        public FuncionariosControllerTeste()
        {
            
        }

        List<Funcionario> CriarFuncionariosTeste()
        {
            var funcionarios = new List<Funcionario>();

            for (var i = 0; i < 101; i++)
            {
                var funcionario = new Funcionario
                                              {
                                                  Id = i,
                                                  Bairro = "Pituba",
                                                  Cargos_Id = 6,
                                                  Cep = "40.000-000",
                                                  Cidades_Estados_Id = 5,
                                                  Cidades_Id = 981,
                                                  Complemento = "Casa",
                                                  DataNascimento = new System.DateTime(1978, 06, 06),
                                                  Logradouro = "Rua Rio Grande do Sul",
                                                  Matricula = "123456-0",
                                                  Nome = "Fulano de Tal",
                                                  Numero = "123e",
                                                  Perfis_Id = 1,
                                                  Ramal = "53902",
                                                  Setores_Id = 116,
                                                  Telefone = "(71) 2222-3333",
                                                  Unidades_Id = 7
                                              };
                funcionarios.Add(funcionario);
            }

            return funcionarios;
        }

        FuncionariosController CriarFuncionariosController()
        {
            //var repository = new FalsoRepositorio.FalsoFuncionarioRepository(CriarFuncionariosTeste());
            return new FuncionariosController();
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Acao_Detalhes_Deve_Retornar_Um_Funcionario_Existente()
        {
            // Arrange
            var controller = CriarFuncionariosController(); 

            // Act
            var resultado = controller.Detalhes(1) as ViewResult;

            // Assert
            Assert.IsNotNull(resultado, "Expected View");
        }

        [TestMethod]
        public void Acao_Detalhes_Deve_Retorna_NaoEncontrado_Para_Funcionario_Inexistente()
        {
            var controller = CriarFuncionariosController();

            var resultado = controller.Detalhes(999) as ViewResult;

            if (resultado != null) Assert.AreEqual("NaoEncontrado", resultado.ViewName);
        }
    }
}
