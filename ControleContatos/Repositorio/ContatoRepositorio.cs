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
    }
}
