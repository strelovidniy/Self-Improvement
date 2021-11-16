﻿using Microsoft.Extensions.DependencyInjection;
using Self.Improvement.Domain.Services.Implementations;
using Self.Improvement.Domain.Services.Interfaces;
using Self.Improvement.Domain.TelegramBot;

namespace Self.Improvement.Web.ServiceExtensions
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ITelegramService, TelegramService>();
            services.AddTransient(provider => new ChatBot());
        }
    }
}