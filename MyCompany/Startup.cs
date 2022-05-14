using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyCompany.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public void ConfigureServices(IServiceCollection services)
        {
            //подключаем конфиг из appsettings.json
            Configuration.Bind("Project", new Config());
            //добавляем поддержку контроллеров и представлений (MVC)
            services.AddControllersWithViews()
                //выставляем совместимость с asp.net core 3.0
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //!!! порядок регистрации middleware очень важен

            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();           

            app.UseRouting();

            //подключение поддержки статичных файлов в приложении (css, js и т.д.)
            app.UseStaticFiles();

            //Регистрация нужных нам маршрутов (endpoints)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
