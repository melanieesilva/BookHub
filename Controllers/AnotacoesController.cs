using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookHub.Data;
using BookHub.Models;
using BookHub.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookHub.Controllers
{
    [Authorize]
    public class AnotacoesController : Controller
    {
        private readonly IAnotacaoRepository _anotacaoRepository;

        public AnotacoesController(IAnotacaoRepository anotacaoRepository)
        {
            _anotacaoRepository = anotacaoRepository;
        }

        public IActionResult Index()
        {
            List<AnotacaoModel> anotacoes = _anotacaoRepository.Listar();
            return View(anotacoes);
        }

        //     // GET: Anotacoes/Details/5
        //     public async Task<IActionResult> Details(int? id)
        //     {
        //         if (id == null)
        //         {
        //             return NotFound();
        //         }

        //         var anotacaoModel = await _context.Anotacoes
        //             .FirstOrDefaultAsync(m => m.Id == id);
        //         if (anotacaoModel == null)
        //         {
        //             return NotFound();
        //         }

        //         return View(anotacaoModel);
        //     }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Titulo,Texto,Categoria,Cor,DataPublicacao")] AnotacaoModel anotacao)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _anotacaoRepository.Cadastrar(anotacao);
                    TempData["Mensagem"] = "Anotação cadastrada com sucesso.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Mensagem"] = $"Houve um erro e não foi possível cadastrar a nota. Detalhes: {ex.Message}";
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(anotacao);
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AnotacaoModel anotacao = _anotacaoRepository.Obter(id);

            if (anotacao == null)
            {
                return NotFound();
            }
            return View(anotacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(
            int id,
            [Bind("Id,Titulo,Texto,Categoria,Cor")] AnotacaoModel anotacao
        )
        {
            if (id != anotacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _anotacaoRepository.AtualizarAnotacao(anotacao);
                }
                catch
                {
                    TempData["Mensagem"] = "Anotação não encontrada. Edição não realizada.";
                    return RedirectToAction(nameof(Index));
                }
                TempData["Mensagem"] = "Editada com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            return View(anotacao);
        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AnotacaoModel anotacao = _anotacaoRepository.Obter(id);

            if (anotacao == null)
            {
                return NotFound();
            }
            return View(anotacao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var anotacaoModel = _anotacaoRepository.Obter(id);

            if (anotacaoModel == null)
            {
                TempData["Mensagem"] = "Anotação não encontrada. Exclusão não realizada.";
                return RedirectToAction(nameof(Index));
            }

            _anotacaoRepository.Deletar(id);

            TempData["Mensagem"] = "Anotação excluída com sucesso!";
            return RedirectToAction(nameof(Index));
        }
    }
}
