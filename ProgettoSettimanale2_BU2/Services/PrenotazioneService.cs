using Microsoft.EntityFrameworkCore;
using ProgettoSettimanale2_BU2.Data;
using ProgettoSettimanale2_BU2.Models;
using ProgettoSettimanale2_BU2.ViewModels;

namespace ProgettoSettimanale2_BU2.Services
{
    public class PrenotazioneService
    {
        private readonly ApplicationDbContext _context;

        public PrenotazioneService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Prenotazione>> GetAllPrenotazioniAsync()
        {
            return await _context.Prenotazioni.Include(p => p.Cliente).Include(p => p.Camera).Include(p => p.Stato).ToListAsync();
        }

        public async Task<Prenotazione> GetPrenotazioneByIdAsync(Guid id)
        {
            return await _context.Prenotazioni.Include(p => p.Cliente).Include(p => p.Camera).Include(p => p.Stato).FirstOrDefaultAsync(p => p.PrenotazioneId == id);
        }

        public async Task AddPrenotazioneAsync(AddPrenotazioneViewModel model)
        {
            var camera = await _context.Camere.FindAsync(model.CameraId);
            if (camera == null)
            {
                throw new Exception("Camera non trovata");
            }
            var nuovaPrenotazione = new Prenotazione
            {
                PrenotazioneId = Guid.NewGuid(),
                ClienteId = model.ClienteId,
                CameraId = model.CameraId,
                DataInizio = model.DataInizio,
                DataFine = model.DataFine,
                StatoId = int.Parse(model.Stato),
            };

            camera.Disponibile = false;
            _context.Prenotazioni.Add(nuovaPrenotazione);
            _context.Camere.Update(camera);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePrenotazioneAsync(EditPrenotazioneViewModel model)
        {
            var prenotazione = await _context.Prenotazioni.FindAsync(model.PrenotazioneId);

            if (prenotazione != null)
            {
                var oldCamera = await _context.Camere.FindAsync(prenotazione.CameraId);
                if (oldCamera != null)
                {
                    oldCamera.Disponibile = true;
                    _context.Camere.Update(oldCamera);
                }

                var newCamera = await _context.Camere.FindAsync(model.CameraId);
                if (newCamera != null && newCamera.Disponibile)
                {
                    prenotazione.ClienteId = model.ClienteId;
                    prenotazione.CameraId = model.CameraId;
                    prenotazione.DataInizio = model.DataInizio;
                    prenotazione.DataFine = model.DataFine;
                    prenotazione.StatoId = int.Parse(model.Stato);

                    newCamera.Disponibile = false;
                    _context.Camere.Update(newCamera);

                    _context.Prenotazioni.Update(prenotazione);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("La nuova camera selezionata non è disponibile.");
                }
            }
        }


        public async Task DeletePrenotazioneAsync(Guid id)
        {
            var prenotazione = await _context.Prenotazioni.FindAsync(id);

            if (prenotazione != null)
            {
                var camera = await _context.Camere.FindAsync(prenotazione.CameraId);

                if (camera != null)
                {
                    camera.Disponibile = true;
                    _context.Camere.Update(camera);
                }

                _context.Prenotazioni.Remove(prenotazione);
                await _context.SaveChangesAsync();
            }
        }
    }
}
