using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using app_tarefas1.Models;
using app_tarefas1.Data;

namespace app_tarefas1.Controllers
{
    [Authorize]
    public class TarefasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TarefasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tarefas
        public async Task<IActionResult> Index()
        {
            var tarefas = await _context.Tarefa.Include(t => t.Tipo).ToListAsync();
            return View(tarefas);
        }

        // GET: Tarefas/Create
        public IActionResult Create()
        {
            ViewData["Tipos"] = _context.Tipo.ToList();
            return View();
        }

        // POST: Tarefas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                tarefa.DataCriacao = DateTime.Now;
                _context.Add(tarefa);
                await _context.SaveChangesAsync();
                TempData["Mensagem"] = "Tarefa criada com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            ViewData["Tipos"] = _context.Tipo.ToList();
            return View(tarefa);
        }

        // GET: Tarefas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var tarefa = await _context.Tarefa.FindAsync(id);
            if (tarefa == null) return NotFound();
            ViewData["Tipos"] = _context.Tipo.ToList();
            return View(tarefa);
        }

        // POST: Tarefas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Tarefa tarefa)
        {
            if (id != tarefa.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarefa);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Tarefa.Any(e => e.Id == tarefa.Id)) return NotFound();
                    else throw;
                }
            }
            ViewData["Tipos"] = _context.Tipo.ToList();
            return View(tarefa);
        }

        // GET: Tarefas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var tarefa = await _context.Tarefa.Include(t => t.Tipo).FirstOrDefaultAsync(m => m.Id == id);
            if (tarefa == null) return NotFound();
            return View(tarefa);
        }

        // GET: Tarefas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var tarefa = await _context.Tarefa.Include(t => t.Tipo).FirstOrDefaultAsync(m => m.Id == id);
            if (tarefa == null) return NotFound();
            return View(tarefa);
        }

        // POST: Tarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarefa = await _context.Tarefa.FindAsync(id);
            if (tarefa != null)
            {
                _context.Tarefa.Remove(tarefa);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Tarefas/Concluir/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Concluir(int id)
        {
            var tarefa = await _context.Tarefa.FindAsync(id);
            if (tarefa == null) return NotFound();
            tarefa.Concluida = true;
            tarefa.DataConclusao = DateTime.Now;
            _context.Update(tarefa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
