﻿using ControleContatos.Models;

namespace ControleContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ListaPorId(int id); 
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int id);

    }
}
