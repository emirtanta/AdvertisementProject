using AdvertisementProject.Business.Interfaces;
using AdvertisementProject.Dtos.AdvertisementDtos;
using AdvertisementProject.WebUI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisementProject.WebUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ApplicationController : Controller
    {
        private readonly IAdvertisementService _advertisementService;

        public ApplicationController(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        public async Task<IActionResult> List()
        {
            var response=await _advertisementService.GetAllServiceAsync();
            
            return this.ResponseView(response);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new AdvertisementCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdvertisementCreateDto advertisementCreateDto)
        {
            var response=await _advertisementService.CreateServiceAsync(advertisementCreateDto);

            return this.ResponseRedirectAction(response, "List");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var response = await _advertisementService.GetByIdServiceAsync<AdvertisementUpdateDto>(id);

            return this.ResponseView(response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AdvertisementUpdateDto advertisementUpdateDto)
        {
            var response=await _advertisementService.UpdateServiceAsync(advertisementUpdateDto);

            return this.ResponseRedirectAction(response,"List");  
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            var response=await _advertisementService.RemoveServiceAsync(id);

            return this.ResponseRedirectAction(response, "List");
        }
    }
}
