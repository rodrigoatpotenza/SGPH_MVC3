using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace SGPH.Models.ViewModels
{
    public class FuncionarioViewModel
    {
        private readonly sgphdbEntities _db = new sgphdbEntities();

        public Funcionario Funcionario { get; private set; }

        public List<SelectListItem> Estados { get; private set; }

        public List<SelectListItem> Cidades { get; private set; }

        public FuncionarioViewModel(Funcionario funcionario)
        {
            Funcionario = funcionario;

            Estados =
                _db.estados.Select(e => new {e.Descricao, e.Id}).ToList().Select(
                    e =>
                    new SelectListItem
                        {
                            Text = e.Descricao,
                            Value = Convert.ToString(e.Id),
                            Selected = e.Id == funcionario.Cidades_Estados_Id
                        }).ToList();

            Cidades =
                _db.cidades.Select(c => new {c.Estados_Id, c.Descricao, c.Id }).ToList().Where(c => c.Estados_Id == funcionario.Cidades_Estados_Id).Select(
                    e =>
                    new SelectListItem
                    {
                        Text = e.Descricao,
                        Value = Convert.ToString(e.Id),
                        Selected = e.Id == funcionario.Cidades_Id
                    }).ToList();
        }
    }
}