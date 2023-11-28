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
public class LivrosController(IBookRepository bookRepository) : Controller
{
    private readonly IBookRepository _bookRepository = bookRepository;

    public IActionResult Index()
    {
        List<LivroModel> livros = _bookRepository.Listar();
        return View(livros);
    }
    
    public IActionResult Details(int id)
    {
        if (id == null)
        {
            return NotFound();
        }

        LivroModel livro = _bookRepository.Obter(id);

        if (livro == null)
        {
            return NotFound();
        }
        return View(livro);
    }

    public IActionResult Cadastro()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Cadastrar(int? Idlivro,LivroModel livro)
    {
        try
        {
            _bookRepository.Cadastrar(Idlivro,livro);
            TempData["Mensagem"] = "Livro cadastrado com sucesso.";
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            TempData["Mensagem"] = $"Houve um erro e não foi possível cadastrar o livro. Detalhes: {ex.Message}";
            return RedirectToAction("Index");
        }
    }

    public IActionResult Editar(int id)
    {
        if (id == null)
        {
            return NotFound();
        }

        LivroModel livro = _bookRepository.Obter(id);

        if (livro == null)
        {
            return NotFound();
        }
        return View(livro);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Atualizar(LivroModel livro)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _bookRepository.AtualizarLivro(livro);
            }
            catch
            {
                TempData["Mensagem"] = "Livro não encontrado. Edição não realizada.";
                return RedirectToAction("Index");
            }
            TempData["Mensagem"] = "Editado com sucesso!";
            return RedirectToAction("Index");
        }
        return View(livro);
    }

    public IActionResult ConfirmarDeletar(int id)
    {
        if (id == null)
        {
            return NotFound();
        }

        LivroModel livro = _bookRepository.Obter(id);

        if (livro == null)
        {
            return NotFound();
        }
        return View(livro);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var LivroModel = _bookRepository.Obter(id);

        if (LivroModel == null)
        {
            TempData["Mensagem"] = "Livro não encontrado. Exclusão não realizada.";
            return RedirectToAction("Index");
        }

        _bookRepository.Deletar(id);

        TempData["Mensagem"] = "Livro excluído com sucesso!";
        return RedirectToAction("Index");
    }
}
