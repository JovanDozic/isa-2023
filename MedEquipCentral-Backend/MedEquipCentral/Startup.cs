using MedEquipCentral.BL.Contracts.IService;
using MedEquipCentral.BL.Mapper;
using MedEquipCentral.BL.Service;
using MedEquipCentral.DA;
using MedEquipCentral.DA.Contexts;
using MedEquipCentral.DA.Contracts;
using MedEquipCentral.DA.Contracts.IRepository;
using MedEquipCentral.DA.Contracts.Model;
using MedEquipCentral.DA.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;

namespace MedEquipCentral
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.Configure<SMTPConfig>(Configuration.GetSection("SMTPConfig"));

            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), 
                    x => x.MigrationsHistoryTable("__EFMigrationsHistory", "medequipcentral"));

            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().
                 AllowAnyHeader());
            });

            services.AddCors(options =>
            {
                options.AddPolicy("_mySpecificOrigins", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                           .AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            // Mapper configuration:
            services.AddAutoMapper(typeof(CommonProfile));
            services.AddAutoMapper(typeof(CompanyProfile));
            services.AddAutoMapper(typeof(UserProfile));
            services.AddAutoMapper(typeof(EquipmentProfile));
            services.AddAutoMapper(typeof(AppointmentProfile));

            //JWT authentication
            var key = Environment.GetEnvironmentVariable("JWT_KEY") ?? "medequipcentral_secret_key";
            var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? "medequipcentral";
            var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? "medequipcentral-front.com";
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("AuthenticationTokens-Expired", "true");
                        }

                        return Task.CompletedTask;
                    }
                };
            });

            //Authorization
            services.AddAuthorization(options =>
            {
                options.AddPolicy("systemAdminPolicy", policy => policy.RequireRole("systemAdmin"));
                options.AddPolicy("companyAdminPolicy", policy => policy.RequireRole("companyAdmin"));
                options.AddPolicy("registredPolicy", policy => policy.RequireRole("registred"));
                options.AddPolicy("unauthenticatedPolicy", policy => policy.RequireRole("unauthenticated"));
                options.AddPolicy("allRolesPolicy", policy => policy.RequireRole("registred", "companyAdmin", "systemAdmin", "unauthenticated"));

            });

            BindServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowOrigin");

            app.UseCors("_mySpecificOrigins");


            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void BindServices(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<ITokenGeneratorRepository, TokenGeneratorRepository>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IEquipmentService, EquipmentService>();
            services.AddTransient<IEquipmentTypeService, EquipmentTypeService>();
            services.AddTransient<IAppointmentService, AppointmentService>();
        }

    }
}
