using AdvertisementProject.Business.Interfaces;
using AdvertisementProject.Business.Services;
using AdvertisementProject.Business.ValidationRules.AdvertisementAppUserValidator;
using AdvertisementProject.Business.ValidationRules.AdvertisementValidator;
using AdvertisementProject.Business.ValidationRules.AppUserValidator;
using AdvertisementProject.Business.ValidationRules.GenderValidator;
using AdvertisementProject.Business.ValidationRules.ProvidedServiceValidator;
using AdvertisementProject.DataAccess.Contexts;
using AdvertisementProject.DataAccess.UnitOfWork;
using AdvertisementProject.Dtos.AdvertisementAppUserDtos;
using AdvertisementProject.Dtos.AdvertisementDtos;
using AdvertisementProject.Dtos.AppUserDtos;
using AdvertisementProject.Dtos.GenderDtos;
using AdvertisementProject.Dtos.ProvidedServiceDtos;
using AdvertisementProject.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AdvertisementContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });

            services.AddScoped<IUow, Uow>();

            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateDtoValidator>();

            services.AddTransient<IValidator<AdvertisementCreateDto>, AdvertisementCreateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementUpdateDto>, AdvertisementUpdateDtoValidator>();

            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();

            services.AddTransient<IValidator<GenderCreateDto>, GenderCreateDtoValidator>();
            services.AddTransient<IValidator<GenderUpdateDto>, GenderUpdateDtoValidator>();

            services.AddTransient<IValidator<AdvertisementAppUserCreateDto>, AdvertisementAppUserCreateDtoValidator>();

            services.AddScoped<IProvidedServiceService, ProvidedServiceService>();
            services.AddScoped<IAdvertisementService, AdvertisementService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<IAdvertisementAppUserService, AdvertisementAppUserService>();
        }
    }
}
