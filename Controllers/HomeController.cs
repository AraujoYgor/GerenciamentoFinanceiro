using System.Diagnostics;
using GerenciamentoFinanceiro.Data;
using GerenciamentoFinanceiro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoFinanceiro.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            
            _context = context;

        }

        public IActionResult Index(string id)
        {
            var filtros = new Filtros(id);

            ViewBag.Filtros = filtros;
            ViewBag.Categorias = _context.Categorias.ToList();
            ViewBag.Transacoes = _context.Transacoes.ToList();

            IQueryable<Financeiro> consulta = _context.Finacas.Include(x => x.transacao).Include(x => x.categoria);

            if (filtros.TemCategoria)
            {
                consulta = consulta.Where(c => c.CategoriaId == filtros.CategoraiId);
            }
            if (filtros.TemTrasacao)
            {
                consulta = consulta.Where(c => c.TransacaoId == filtros.TransacaoId);
            }
            if (filtros.TemDataOperacao) 
            {
                var data = DateTime.Today;


                if (filtros.EPassado)
                {
                    consulta = consulta.Where(c => c.DataDaOperacao > data);
                }
                if (filtros.EFuturo)
                {
                    consulta = consulta.Where(c => c.DataDaOperacao < data);
                }
                if (filtros.EesseMes)
                {
                    consulta = consulta.Where(c => c.DataDaOperacao == data);
                }
            }  

            var financas = consulta.OrderBy(d => d.DataDaOperacao).ToList();

            return View(financas);
        }

    }
}
