
using Autofac;
using Autofac.Extras.DynamicProxy;
using CC.Yi.BLL;
using CC.Yi.Common.Cache;
using CC.Yi.Common.Castle;
using CC.Yi.DAL;
using CC.Yi.IBLL;
using CC.Yi.IDAL;
using CC.Yi.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Yi.API
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CC.Yi.API", Version = "v1" });
            });
            services.AddSession();
            services.AddMvc();
            string connection1 = Configuration["ConnectionStringBySQL"];
            string connection2 = Configuration["ConnectionStringByMySQL"];
            string connection3 = Configuration["ConnectionStringBySQLite"];
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(connection3, b => b.MigrationsAssembly("CC.Yi.API"));//�������ݿ�
            });


            //����ע��ת����Autofac
            //services.AddScoped(typeof(IBaseDal<>), typeof(BaseDal<>));
            //services.AddScoped(typeof(IstudentBll), typeof(studentBll));

            //reidsע��
            //services.AddSingleton(typeof(ICacheWriter), new RedisCacheService(new Microsoft.Extensions.Caching.Redis.RedisCacheOptions()
            //{
            //    Configuration = Configuration.GetSection("Cache.ConnectionString").Value,
            //    InstanceName = Configuration.GetSection("Cache.InstanceName").Value
            //}));


            //����Identity�����֤
            //services.AddIdentity<result_user, IdentityRole>(options =>
            // {
            //     options.Password.RequiredLength = 6;//������̳���
            //     options.Password.RequireDigit = false;//������������
            //     options.Password.RequireLowercase = false;//��������Сд��ĸ
            //     options.Password.RequireNonAlphanumeric = false;//�������������ַ�
            //     options.Password.RequireUppercase = false;//���������д��ĸ
            //    //options.User.RequireUniqueEmail = false;//ע�������Ƿ���Բ��ظ�
            //    //options.User.AllowedUserNameCharacters="abcd"//����ֻ������������ַ�
            //}).AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();
             services.AddCors(options => options.AddPolicy("CorsPolicy",//�����������
             builder =>
             {
                 builder.AllowAnyMethod()
                     .SetIsOriginAllowed(_ => true)
                     .AllowAnyHeader()
                     .AllowCredentials();
             }));
        }

        private void InitData(IServiceProvider serviceProvider)
        {
            var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = serviceScope.ServiceProvider.GetService<DataContext>();
            DbContentFactory.Initialize(context);//���þ�̬�෽��ע��
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CC.Yi.API v1"));
            }

            //app.UseAuthentication();
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            InitData(app.ApplicationServices);
        }
    }
}
