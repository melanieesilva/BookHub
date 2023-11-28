using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookHub.Data;
using BookHub.Models;

namespace BookHub.Repository
{
    public class AnotacaoRepository : IAnotacaoRepository
    {
        private readonly ApplicationDbContext app_context;

        public AnotacaoRepository(ApplicationDbContext appcontext)
        {
            app_context = appcontext;
        }

        public AnotacaoModel Cadastrar(AnotacaoModel anotacao)
        {
            app_context.Anotacoes.Add(anotacao);
            app_context.SaveChanges();
            return anotacao;
        }

        public AnotacaoModel Obter(int id)
        {
            return app_context.Anotacoes.FirstOrDefault(a => a.Id == id);
        }

        public List<AnotacaoModel> Listar()
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

        public void Deletar(int id)
        {
            var anotacaoExistente = app_context.Anotacoes.FirstOrDefault(a => a.Id == id);
            if (anotacaoExistente != null)
            {
                app_context.Remove(anotacaoExistente);
                app_context.SaveChanges();
            }
        }
    }
}
