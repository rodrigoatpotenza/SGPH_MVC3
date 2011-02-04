using System.Linq;

namespace SGPH.Models
{
    public interface IFuncionarioRepository
    {
        IQueryable<Funcionario> EncontreTodosOsFuncionarios();
        Funcionario TragaUmFuncionario(int id);
        void Inserir(Funcionario funcionario);
        void Excluir(Funcionario funcionario);
        void PersistirNoBanco();
    }
}