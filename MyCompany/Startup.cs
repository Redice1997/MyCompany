using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
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
