using System;
using System.Collections.Generic;
using System.Linq;
using SGPH.Models;

namespace SGPH.Tests.FalsoRepositorio
{
    public class FalsoFuncionarioRepository : IFuncionarioRepository
    {
        private List<Funcionario> _funcionarios;

        public FalsoFuncionarioRepository(List<Funcionario> funcionarios)
        {
            _funcionarios = funcionarios;
        }

        #region Implementation of IFuncionarioRepository

        public IQueryable<Funcionario> EncontreTodosOsFuncionarios()
        {
            return _funcionarios.AsQueryable();
        }

        public Funcionario TragaUmFuncionario(int id)
        {
            return _funcionarios.FirstOrDefault(f=>f.Id == id);
        }

        public void Inserir(Funcionario funcionario)
        {
            _funcionarios.Add(funcionario);
        }

        public void Excluir(Funcionario funcionario)
        {
            _funcionarios.Remove(funcionario);
        }

        public void PersistirNoBanco()
        {
        }

        #endregion
    }
}
