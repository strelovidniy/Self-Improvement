using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Self.Improvement.Data.Context;

namespace Self.Improvement.Web.ServiceExtensions
{
    public static class DbExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services)
        {
            services.AddDbContext<SelfImprovementContext>(
                options => options.UseSqlServer("name=ConnectionStrings:SelfImprovementDatabase"));
        }
    }
}
