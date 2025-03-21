using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgettoSettimanale2_BU2.Services;
using ProgettoSettimanale2_BU2.ViewModels;

namespace ProgettoSettimanale2_BU2.Controllers
{
    public class PrenotazioneController : Controller
    {
        private readonly PrenotazioneService _prenotazioneService;
        private readonly ClienteService _clienteService;
        private readonly CameraService _cameraService;

        public PrenotazioneController(PrenotazioneService prenotazioneService, ClienteService clienteService, CameraService cameraService)
        {
            _prenotazioneService = prenotazioneService;
            _clienteService = clienteService;
            _cameraService = cameraService;
        }

        public async Task<IActionResult> Index()
        {
            var prenotazioni = await _prenotazioneService.GetAllPrenotazioniAsync();
            return View(prenotazioni);
        }

        public async Task<IActionResult> Add()
        {
            ViewBag.Clienti = await _clienteService.GetClientiListAsync();
            ViewBag.Camere = await _cameraService.GetCamereListAsync();
            ViewBag.Stati = await _cameraService.GetCameraStatiAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddPrenotazioneViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _prenotazioneService.AddPrenotazioneAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var prenotazione = await _prenotazioneService.GetPrenotazioneByIdAsync(id);
            if (prenotazione == null)
            {
                return NotFound();
            }

            ViewBag.Clienti = await _clienteService.GetClientiListAsync();
            ViewBag.Camere = await _cameraService.GetCamereListAsync();
            ViewBag.Stati = await _cameraService.GetCameraStatiAsync();

            var modelloPrenotazione = new EditPrenotazioneViewModel
            {
                PrenotazioneId = prenotazione.PrenotazioneId,
                ClienteId = prenotazione.ClienteId,
                CameraId = prenotazione.CameraId,
                DataInizio = prenotazione.DataInizio,
                DataFine = prenotazione.DataFine,
                Stato = prenotazione.Stato.Nome
            };

            return View(modelloPrenotazione);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditPrenotazioneViewModel model)
        {
            if (id != model.PrenotazioneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _prenotazioneService.UpdatePrenotazioneAsync(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var prenotazione = await _prenotazioneService.GetPrenotazioneByIdAsync(id);
            if (prenotazione == null)
            {
                return NotFound();
            }

            return View(prenotazione);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _prenotazioneService.DeletePrenotazioneAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
