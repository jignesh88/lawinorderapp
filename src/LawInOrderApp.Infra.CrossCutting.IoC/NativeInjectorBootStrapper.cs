using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using LawInOrderApp.Domain.Core.Bus;
using Microsoft.AspNetCore.Authorization;
using LawInOrderApp.Domain.Interfaces;
using LawInOrderApp.Infra.Data.Context;
using LawInOrderApp.Infra.Data.Repository.EventSourcing;
using LawInOrderApp.Domain.Core.Events;
using LawInOrderApp.Infra.Data.EventSourcing;
using LawInOrderApp.Infra.Data.Repository;
using LawInOrderApp.Infra.Data.UoW;
using LawInOrderApp.Domain.Commands;
using LawInOrderApp.Domain.Core.Notifications;
using LawInOrderApp.Domain.CommandHandlers;
using LawInOrderApp.Infra.CrossCutting.Bus;
using LawInOrderApp.Infra.CrossCutting.Identity.Services;
using LawInOrderApp.Infra.CrossCutting.Identity.Models;
using LawInOrderApp.Application.Services;
using LawInOrderApp.Application.Interfaces;
using LawInOrderApp.Domain.Events;
using LawInOrderApp.Domain.EventHandlers;
using LawInOrderApp.Infra.CrossCutting.Identity.Authorization;

namespace LawInOrderApp.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Asp.net httpcontext dependecy
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Asp.net authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimRequirementHandler>();

            // Application
            services.AddScoped<ITimeSheetAppService, TimeSheetAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<TimeSheetCreatedEvent>, TimeSheetEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<CreateNewTimeSheetCommand>,
                TimeSheetCommandHandler>();

            // Infra - Data
            services.AddScoped<ITimeSheetRepository, TimeSheetRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<LawInOrderAppContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Service
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            //services.AddTransient<ISmsSender, AuthSMSMessageSender>();
            // Infra - Identity

            services.AddScoped<IUser, AspNetUser>();
        }


    }
}
