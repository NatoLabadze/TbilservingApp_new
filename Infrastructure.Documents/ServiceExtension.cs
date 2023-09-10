using Core.Application.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Documents
{
    public static class ServiceExtension
    {
        public static void AddDocumentLayer(this IServiceCollection services, IConfiguration configuration)

        {
            services.AddScoped<IDocumentService, DocumentService>();

        }
    }
}
