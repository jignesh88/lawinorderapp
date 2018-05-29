using System;
using AutoMapper;
using LawInOrderApp.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
namespace LawInOrderApp.WebApi.Configuration
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services){

            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper();

            AutoMapperConfig.RegisterMappings();
        }
    }
}
