using AdvertisementProject.Business.Interfaces;
using AdvertisementProject.Common.Enums;
using AdvertisementProject.Dtos.AdvertisementAppUserDtos;
using AdvertisementProject.Dtos.AppUserDtos;
using AdvertisementProject.Dtos.MilitaryStatusDtos;
using AdvertisementProject.Entities;
using AdvertisementProject.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace AdvertisementProject.WebUI.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IAdvertisementAppUserService _advertisementAppUserService;

        public AdvertisementController(IAppUserService appUserService, IAdvertisementAppUserService advertisementAppUserService)
        {
            _appUserService = appUserService;
            _advertisementAppUserService = advertisementAppUserService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="Member")]
        public async Task<IActionResult> Send(int advertisementId)
        {
            var userId = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);

            var userResponse=await _appUserService.GetByIdServiceAsync<AppUserListDto>(userId);

            ViewBag.GenderId=userResponse.Data.GenderId;

            var items = Enum.GetValues(typeof(MilitaryStatusType));

            var list=new List<MilitaryStatusListDto>();

            foreach (int item in items)
            {
                list.Add(new MilitaryStatusListDto
                {
                    Id = item,
                    Definition = Enum.GetName(typeof(MilitaryStatusType), item),
                });
            }

            ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");

            return View(new AdvertisementAppUserCreateModel
            {
                AdvertisementId = advertisementId,
                AppUserId = userId,
            });
        }

        [Authorize(Roles="Member")]
        [HttpPost]
        public async Task<IActionResult> Send(AdvertisementAppUserCreateModel advertisementAppUserCreateModel)
        {
            AdvertisementAppUserCreateDto advertisementAppUserCreateDto = new();

            //resim yükleme
            if (advertisementAppUserCreateModel.CvFile!=null)
            {
                var fileName=Guid.NewGuid().ToString();
                var extName = Path.GetExtension(advertisementAppUserCreateModel.CvFile.FileName);

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "cvFiles", fileName + extName);

                var stream = new FileStream(path, FileMode.Create);

                await advertisementAppUserCreateModel.CvFile.CopyToAsync(stream);

                advertisementAppUserCreateDto.CvPath = path;
            }
            //resim yükleme bitti

            advertisementAppUserCreateDto.AdvertisementAppUserStatusId = advertisementAppUserCreateModel.AdvertisementAppUserStatusId;
            advertisementAppUserCreateDto.AdvertisementId = advertisementAppUserCreateModel.AdvertisementId;
            advertisementAppUserCreateDto.AppUserId = advertisementAppUserCreateModel.AppUserId;
            advertisementAppUserCreateDto.EndDate = advertisementAppUserCreateModel.EndDate;
            advertisementAppUserCreateDto.MilitaryStatusId = advertisementAppUserCreateModel.MilitaryStatusId;
            advertisementAppUserCreateDto.WorkExperience = advertisementAppUserCreateModel.WorkExperience;

            var response=await _advertisementAppUserService.CreateAdvertisementServiceAsync(advertisementAppUserCreateDto);

            if (response.ResponseType==Common.ResponseType.ValidationError)
            {
                foreach (var error in response.ValidationErrors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                var userId = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);

                var userResponse=await _appUserService.GetByIdServiceAsync<AppUserListDto>(userId);

                ViewBag.GenderId = userResponse.Data.GenderId;

                var items = Enum.GetValues(typeof(MilitaryStatusType));
                var list=new List<MilitaryStatusListDto>();

                foreach (int item in items)
                {
                    list.Add(new MilitaryStatusListDto
                    {
                        Id = item,
                        Definition = Enum.GetName(typeof(MilitaryStatusType), item)
                    });
                }

                ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");

                return View(advertisementAppUserCreateModel);
            }

            else
            {
                return RedirectToAction("HumanResource", "Home");
            }
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> List()
        {
            var list = await _advertisementAppUserService.GetListAdvertisementServiceAsync(AdvertisementAppUserStatusType.Basvurdu);

            return View(list);
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> SetStatus(int advertisementAppUserId,AdvertisementAppUserStatusType advertisementAppUserStatusType)
        {
            await _advertisementAppUserService.SetStatusAsync(advertisementAppUserId, advertisementAppUserStatusType);

            return RedirectToAction(nameof(List));
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> ApprovedList()
        {
            var list = await _advertisementAppUserService.GetListAdvertisementServiceAsync(AdvertisementAppUserStatusType.Mulakat);

            return View(list);
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> RejectedList()
        {
            var list = await _advertisementAppUserService.GetListAdvertisementServiceAsync(AdvertisementAppUserStatusType.Olumsuz);

            return View(list);
        }
    }
}
