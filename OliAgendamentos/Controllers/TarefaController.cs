using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OliAgendamentos.Data;
using OliAgendamentos.Models;

namespace OliAgendamentos.Controllers
{
    public class TarefaController : Controller
    {
        private readonly OAContext _context;
        public TarefaController(OAContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<List<Tarefa>>> Index()
        {
            return View(await _context.Tarefas.ToListAsync());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Tarefa tarefa)
        {
            if (ModelState.IsValid){
                try
                {
                    _context.Tarefas.Add(tarefa);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Erro:" + ex);
                }
            }
            
            return View(tarefa);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);
            if(tarefa == null) return NotFound();
            return View(tarefa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, Tarefa tarefa)
        {
            if(id == null) return NotFound();
            _context.Tarefas.Update(tarefa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Details(int? id)
        {
            if(id == null) return NotFound();
            var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);
            if(tarefa == null) return BadRequest();
            return View(tarefa);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);
            if(tarefa == null) return NotFound();
            return View(tarefa);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int? id)
        {
            var tarefa = await _context.Tarefas.SingleOrDefaultAsync(t => t.Id == id);
            if (tarefa == null) return NotFound("Tarefa não encontrada");
            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
