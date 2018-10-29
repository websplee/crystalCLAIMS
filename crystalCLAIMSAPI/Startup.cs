using System;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using crystalCLAIMSAPI.Models;
using crystalCLAIMSAPI.Data;
using crystalCLAIMSAPI.Resources;
using crystalCLAIMSAPI.Repositories;
using crystalCLAIMSAPI.Repositories.Interfaces;
using crystalCLAIMSAPI.Helpers;
using crystalCLAIMSAPI.ViewModels;
using crystalCLAIMSAPI.UnitOfWork;
using Swashbuckle.AspNetCore.Swagger;

namespace crystalCLAIMSAPI
{
    public class Startup
    {
        private readonly IHostingEnvironment _environment;
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            _environment = env;

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var stsConfig = Configuration.GetSection("StsConfig");
            var useLocalCertStore = Convert.ToBoolean(Configuration["UseLocalCertStore"]);
            var certificateThumbprint = Configuration["CertificateThumbprint"];
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            X509Certificate2 cert;

            if (_environment.IsProduction())
            {
                if (useLocalCertStore)
                {
                    using (X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine))
                    {
                        store.Open(OpenFlags.ReadOnly);
                        var certs = store.Certificates.Find(X509FindType.FindByThumbprint, certificateThumbprint, false);
                        cert = certs[0];
                        store.Close();
                    }
                }
                else
                {
                    /* Azure deployment, will be used if deployed to Azure
                    var vaultConfigSection = Configuration.GetSection("Vault");
                    var keyVaultService = new KeyVaultCertificateService(vaultConfigSection["Url"], vaultConfigSection["ClientId"], vaultConfigSection["ClientSecret"]);
                    cert = keyVaultService.GetCertificateFromKeyVault(vaultConfigSection["CertificateName"]);
                    */
                }
            }
            else
            {
                // cert = new X509Certificate2(Path.Combine(_environment.ContentRootPath, "webspleeserver.pfx"), "");
            }

            services.AddDbContext<CrystalCLAIMSDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Repositories
            services.AddScoped<IClaimRepository, ClaimRepository>()
                .AddScoped<IClaimDiagnosisRepository, ClaimDiagnosisRepository>()
                .AddScoped<IClaimDrugRepository, ClaimDrugRepository>()
                .AddScoped<IClaimDoctorRepository, ClaimDoctorRepository>()
                .AddScoped<IClaimServiceProvidedRepository, ClaimServiceProvidedRepository>()
                .AddScoped<IDistrictRepository, DistrictRepository>()
                //.AddScoped<IEntityBaseRepository, EntityBaseRepository>()
                .AddScoped<IHCPUserRepository, HCPUserRepository>()
                .AddScoped<IHCPDiagnosisRepository, HCPDiagnosisRepository>()
                .AddScoped<IHCPDoctorRepository, HCPDoctorRepository>()
                .AddScoped<IHCPDrugRepository, HCPDrugRepository>()
                .AddScoped<IHCPServiceRepository, HCPServiceRepository>()
                .AddScoped<IHealthcareProviderRepository, HealthcareProviderRepository>()
                .AddScoped<IInsuranceProviderRepository, InsuranceProviderRepository>()
                .AddScoped<IIPUSerRepository, IPUserRepository>()
                .AddScoped<IMedicalPersonnelRepository, MedicalPersonnelRepository>()
                .AddScoped<IMemberRepository, MemberRepository>()
                .AddScoped<IPolicyHolderRepository, PolicyHolderRespository>() 
                .AddScoped<IProvinceRepository, ProvinceRepository>()
                .AddScoped<IStandardDiagnosisRepository, StandardDiagnosisRepository>()
                .AddScoped<IStandardDrugRepository, StandardDrugRepository>()
                .AddScoped<IStandardServiceProvidedRepository, StandardServiceProvidedRepository>()
                .AddScoped<IUnitOfWork, HttpUnitOfWork>();

            services.Configure<CrystalConfig>(Configuration.GetSection("crystalCLAIMSAPIConfig"));
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            services.AddSingleton<LocService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // Specifically added for the HttpUnitOfWork injection
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddAuthentication();            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddViewLocalization()
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
                        return factory.Create("SharedResource", assemblyName.Name);
                    };
                });
            services.AddAutoMapper(x => x.AddProfile(new AutoMapperProfile()));
            
            /*Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });*/

            // Add Swagger support
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "crystalCLAIMS API",
                    Description = "Core API definition for the crystalCLAIMS project",
                    TermsOfService = "Make sure you are authorised and fully paid for this service",
                    Contact = new Contact
                    {
                        Name = "Humphrey Chinyama",
                        Email = "hchinyama@crystalisedliquid.com",
                        Url = "https://www.crystalisedliquid.com"
                    },
                    License = new License
                    {
                        Name = "Use under CLE License",
                        Url = "https://crystalisedliquid.com/license"
                    }
                });

                /*c.AddSecurityDefinition("OpenID Connect", new OAuth2Scheme
                {
                    Type = "oauth2",
                    Flow = "password",
                    TokenUrl = "/connect/token"
                });
                */
            });
            // services.AddTransient<IProfileService, IdentityWithAdditionalClaimsProfileService>();

            // services.AddTransient<IEmailSender, EmailSender>();
            // Business Services
            services.AddScoped<IEmailer, Emailer>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug(LogLevel.Warning);
            // loggerFactory.AddFile(Configuration.GetSection("Logging"));

            Utilities.ConfigureLogger(loggerFactory);
            EmailTemplates.Initialize(env);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Enforce https during production
                //var rewriteOptions = new RewriteOptions()
                //    .AddRedirectToHttps();
                //app.UseRewriter(rewriteOptions);

                app.UseExceptionHandler("/Home/Error");
            }

            //Configure Cors
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseStaticFiles();
            // app.UseSpaStaticFiles();
            app.UseAuthentication();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "crystalCLAIMS API V1");
            });


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Claims}/{action=Get}/{id?}");
            });

            // Database initialization here 
        }
    }
}
