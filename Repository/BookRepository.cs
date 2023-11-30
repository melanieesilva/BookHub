using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BookHub.Data;
using BookHub.Models;

namespace BookHub.Repository;

public class BookRepository(ApplicationDbContext appcontext) : IBookRepository
{
    private readonly ApplicationDbContext app_context = appcontext;

    public AnotacaoModel CadastrarAnotacao(AnotacaoModel anotacao)
    {
        app_context.Anotacoes.Add(anotacao);
        app_context.SaveChanges();

        return anotacao;
    }

    public AnotacaoModel ObterAnotacao(int id)
    {
        return app_context.Anotacoes.FirstOrDefault(a => a.IdAnotacao == id);
    }

    public List<AnotacaoModel> ListarAnotacoes()
    {
        return app_context.Anotacoes.ToList();
    }

    public void AtualizarAnotacao(AnotacaoModel anotacao)
    {
        var anotacaoExistente = app_context
            .Anotacoes
            .FirstOrDefault(a => a.IdAnotacao == anotacao.IdAnotacao);
        if (anotacaoExistente != null)
        {
            anotacaoExistente.Titulo = anotacao.Titulo;
            anotacaoExistente.Texto = anotacao.Texto;
            anotacaoExistente.Categoria = anotacao.Categoria;
            anotacaoExistente.Cor = anotacao.Cor;

            app_context.SaveChanges();
        }
    }

    public bool DeletarAnotacao(int id)
    {
        var anotacaoExistente = app_context.Anotacoes.FirstOrDefault(a => a.IdAnotacao == id);

        app_context.Remove(anotacaoExistente);
        app_context.SaveChanges();
        return true;
    }

    public LivroModel CadastrarLivro(LivroModel livro)
    {
        app_context.Livros.Add(livro);
        app_context.SaveChanges();
        return livro;
    }

    public List<LivroModel> ListarLivro()
    {
        return app_context.Livros.ToList();
    }

    public void AtualizarLivro(LivroModel livro)
    {
        var livroExistente = app_context.Livros.FirstOrDefault(a => a.IdLivro == livro.IdLivro);
        if (livroExistente != null)
        {
            livroExistente.Titulo = livro.Titulo;
            livroExistente.Descricao = livro.Descricao;
            livroExistente.Genero = livro.Genero;
            livroExistente.NomeAutor = livro.NomeAutor;

            app_context.SaveChanges();
        }
    }

    public bool DeletarLivro(int id)
    {
        LivroModel livroExistente = app_context.Livros.FirstOrDefault(a => a.IdLivro == id);
        if (livroExistente == null)
            throw new Exception("O livro não existe");

        app_context.Remove(livroExistente);
        app_context.SaveChanges();
        return true;
    }

    public LivroModel ObterLivro(int id)
    {
        return app_context.Livros.FirstOrDefault(a => a.IdLivro == id);
    }
}
