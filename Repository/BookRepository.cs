using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookHub.Data;
using BookHub.Models;

namespace BookHub.Repository
{
    public class BookRepository(ApplicationDbContext appcontext) : IBookRepository
    {
        private readonly ApplicationDbContext app_context = appcontext;

        public AnotacaoModel CadastrarAnotacao(int id, AnotacaoModel anotacao)
        {
            app_context.Anotacoes.Add(anotacao);
            LivroModel livro = app_context.Livros.FirstOrDefault(l => l.Id == id);
            livro.CodigoAnotacao = id;

            app_context.SaveChanges();
            return anotacao;
        }

        public AnotacaoModel ObterAnotacao(int id)
        {
            return app_context.Anotacoes.FirstOrDefault(a => a.Id == id);
        }

        public List<AnotacaoModel> ListarAnotacoes()
        {
            return app_context.Anotacoes.ToList();
        }

        public void AtualizarAnotacao(AnotacaoModel anotacao)
        {
            var anotacaoExistente = app_context.Anotacoes.FirstOrDefault(a => a.Id == anotacao.Id);
            if (anotacaoExistente != null)
            {
                anotacaoExistente.Titulo = anotacao.Titulo;
                anotacaoExistente.Texto = anotacao.Texto;
                anotacaoExistente.Categoria = anotacao.Categoria;
                anotacaoExistente.Cor = anotacao.Cor;

                app_context.SaveChanges();
            }
        }

        public void DeletarAnotacao(int id)
        {
            var anotacaoExistente = app_context.Anotacoes.FirstOrDefault(a => a.Id == id);
            if (anotacaoExistente != null)
            {
                app_context.Remove(anotacaoExistente);
                app_context.SaveChanges();
            }
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
            var livroExistente = app_context.Livros.FirstOrDefault(a => a.Id == livro.Id);
            if (livroExistente != null)
            {
                livroExistente.Titulo = livro.Titulo;
                livroExistente.Descricao = livro.Descricao;
                livroExistente.Genero = livro.Genero;
                livroExistente.NomeAutor = livro.NomeAutor;

                app_context.SaveChanges();
            }
        }

        public void DeletarLivro(int id)
        {
            var livroExistente = app_context.Livros.FirstOrDefault(a => a.Id == id);
            if (livroExistente != null)
            {
                app_context.Remove(livroExistente);
                app_context.SaveChanges();
            }
        }

        public LivroModel ObterLivro(int id)
        {
            if (id != null)
            {
                return app_context.Livros.FirstOrDefault(a => a.Id == id);
            }
            throw new NotImplementedException();
        }
    }
}
