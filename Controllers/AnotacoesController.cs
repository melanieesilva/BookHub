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

namespace BookHub.Controllers;

[Authorize]
public class AnotacoesController(IBookRepository bookRepository) : Controller
{
    private readonly IBookRepository _bookRepository = bookRepository;

    public IActionResult Index()
    {
        List<AnotacaoModel> anotacoes = _bookRepository.ListarAnotacoes();
        return View(anotacoes);
    }

    public IActionResult Create(int id)
    {
        AnotacaoModel anotacaoTemp = new AnotacaoModel
        {
            Titulo = "",
            Texto = "",
            Categoria = "",
            Cor = "",
            IdLivro = id
        };

        _bookRepository.CadastrarAnotacao(anotacaoTemp);

        return View(anotacaoTemp);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Cadastrar(AnotacaoModel anotacao)
    {
        try
        {
            _bookRepository.AtualizarAnotacao(anotacao);
            TempData["Mensagem"] = "Anotação cadastrada com sucesso.";
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            TempData["Mensagem"] =
                $"Houve um erro e não foi possível cadastrar a nota. Detalhes: {ex.Message}";
            return RedirectToAction("Index");
        }
    }

    public IActionResult Edit(int id)
    {
        AnotacaoModel anotacao = _bookRepository.ObterAnotacao(id);

        if (anotacao == null)
        {
            return NotFound();
        }
        return View(anotacao);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Atualizar(AnotacaoModel anotacao)
    {
        _bookRepository.AtualizarAnotacao(anotacao);
        TempData["Mensagem"] = "Editada com sucesso!";
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        AnotacaoModel anotacao = _bookRepository.ObterAnotacao(id);

        if (anotacao == null)
        {
            return NotFound();
        }
        return View(anotacao);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var anotacaoModel = _bookRepository.ObterAnotacao(id);

        if (anotacaoModel == null)
        {
            TempData["Mensagem"] = "Anotação não encontrada. Exclusão não realizada.";
            return RedirectToAction("Index");
        }

        _bookRepository.DeletarAnotacao(id);

        TempData["Mensagem"] = "Anotação excluída com sucesso!";
        return RedirectToAction("Index");
    }
}
