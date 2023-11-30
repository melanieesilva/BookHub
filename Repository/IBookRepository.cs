using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookHub.Models;

namespace BookHub.Repository
{
    public interface IBookRepository
    {
        AnotacaoModel CadastrarAnotacao(AnotacaoModel anotacao);
        List<AnotacaoModel> ListarAnotacoes();
        void AtualizarAnotacao(AnotacaoModel anotacao);
        bool DeletarAnotacao(int id);
        AnotacaoModel ObterAnotacao(int id);
        
        LivroModel CadastrarLivro(LivroModel livro);
        List<LivroModel> ListarLivro();
        void AtualizarLivro(LivroModel livro);
        bool DeletarLivro(int id);
        LivroModel ObterLivro(int id);

       
    }
}
