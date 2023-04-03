using ControleContatos.Data;
using ControleContatos.Models;

namespace ControleContatos.Repositorio
{

    //Contem os metodos para trabalhar com contatos
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ContatoModel ListaPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(b => b.Id == id);  
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            //GRAVAR NO DB
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListaPorId(contato.Id);

            if (contatoDB == null) {
                throw new Exception("Houve um erro na atualização do contato");
            }
            else
            {
                contatoDB.Nome = contato.Nome;
                contatoDB.Email = contato.Email;
                contatoDB.Celular = contato.Celular;

                _bancoContext.Contatos.Update(contatoDB);
                _bancoContext.SaveChanges();

                return contatoDB;
            }

        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListaPorId(id);

            if (contatoDB == null)
            {
                throw new Exception("Houve um erro na atualização do contato");
            }
            else
            {
                _bancoContext.Contatos.Remove(contatoDB);
                _bancoContext.SaveChanges();
                return true;
            }
        }
    }
}
