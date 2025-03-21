using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgettoSettimanale2_BU2.Data;
using ProgettoSettimanale2_BU2.Models;
using ProgettoSettimanale2_BU2.Services;
using ProgettoSettimanale2_BU2.ViewModels;

namespace ProgettoSettimanale2_BU2.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ClienteService _clienteService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly LoggerService _loggerService;

        public ClienteController(ApplicationDbContext context, ClienteService clienteService, UserManager<ApplicationUser> userManager, LoggerService loggerService)
        {
            _context = context;
            _clienteService = clienteService;
            _userManager = userManager;
            _loggerService = loggerService;
        }
        public async Task<IActionResult> Index()
        {
            var clienti = await _clienteService.GetAllClientiAsync();
            return View(clienti);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddClienteViewModel cliente)
        {
            try
            {
                await _clienteService.AddClienteAsync(cliente, User);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(cliente);
            }
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var cliente = await _clienteService.GetClienteByIdAsync(id.Value);
            if (cliente == null) return NotFound();

            var model = new EditClienteViewModel
            {
                ClienteId = cliente.ClienteId,
                Nome = cliente.Nome,
                Cognome = cliente.Cognome,
                Email = cliente.Email,
                Telefono = cliente.Telefono
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditClienteViewModel cliente)
        {
            if (id != cliente.ClienteId) return NotFound();

            if (ModelState.IsValid)
            {
                await _clienteService.EditClienteAsync(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var cliente = await _clienteService.GetClienteByIdAsync(id.Value);
            if (cliente == null) return NotFound();

            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _clienteService.DeleteClienteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
