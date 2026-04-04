using Microsoft.AspNetCore.Mvc;
using Vagabond_frontend.DTOs;
using Vagabond_frontend.Services;

namespace Vagabond_frontend.Controllers
{
    public class DestinationController : Controller
    {
        private readonly DestinationService _service;
        public DestinationController(DestinationService service) 
        { 
            _service = service;
        }

        public async Task<IActionResult> GetAll()
        {
            var resp = await _service.GetAll();
            return View(resp);
        }


        [HttpPost]
        public async Task<IActionResult> Create(DestinationDto dto)
        {
            await _service.Create(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var data = await _service.GetById(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, DestinationDto dto)
        {
            await _service.Update(id, dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}