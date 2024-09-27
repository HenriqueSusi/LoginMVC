using CadastroMvc.Data;
using CadastroMvc.Extencoes;
using CadastroMvc.Migrations;
using CadastroMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroMvc.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var produtos = _context.Produtos.ToList();
            return View(produtos);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ProdutoModel produto)
        {
            if (ModelState.IsValid)
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        public IActionResult Detalhes(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }


        public IActionResult AdicionarAoCarrinho(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }

            var carrinho = ObterCarrinho();
            carrinho.AdicionarItem(produto, 1);
            SalvarCarrinho(carrinho);

            return RedirectToAction("Index", "Carrinho");  // Redireciona para o carrinho
        }


        // Métodos para manipular o carrinho na sessão (mesmo código já explicado antes)
        private CarrinhoModel ObterCarrinho()
        {
            var carrinho = HttpContext.Session.GetObjectFromJson<CarrinhoModel>("Carrinho") ?? new CarrinhoModel();
            return carrinho;
        }
        private void SalvarCarrinho(CarrinhoModel carrinho)
        {
            HttpContext.Session.SetObjectAsJson("Carrinho", carrinho);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Deletar(int id)
        {

                var produto = _context.Produtos.Find(id);
                if (produto == null)
               {
                   return NotFound();
               }

                _context.Produtos.Remove(produto);
                _context.SaveChanges(); 

                return RedirectToAction("Index"); 

        }
    }
}
