using System;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Self.Improvement.Domain.Hubs;
using Self.Improvement.Web.Middleware;
using Self.Improvement.Web.ServiceExtensions;

namespace Self.Improvement.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => 
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGoogleAuthentication(Configuration);

            services.AddGoogleAuthorization();

            services.AddHttpContextAccessor();
            
            services.AddControllers().AddNewtonsoftJson();

            services.AddServices();

            services.ApplyConfigurations(Configuration);

            services.ConfigureDbContext();

            services.AddSignalR();

            services.AddHangfire(configuration => configuration
               .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
               .UseSimpleAssemblyNameTypeSerializer()
               .UseRecommendedSerializerSettings()
               .UseSqlServerStorage(Configuration.GetConnectionString("SelfImprovementDatabase"), new SqlServerStorageOptions
               {
                   CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                   SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                   QueuePollInterval = TimeSpan.Zero,
                   UseRecommendedIsolationLevel = true,
                   DisableGlobalLocks = true
               }));

            services.AddHangfireServer();

            //services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(builder =>
            //    {
            //        builder.WithOrigins("https://example.com")
            //            .AllowCredentials()
            //            .AllowAnyHeader()
            //            .AllowAnyMethod();
            //    });
            //});

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration => configuration.RootPath = "ClientApp/dist");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMiddleware<TelegramBotMiddleware>();

            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseHangfireDashboard();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Lax
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<SignalRHub>("api/v1/chats/messages-hub");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapHangfireDashboard();
            });

            app.UseAngular(env);
        }
    }
}
