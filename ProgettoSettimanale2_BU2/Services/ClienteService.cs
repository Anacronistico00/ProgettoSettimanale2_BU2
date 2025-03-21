using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgettoSettimanale2_BU2.Data;
using ProgettoSettimanale2_BU2.Models;
using ProgettoSettimanale2_BU2.ViewModels;
using System.Security.Claims;

namespace ProgettoSettimanale2_BU2.Services
{
    public class ClienteService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly LoggerService _loggerService;
        public ClienteService(ApplicationDbContext context, UserManager<ApplicationUser> usermanager, LoggerService loggerService)
        {
            _context = context;
            _userManager = usermanager;
            _loggerService = loggerService;
        }

        public async Task<List<Cliente>> GetAllClientiAsync()
        {
            return await _context.Clienti.Include(c => c.User).ToListAsync();
        }

        public async Task<List<Cliente>> GetClientiListAsync()
        {
            return await _context.Clienti.ToListAsync();
        }

        public async Task<Cliente?> GetClienteByIdAsync(Guid id)
        {
            return await _context.Clienti.FindAsync(id);
        }

        public async Task AddClienteAsync(AddClienteViewModel model, ClaimsPrincipal claimsPrincipal)
        {
            var user = await _userManager.FindByEmailAsync(claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value);
            var cliente = new Cliente
            {
                ClienteId = Guid.NewGuid(),
                Nome = model.Nome,
                Cognome = model.Cognome,
                Email = model.Email,
                Telefono = model.Telefono,
                UserId = user.Id
            };

            _context.Clienti.Add(cliente);
            await _context.SaveChangesAsync();

            _loggerService.LogInformation("Cliente aggiunto con successo.");
        }

        public async Task EditClienteAsync(EditClienteViewModel model)
        {
            var cliente = await _context.Clienti.FindAsync(model.ClienteId);
            if (cliente == null) return;

            cliente.Nome = model.Nome;
            cliente.Cognome = model.Cognome;
            cliente.Email = model.Email;
            cliente.Telefono = model.Telefono;

            _context.Clienti.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClienteAsync(Guid id)
        {
            var cliente = await _context.Clienti.FindAsync(id);
            if (cliente != null)
            {
                _context.Clienti.Remove(cliente);
                await _context.SaveChangesAsync();
                _loggerService.LogInformation($"Cliente {id} eliminato.");
            }
        }
    }
}
