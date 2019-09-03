using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MCB.Memphis.Core.Services;
using MCB.Memphis.Services.News;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.DQE.SqlServer;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using MCB.Memphis.Core;
using MCB.MasterPiece.Hashing.Services.Interfaces;
using MCB.MasterPiece.Hashing.Services;
using MCB.Memphis.Services.AdminSites;
using MCB.Memphis.Services.AdminUser;

namespace MCB.Memphis.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // ******
            // BLAZOR COOKIE Auth Code (begin)
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = new PathString("/Account/Login");
                options.ReturnUrlParameter = "returnUrl";
            });
            services.AddMvc(options =>
            {
                options.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build()));
            });

            // From: https://github.com/aspnet/Blazor/issues/1554
            // HttpContextAccessor
            services.AddHttpContextAccessor();
            services.AddScoped<HttpContextAccessor>();
            services.AddHttpClient();
            services.AddScoped<HttpClient>();

            //// BLAZOR COOKIE Auth Code (end)
            //// ******
            services.AddRazorPages();
            services.AddServerSideBlazor();

            // DI
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<IAdminSiteService, Services.AdminSites.AdminSiteService>();
            services.AddScoped<AppStateProvider, AppStateProvider>();
            services.AddScoped<IHashingService, PBKDF2HashingService>();
            services.AddScoped<IAdminUserService, AdminUserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            MCB.MasterPiece.Data.DaoClasses.CommonDaoBase.ActualConnectionString = Configuration.GetConnectionString("DefaultConnection");
            // Configure the DQE
            RuntimeConfiguration.ConfigureDQE<SQLServerDQEConfiguration>(
                                            c => c.SetTraceLevel(TraceLevel.Verbose)
                                                    .AddDbProviderFactory(typeof(System.Data.SqlClient.SqlClientFactory))
                                                    .SetDefaultCompatibilityLevel(SqlServerCompatibilityLevel.SqlServer2012));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // ******
            // BLAZOR COOKIE Auth Code (begin)
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();
            // BLAZOR COOKIE Auth Code (end)
            // ******
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub<App>(selector: "app");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
