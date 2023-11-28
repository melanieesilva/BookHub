using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookHub.Models;

namespace BookHub.Repository
{
    public interface IAnotacaoRepository
    {
        AnotacaoModel Cadastrar(AnotacaoModel anotacao);
        List<AnotacaoModel> Listar();
        void AtualizarAnotacao(AnotacaoModel anotacao);
        void Deletar(int id);
        AnotacaoModel Obter(int id);
    }
}
