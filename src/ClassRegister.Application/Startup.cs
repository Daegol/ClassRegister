using System.Text;
using ClassRegister.Application.Frameworks;
using ClassRegister.Core.Repositories;
using ClassRegister.Infrastructure.Authorization;
using ClassRegister.Infrastructure.Database;
using ClassRegister.Infrastructure.Repositories;
using ClassRegister.Services.IServices;
using ClassRegister.Services.Mappers;
using ClassRegister.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace ClassRegister.Application
{
    public class Startup
    {
        public static IConfiguration Configuration { get; protected set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SqlOptions>(Configuration.GetSection("Sql"));

            var jwtSection = Configuration.GetSection("Jwt");
            services.Configure<JwtOptions>(jwtSection);
            var jwtOptions = new JwtOptions();
            jwtSection.Bind(jwtOptions);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(cfg =>
                {
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
                        ValidIssuer = jwtOptions.Issuer,
                        ValidateAudience = false,
                        ValidateLifetime = jwtOptions.ValidateLifetime
                    };
                });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(x => x.SerializerSettings.Formatting = Formatting.Indented);

            services.AddAuthorization(x => x.AddPolicy("Admin", p => p.RequireRole("Admin")));
            
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IParentRepository, ParentRepository>();
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddSingleton<IJwtHandler, JwtHandler>();

            services.AddSingleton(AutoMapperConfig.Initialize());
            services.AddDbContext<DatabaseContext>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IParentService, ParentService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IClassService, ClassService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(x => x.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseErrorHandler();
            app.UseMvc();
        }
    }
}