using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PunchClock.Service.Persistence.Interfaces.Readers;
using PunchClock.Service.Persistence.Interfaces.Removes;
using PunchClock.Service.Persistence.Interfaces.Writers;
using PunchClock.Service.PersistenceDb.Context;
using PunchClock.Service.PersistenceDb.Services.Readers;
using PunchClock.Service.PersistenceDb.Services.Removes;
using PunchClock.Service.PersistenceDb.Services.Writers;
using PunchClock.Service.Web.Validators.v1.PointRecord;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchClock.Service.Web
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;

        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env;
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(opt =>
                {
                    opt.RegisterValidatorsFromAssemblyContaining<UserValidator>();
                    opt.RegisterValidatorsFromAssemblyContaining<PunchClockValidator>();
                    opt.RegisterValidatorsFromAssemblyContaining<AuthResetValidator>();
                    opt.RegisterValidatorsFromAssemblyContaining<AuthValidator>();
                    opt.RegisterValidatorsFromAssemblyContaining<DocumentValidator>();
                    opt.RegisterValidatorsFromAssemblyContaining<VacationValidator>();
                });

            services.AddTransient<DataContext>();
            services.AddCors();
            services.AddApiVersioning();

            // configure strongly typed settings objects
            var appSettingsSection = _configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            //Swagger
            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "API",
                        Version = "v1",
                        Description = "API",
                        Contact = new OpenApiContact
                        {
                            Name = "Leandro Zavaski"
                        }
                    });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
            });

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IReadUser>();
                        var userId = context.Principal.Identity.Name;
                        var user = userService.GetUserByIdAsync(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            //Register Commands
            //services.AddMediatR(typeof(ReadAuthQuery).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(WritePunchClockCommand).GetTypeInfo().Assembly);

            //services.AddMediatR(typeof(ReadAuthQuery).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(ReadRolesQuery).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(ReadUsersQuery).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(ReadUserByIdQuery).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(ReadUserByDocumentQuery).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(ReadVacationQuery).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(WriteAuthResetCommand).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(WritePunchClockCommand).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(ReadAuth).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(ReadAuth).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(ReadAuth).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(ReadAuth).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(ReadAuth).GetTypeInfo().Assembly);

            //Register Handlers
            services.AddTransient<IReadAuth, ReadAuth>();
            services.AddTransient<IReadUser, ReadUser>();
            services.AddTransient<IReadRole, ReadRole>();
            services.AddTransient<IReadVacation, ReadVacation>();

            services.AddTransient<IRemoveUser, RemoveUser>();
            services.AddTransient<IRemoveRole, RemoveRole>();
            services.AddTransient<IRemoveVacation, RemoveVacation>();

            services.AddTransient<IWriteAuth, WriteAuth>();
            services.AddTransient<IWriteRole, WriteRole>();
            services.AddTransient<IWriteUser, WriteUser>();
            services.AddTransient<IWritePunchClock, WritePunchClock>();
            services.AddTransient<IWriteVacation, WriteVacation>();

            //Logger
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole();
                loggingBuilder.AddEventLog();
                loggingBuilder.AddDebug();
            });

            //Mediator
            var assembly = AppDomain.CurrentDomain.Load("PunchClock.Service.Application");
            services.AddMediatR(assembly);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddFile("Logs/application-{Date}.txt");

            // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            // Adding auth and auth for api
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
