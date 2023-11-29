using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookHub.Models;

namespace BookHub.Repository
{
    public interface IBookRepository
    {
        AnotacaoModel CadastrarAnotacao(int id,AnotacaoModel anotacao);
        List<AnotacaoModel> ListarAnotacoes();
        void AtualizarAnotacao(AnotacaoModel anotacao);
        void DeletarAnotacao(int id);
        AnotacaoModel ObterAnotacao(int id);
        
        LivroModel CadastrarLivro(LivroModel livro);
        List<LivroModel> ListarLivro();
        void AtualizarLivro(LivroModel livro);
        void DeletarLivro(int id);
        LivroModel ObterLivro(int id);

    }
}
