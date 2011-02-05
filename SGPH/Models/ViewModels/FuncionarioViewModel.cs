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

        public List<SelectListItem> Cargos { get; private set; }

        public List<SelectListItem> Unidades { get; private set; }

        public List<SelectListItem> Setores { get; private set; }

        public List<SelectListItem> Perfis { get; private set; }

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

            Cargos = 
                _db.cargos.Select(c => new {c.Descricao, c.Id}).ToList().Select(
                e=>
                new SelectListItem
                    {
                        Text = e.Descricao,
                        Value = Convert.ToString(e.Id),
                        Selected = e.Id == funcionario.Cargos_Id
                    }).ToList();

            Unidades =
                _db.unidades.Select(u => new { u.Descricao, u.Id }).ToList().Select(
                u =>
                new SelectListItem
                {
                    Text = u.Descricao,
                    Value = Convert.ToString(u.Id),
                    Selected = u.Id == funcionario.Unidades_Id
                }).ToList();

            Setores =
                _db.setores.Select(s => new { s.Descricao, s.Id }).ToList().Select(
                s =>
                new SelectListItem
                {
                    Text = s.Descricao,
                    Value = Convert.ToString(s.Id),
                    Selected = s.Id == funcionario.Setores_Id
                }).ToList();

            Perfis =
                _db.perfis.Select(p => new { p.Descricao, p.Id }).ToList().Select(
                p =>
                new SelectListItem
                {
                    Text = p.Descricao,
                    Value = Convert.ToString(p.Id),
                    Selected = p.Id == funcionario.Perfis_Id
                }).ToList();
        }
    }
}