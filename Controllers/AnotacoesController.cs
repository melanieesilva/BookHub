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
        //buscar livro
        LivroModel livro = _bookRepository.ObterLivro(id);
        //cadastrar livro em AnotacoesLivro
        _bookRepository.CadastrarAnotacaoLivro(livro);
        //retornar modelo
        //buscar a anotacao do livro e retornar
        AnotacaoLivroModel anotacaoLivro = _bookRepository.ObterAnotacaoLivro(id);
        return View(anotacaoLivro);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Cadastrar(AnotacaoLivroModel anotacaoLivro)
    {
        try
        {
            _bookRepository.CadastrarAnotacaoLivro(anotacaoLivro);
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
        if (ModelState.IsValid)
        {
            try
            {
                _bookRepository.AtualizarAnotacao(anotacao);
                TempData["Mensagem"] = "Editada com sucesso!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Mensagem"] = "Anotação não encontrada. Edição não realizada.";
                return RedirectToAction("Index");
            }
        }
        return View(anotacao);
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
