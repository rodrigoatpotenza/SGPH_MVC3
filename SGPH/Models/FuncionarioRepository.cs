using System.Linq;

namespace SGPH.Models
{
    public class FuncionarioRepository
    {
        private readonly sgphdbEntities _entities = new sgphdbEntities();

        public IQueryable<Funcionario> EncontreTodosOsFuncionarios()
        {
            return _entities.funcionarios;
        }

        public Funcionario TragaUmFuncionario(int id)
        {
            return _entities.funcionarios.FirstOrDefault(f => f.Id == id);
        }

        public void Inserir(Funcionario funcionario)
        {
            _entities.funcionarios.AddObject(funcionario);
        }

        public void Excluir(Funcionario funcionario)
        {
            foreach (var funcionarioIdioma in funcionario.funcionarios_idiomas)
            {
                _entities.funcionarios_idiomas.DeleteObject(funcionarioIdioma);
            }

            foreach (var experienciaProfissional in funcionario.experienciasprofissionais)
            {
                _entities.experienciasprofissionais.DeleteObject(experienciaProfissional);
            }

            foreach (var cursoExtensao in funcionario.cursosextensaos)
            {
                _entities.cursosextensaos.DeleteObject(cursoExtensao);    
            }

            foreach (var formacao in funcionario.formacoes)
            {
                _entities.formacoes.DeleteObject(formacao);
            }

            _entities.funcionarios.DeleteObject(funcionario);
        }

        public void PersistirNoBanco()
        {
            _entities.SaveChanges();
        }
    }
}