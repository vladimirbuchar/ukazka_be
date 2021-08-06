using Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Model;
using System.Linq;
using System.Text.RegularExpressions;

namespace EduApi
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
            services.RegistrationCodeBook();
            services.RegisterEmail();
            services.RegistrationUser();
            services.RegistrationRole();
            services.RegistrationAccessToken();
            services.RegistrationOrganizationRole();
            services.RegistrationOrganization();
            services.RegisterLicense();
            services.RegisterBranch();
            services.RegistrationCourse();
            services.RegistrationSlider();
            services.RegistrationClassRoom();
            services.RegistrationCourseTerm();
            services.RegistrationCourseLectorFacade();
            services.RegistrionCourseStudentFacade();
            services.RegistrationCourseLesson();
            services.RegistrationCourseLessonItem();
            services.RegistratioBankOfQuestion();
            services.RegistrationQuestion();
            services.RegistrationAnswer();
            services.RegisterNotification();
            services.RegisterFileUpload();
            services.RegisterTest();
            services.RegisterIntegration();
            services.RegisterPage();
            services.RegisterLifeTime();
            services.RegisterCertificate();
            services.RegisterPdf();
            services.RegisterSendMessage();
            services.RegisterStudentGroup();
            services.RegisterCourseMaterial();
            services.RegisterTextService();
            services.RegisterNote();
            services.RegisterCourseTable();
            services.RegisterChat();
            services.AddMvc(
                options =>
                {
                    options.Filters.Add(new ResponseCacheAttribute() { NoStore = true, Location = ResponseCacheLocation.None });
                    options.Filters.Add(new ProducesAttribute("application/json"));
                }
                ).SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddDbContext<EduDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("EduApi")));
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder => builder.SetIsOriginAllowed(IsOriginAllowed).AllowAnyMethod().AllowAnyHeader());
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "FlexibleLMS", Version = "1.0" });
                c.UseInlineDefinitionsForEnums();
            });
        }
        private static bool IsOriginAllowed(string host)
        {
            var corsOriginAllowed = new[] { "http://localhost:3000","https://app.flexiblelms.com" };
            return corsOriginAllowed.Contains(host);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            // AFAIK in netcoreapp2.2 this was not required
            // to use CORS with attributes.
            // This is now required, as otherwise a runtime exception is thrown
            // UseCors applies a global CORS policy, when no policy name is given
            // the default CORS policy is applied
            app.UseCors();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "FlexibleLMS";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FlexibleLMS API V1");
                c.RoutePrefix = "swagger";
            });
        }
    }
}