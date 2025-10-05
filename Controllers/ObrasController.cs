using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EvolucaoObra.Data;
using EvolucaoObra.Models;

namespace EvolucaoObra.Controllers
{
    public class ObrasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ObrasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Obras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Obras.ToListAsync());
        }

        // GET: Obras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var obra = await _context.Obras.FirstOrDefaultAsync(m => m.Id == id);
            if (obra == null) return NotFound();

            return View(obra);
        }

        // GET: Obras/Create
        public IActionResult Create()
        {
            // Inicializa um objeto Obra para evitar NullReferenceException
            return View(new Obra 
            { 
                DataInicio = DateTime.Today, 
                Status = "Em andamento" 
            });
        }

        // POST: Obras/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Endereco,Responsavel,DataInicio,DataTerminoPrevista,DataConclusao,Status,EtapaAtual,Observacoes")] Obra obra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obra);
        }

        // GET: Obras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var obra = await _context.Obras.FindAsync(id);
            if (obra == null) return NotFound();
            return View(obra);
        }

        // POST: Obras/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Endereco,Responsavel,DataInicio,DataTerminoPrevista,DataConclusao,Status,EtapaAtual,Observacoes")] Obra obra)
        {
            if (id != obra.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObraExists(obra.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(obra);
        }

        // GET: Obras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var obra = await _context.Obras.FirstOrDefaultAsync(m => m.Id == id);
            if (obra == null) return NotFound();

            return View(obra);
        }

        // POST: Obras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obra = await _context.Obras.FindAsync(id);
            _context.Obras.Remove(obra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObraExists(int id) => _context.Obras.Any(e => e.Id == id);
    }
}
