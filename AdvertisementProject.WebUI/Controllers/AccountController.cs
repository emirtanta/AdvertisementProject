using AdvertisementProject.Business.Interfaces;
using AdvertisementProject.Common.Enums;
using AdvertisementProject.Dtos.AppUserDtos;
using AdvertisementProject.WebUI.Extensions;
using AdvertisementProject.WebUI.Models;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace AdvertisementProject.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IValidator<UserCreateModel> _userCreateModelValidator;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public AccountController(IGenderService genderService, IValidator<UserCreateModel> userCreateModelValidator, IAppUserService appUserService, IMapper mapper)
        {
            _genderService = genderService;
            _userCreateModelValidator = userCreateModelValidator;
            _appUserService = appUserService;
            _mapper = mapper;
        }

        public async Task<IActionResult> SignUp()
        {
            var response = await _genderService.GetAllServiceAsync();

            var model = new UserCreateModel
            {
                Genders = new SelectList(response.Data, "Id", "Definition")
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel userCreateModel)
        {
            var result=_userCreateModelValidator.Validate(userCreateModel);

            if (result.IsValid)
            {
                var dto = _mapper.Map<AppUserCreateDto>(userCreateModel);
                var createResponse = await _appUserService.CreateWithRoleServiceAsync(dto, (int)RoleType.Member);

                return this.ResponseRedirectAction(createResponse, "SignIn");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            var response= await _genderService.GetAllServiceAsync();

            userCreateModel.Genders = new SelectList(response.Data, "Id", "Definition", userCreateModel.GenderId);

            return View(userCreateModel);


        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {
            var result = await _appUserService.CheckUserServiceAsync(appUserLoginDto);

            if (result.ResponseType==Common.ResponseType.Success)
            {
                var roleResult = await _appUserService.GetRolesByUserIdServiceAsync(result.Data.Id);
                //ilgili kullanıcının rollerini çekiyoruz
                var claims = new List<Claim>();

                if (roleResult.ResponseType==Common.ResponseType.Success)
                {
                    foreach (var role in roleResult.Data)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.Definition));
                    }
                }
                claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()));

                var claimsIdentity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = appUserLoginDto.RememberMe
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("Kullanıcı adı veya şifre hatalı", result.Message);

            return View(appUserLoginDto);
        }

        public async Task<IActionResult>LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}
