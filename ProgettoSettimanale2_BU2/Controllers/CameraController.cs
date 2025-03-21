using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgettoSettimanale2_BU2.Data;
using ProgettoSettimanale2_BU2.Services;
using ProgettoSettimanale2_BU2.ViewModels;

namespace ProgettoSettimanale2_BU2.Controllers
{
    public class CameraController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CameraService _cameraService;

        public CameraController(ApplicationDbContext context, CameraService cameraService)
        {
            _context = context;
            _cameraService = cameraService;
        }

        public async Task<IActionResult> Index()
        {
            var camere = await _cameraService.GetAllCamereAsync();
            return View(camere);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var camera = await _cameraService.GetCameraByIdAsync(id);
            if (camera == null)
            {
                return NotFound();
            }
            return View(camera);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camera = await _cameraService.GetCameraByIdAsync(id.Value);
            if (camera == null)
            {
                return NotFound();
            }

            var model = new EditCameraViewModel
            {
                CameraId = camera.CameraId,
                Numero = camera.Numero,
                TipoId = camera.TipoId,
                Tipo = camera.Tipo,
                Prezzo = camera.Prezzo,
                Disponibile = camera.Disponibile,
                Tipi = await _cameraService.GetAllTipiAsync()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditCameraViewModel model)
        {
            if (id != model.CameraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _cameraService.UpdateCameraAsync(id, model);
                if (!result)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }

            model.Tipi = await _cameraService.GetAllTipiAsync();
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camera = await _cameraService.GetCameraByIdAsync(id.Value);
            if (camera == null)
            {
                return NotFound();
            }

            return View(camera);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var result = await _cameraService.DeleteCameraAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
