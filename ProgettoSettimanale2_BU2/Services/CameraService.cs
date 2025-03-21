using Microsoft.EntityFrameworkCore;
using ProgettoSettimanale2_BU2.Data;
using ProgettoSettimanale2_BU2.Models;
using ProgettoSettimanale2_BU2.ViewModels;

namespace ProgettoSettimanale2_BU2.Services
{
    public class CameraService
    {
        private readonly ApplicationDbContext _context;

        public CameraService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Camera>> GetAllCamereAsync()
        {
            return await _context.Camere.Include(c => c.Tipo).ToListAsync();
        }

        public async Task<List<Camera>> GetCamereListAsync()
        {
            return await _context.Camere.ToListAsync();
        }

        public async Task<List<Stato>> GetCameraStatiAsync()
        {
            return await _context.Stati.ToListAsync();
        }

        public async Task<Camera> GetCameraByIdAsync(Guid id)
        {
            return await _context.Camere.Include(c => c.Tipo).FirstOrDefaultAsync(c => c.CameraId == id);
        }

        public async Task<List<Tipo>> GetAllTipiAsync()
        {
            return await _context.TipiCamere.ToListAsync();
        }

        public async Task<bool> UpdateCameraAsync(Guid id, EditCameraViewModel model)
        {
            var camera = await _context.Camere.FindAsync(id);
            if (camera == null)
            {
                return false;
            }

            camera.Numero = model.Numero;
            camera.TipoId = model.TipoId;
            camera.Prezzo = model.Prezzo;
            camera.Disponibile = model.Disponibile;

            _context.Update(camera);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCameraAsync(Guid id)
        {
            var camera = await _context.Camere.FindAsync(id);
            if (camera == null)
            {
                return false;
            }

            _context.Camere.Remove(camera);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
