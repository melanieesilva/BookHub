using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookHub.Controllers
{
    [Route("[controller]")]
    public class AnotacaoLivroController : Controller
    {
        private readonly ILogger<AnotacaoLivro> _logger;

        public AnotacaoLivro(ILogger<AnotacaoLivro> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}