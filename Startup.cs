using System.Text;
using CriticalNotify.Data;
using CriticalNotify.Helper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;


namespace CriticalNotify
{
    public class Startup
    {
        private string connRoot { get; }
        readonly string sAllowS = "CorsDomain";
        public const string CookieScheme = "SES";

        public IConfiguration IConf { get; }


        public Startup(IConfiguration _IConf)
        {
            IConf = _IConf;

            connRoot = UStore.GetConn(IConf, "Root");
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Echo : DI
            services.AddDbContext<HNContext>(delegate (DbContextOptionsBuilder options)
            {
                options.UseSqlServer(connRoot);
            });
            services.AddScoped<I病患檔Service, 病患檔Service>();
            services.AddScoped<I報告台結果檔Service, 報告台結果檔Service>();
            services.AddScoped<I危急值通報檔Service, 危急值通報檔Service>();
            services.AddScoped<I繳費Service,繳費Service>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //* get IP */
            services.AddHttpContextAccessor();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

            //** 加入 appsettings.json 自訂的參數取得 */
            services.AddSingleton<IConfiguration>(IConf);
            services.AddSingleton<JwtHelpers>();
            /// * for Cors Domain , 注意網址結尾不要/符號
            services.AddCors(options =>
            {
                options.AddPolicy(name: sAllowS,
                    builder =>
                    {
                        builder.WithOrigins(
                            "https://localhost:5001",
                            "http://localhost:4200",
                            "http://localhost:4200/#",
                            "https://www.country.org.tw"
                        ).AllowAnyHeader().AllowAnyMethod();
                        // 這兩段是回傳資料用的.沒設定的話 Client 收到都是empty array
                    });
            });


            services.Configure<CookiePolicyOptions>(options =>
            {
                //* 原本是true,但有些人的電腦似乎會無效,所以改成false */
                options.CheckConsentNeeded = context => false;
                // options.MinimumSameSitePolicy = SameSiteMode.Strict;
                options.MinimumSameSitePolicy = SameSiteMode.Lax;

            });

            // * 重要!! 3.1版須添加此段才可以讀取 Request.Body
            // * for Kestrel , ex MAC OS
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            // * for IIS
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.SameSite = SameSiteMode.Strict;
            });


            // services.AddControllersWithViews();
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                };
            });

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors(sAllowS); // UseCors 要在 驗證授權 前面
            app.UseAuthentication(); // 先驗證
            app.UseAuthorization(); // 再授權

            // app.Run(async (context) =>
            //    {
            //        var client = new GetVaccLstDataAsync();
            //        var response = await client.GetVaccLstDataAsync();
            //        await context.Response.WriteAsync(response);
            //    });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
