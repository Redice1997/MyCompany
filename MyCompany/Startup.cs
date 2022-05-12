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
            //��������� ��������� ������������ � ������������� (MVC)
            services.AddControllersWithViews()
                //���������� ������������� � asp.net core 3.0
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //!!! ������� ����������� middleware ����� �����

            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();           

            app.UseRouting();

            //����������� ��������� ��������� ������ � ���������� (css, js � �.�.)
            app.UseStaticFiles();

            //����������� ������ ��� ��������� (endpoints)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
