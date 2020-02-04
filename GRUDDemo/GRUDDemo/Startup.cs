using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using GRUDDemo.Models;
using GRUDDemo.Services;

namespace GRUDDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            //註冊 DB Context，指定使用 SQL 資料庫
            services.AddDbContextPool<DemoDBContext>(options =>
            {
                //TODO: 實際應用時連線字串不該寫死，應移入設定檔並加密儲存
                options.UseSqlServer(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Bang\source\repos\bang1983\YCDemo\GRUDDemo\YCDemo.mdf; Integrated Security = True; Connect Timeout = 30");
            });


            /* 
			 * services.AddTransient 每次注入時都重新產生一個新的物件
			 * services.AddScoped 每個Request的第一次注入時都重新產生一個新的物件，直到Request結束
			 * services.AddSingleton 程式運行期間只會有一個物件
			 */

            //services.AddScoped<ICommonService, CommonService>();
            services.AddScoped(typeof(IService<>), typeof(Service<>));

            // 依賴注入容器區
            #region ########## DI IRepository ########## 
            services.AddScoped<IRepository<DemoCode>, Repository<DemoCode>>();
            #endregion

            // 依賴注入服務區
            #region ########## DI IRepository ########## 
            services.AddScoped<IDemoCodeService, DemoCodeService>();
            #endregion

 

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DemoDBContext dbContext)
        {

            //檢查資料表是否已經存在，若不存在自動建立；若資料表存在但版本太舊符則自動更新。
            //並且限定只有LocalDB才能執行
            if (dbContext.Database.GetDbConnection().ConnectionString.Contains("MSSQLLocalDB"))
            {
                dbContext.Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
