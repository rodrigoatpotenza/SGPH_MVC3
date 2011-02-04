using System;
using System.Web.Mvc;
using SGPH.Helpers;
using SGPH.Models;
using SGPH.Models.ViewModels;

namespace SGPH.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly FuncionarioRepository _funcionarioRepository = new FuncionarioRepository();
        //
        // GET: /Funcionarios/
        //      /Funcionarios/Pagina/2

        public ActionResult Index(int pagina = 0)
        {
            const int tamanhoDaPagina = 10;

            var funcionarios = _funcionarioRepository.EncontreTodosOsFuncionarios();
            var paginacaoFuncionarios = new ListaPaginada<Funcionario>(funcionarios, pagina, tamanhoDaPagina);  

            return View(paginacaoFuncionarios);
        }


        public ActionResult Detalhes(int id)
        {
            var funcionario = _funcionarioRepository.TragaUmFuncionario(id);

            return funcionario == null ? View("NaoEncontrado") : View("Detalhes", funcionario);
        }

        //
        // GET: /Funcionarios/Editar/1

        [Authorize]
        public ActionResult Editar(int id)
        {
            var funcionario = _funcionarioRepository.TragaUmFuncionario(id);

            return View(new FuncionarioViewModel(funcionario));
        }

        //
        // POST: /Funcionarios/Editar/1

        [HttpPost]
        public ActionResult Editar(int id, FormCollection form)
        {
            var funcionario = _funcionarioRepository.TragaUmFuncionario(id);
            funcionario.Cidades_Estados_Id = Convert.ToInt64(form["Funcionario.Cidades_Estados_Id"]);
            funcionario.Cidades_Id = Convert.ToInt64(form["Funcionario.Cidades_Id"]);

            if(TryUpdateModel(funcionario))
            {
                _funcionarioRepository.PersistirNoBanco();
                return RedirectToAction("Detalhes", new {id = funcionario.Id});
            }

            return View(new FuncionarioViewModel(funcionario));
        }

        //
        // GET: /Funcionarios/Criar

        public ActionResult Criar()
        {
            var funcionario = new Funcionario();

            return View(new FuncionarioViewModel(funcionario));
        }

        //
        // POST: /Funcionarios/Criar

        [HttpPost,Authorize]
        public ActionResult Criar(Funcionario funcionario)
        {
            if(ModelState.IsValid)
            {
                _funcionarioRepository.Inserir(funcionario);
                _funcionarioRepository.PersistirNoBanco();

                return RedirectToAction("Detalhes", new {id =  funcionario.Id});
            }

            return View(new FuncionarioViewModel(funcionario));
        }

        //
        // GET: /Funcionarios/Excluir/1

        public ActionResult Excluir(int id)
        {
            var funcionario = _funcionarioRepository.TragaUmFuncionario(id);

            return funcionario == null ? View("NaoEncontrado") : View(funcionario);
        }

        //
        // POST: /Funcionarios/Excluir/1

        [HttpPost]
        public ActionResult Excluir(int id, string confirmButton)
        {
            var funcionario = _funcionarioRepository.TragaUmFuncionario(id);

            if (funcionario == null)
                return View("NaoEncontrado");

            _funcionarioRepository.Excluir(funcionario);
            _funcionarioRepository.PersistirNoBanco();

            return View("Excluido");
        }

        public ActionResult Cidades(long? estadoId, Funcionario funcionario)
        {
            if(estadoId.HasValue)
                funcionario.Cidades_Estados_Id = estadoId.Value;

            var cidades = new SelectList(new FuncionarioViewModel(funcionario).Cidades, "Value", "Text");

            return Json(cidades,JsonRequestBehavior.AllowGet);
        }

    }
}
