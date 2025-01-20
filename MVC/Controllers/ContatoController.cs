using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Context;
using MVC.Models;

namespace MVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly AgendaContext _context;
        public ContatoController(AgendaContext context) {
            _context = context;
        }

        public IActionResult Index()
        {
            if (_context == null)
            {
                return Problem("Entity set 'AgendaContext.Contatos' is null.");
            }
            var contatos = _context.Contatos.ToList();
            return View(contatos);
        }

        public IActionResult Criar() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Contato contato) 
        {
            if(ModelState.IsValid) {
                _context.Contatos.Add(contato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(contato);
        }

        public IActionResult Editar(int id) {
            var contato = _context.Contatos.Find(id);
            if(contato == null)
                return RedirectToAction(nameof(Index));

            return View(contato);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Contato contato) {
            if(ModelState.IsValid){
                _context.Contatos.Update(contato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
    }   

        public IActionResult Detalhe(int id) {
            var contato = _context.Contatos.Find(id);
            if(contato == null)
                return RedirectToAction(nameof(Index));

            return View(contato);
        }
        
        public IActionResult Excluir(int id) 
        {
            var contato = _context.Contatos.Find(id);
            if(contato == null)
                return RedirectToAction(nameof(Index));
            return View(contato);   
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(Contato c) {
            var contato = await _context.Contatos.FindAsync(c.Id);
            _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }   
    }
}