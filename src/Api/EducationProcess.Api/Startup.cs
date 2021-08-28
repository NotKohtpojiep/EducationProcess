using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using EducationProcess.DataAccess;
using EducationProcess.DataAccess.Repositories;
using EducationProcess.DataAccess.Repositories.Interfaces;
using EducationProcess.Services;
using EducationProcess.Services.Interfaces;
using EducationProcess.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace EducationProcess.Api
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
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<ServicesMappingProfile>();
            });

            services.AddControllers();

            /*
            // accepts any access token issued by identity server
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = Configuration.GetConnectionString("IdentityServerUrl");

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

            // adds an authorization policy to make sure the token is for scope 'api1'
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "api1");
                });
            });
            */

            services.AddDbContext<EducationProcessContext>(optionsBuilder =>
                optionsBuilder.UseMySql(Configuration.GetConnectionString("ConnectionDbContext"), new MySqlServerVersion(new Version(8, 0, 22))));
            //services.BuildServiceProvider().GetService<EducationProcessContext>()?.Database.Migrate();

            #region Repositories implementation

            services.AddScoped<IAcademicYearRepository, AcademicYearRepository>();
            services.AddScoped<IAudienceRepository, AudienceRepository>();
            services.AddScoped<IAudienceTypeRepository, AudienceTypeRepository>();
            services.AddScoped<ICathedraRepository, CathedraRepository>();
            services.AddScoped<ICathedraSpecialtyRepository, CathedraSpecialtyRepository>();
            services.AddScoped<IConductedPairRepository, ConductedPairRepository>();
            services.AddScoped<IDisciplineRepository, DisciplineRepository>();
            services.AddScoped<IEducationCyclesAndModuleRepository, EducationCyclesAndModuleRepository>();
            services.AddScoped<IEducationFormRepository, EducationFormRepository>();
            services.AddScoped<IEducationLevelRepository, EducationLevelRepository>();
            services.AddScoped<IEducationPlanSemesterDisciplineRepository, EducationPlanSemesterDisciplineRepository>();
            services.AddScoped<IEducationPlanRepository, EducationPlanRepository>();
            services.AddScoped<IEmployeeCathedraRepository, EmployeeCathedraRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IFederalStateEducationalStandardRepository, FederalStateEducationalStandardRepository>();
            services.AddScoped<IFixedDisciplineRepository, FixedDisciplineRepository>();
            services.AddScoped<IFsesCategoryPartitionRepository, FsesCategoryPartitionRepository>();
            services.AddScoped<IFsesCategoryRepository, FsesCategoryRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IIntermediateCertificationFormRepository, IntermediateCertificationFormRepository>();
            services.AddScoped<ILessonTypeRepository, LessonTypeRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IReceivedEducationFormRepository, ReceivedEducationFormRepository>();
            services.AddScoped<IReceivedEducationRepository, ReceivedEducationRepository>();
            services.AddScoped<IReceivedSpecialtyRepository, ReceivedSpecialtyRepository>();
            services.AddScoped<IScheduleDisciplineReplacementRepository, ScheduleDisciplineReplacementRepository>();
            services.AddScoped<IScheduleDisciplineRepository, ScheduleDisciplineRepository>();
            services.AddScoped<ISemesterDisciplineRepository, SemesterDisciplineRepository>();
            services.AddScoped<ISemesterRepository, SemesterRepository>();

            #endregion

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #region Services implementation

            services.AddScoped<IAcademicYearService, AcademicYearService>();
            services.AddScoped<IAudienceService, AudienceService>();
            services.AddScoped<IAudienceTypeService, AudienceTypeService>();
            services.AddScoped<ICathedraService, CathedraService>();
            services.AddScoped<ICathedraSpecialtyService, CathedraSpecialtyService>();
            services.AddScoped<IConductedPairService, ConductedPairService>();
            services.AddScoped<IDisciplineService, DisciplineService>();
            services.AddScoped<IEducationCyclesAndModuleService, EducationCyclesAndModuleService>();
            services.AddScoped<IEducationFormService, EducationFormService>();
            services.AddScoped<IEducationLevelService, EducationLevelService>();
            services.AddScoped<IEducationPlanSemesterDisciplineService, EducationPlanSemesterDisciplineService>();
            services.AddScoped<IEducationPlanService, EducationPlanService>();
            services.AddScoped<IEmployeeCathedraService, EmployeeCathedraService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IFederalStateEducationalStandardService, FederalStateEducationalStandardService>();
            services.AddScoped<IFixedDisciplineService, FixedDisciplineService>();
            services.AddScoped<IFsesCategoryPartitionService, FsesCategoryPartitionService>();
            services.AddScoped<IFsesCategoryService, FsesCategoryService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IIntermediateCertificationFormService, IntermediateCertificationFormService>();
            services.AddScoped<ILessonTypeService, LessonTypeService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IReceivedEducationFormService, ReceivedEducationFormService>();
            services.AddScoped<IReceivedEducationService, ReceivedEducationService>();
            services.AddScoped<IReceivedSpecialtyService, ReceivedSpecialtyService>();
            services.AddScoped<IScheduleDisciplineReplacementService, ScheduleDisciplineReplacementService>();
            services.AddScoped<IScheduleDisciplineService, ScheduleDisciplineService>();
            services.AddScoped<ISemesterDisciplineService, SemesterDisciplineService>();
            services.AddScoped<ISemesterService, SemesterService>();

            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EducationProcess.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EducationProcess.Api v1"));

            }
            app.UseExceptionHandler("/error");

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //.RequireAuthorization("ApiScope");
            });
        }
    }
}