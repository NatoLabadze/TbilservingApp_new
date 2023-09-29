
using Core.Application.Interfaces.Repository;
using Core.Application.Services;
using Infrastructure.Database.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TbilservingApp.Application.Interfaces.Repository;

namespace Infrastructure.Database
{
    public static class ServiceExtensions
    {
        public static void AddDbLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TbilservingDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("TbilservingDBConnection")));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IStatementRepository, StatementsRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<ISmsService, SmsService>();
        }
    }
}
