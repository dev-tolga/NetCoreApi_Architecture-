using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encyption;
using Core.Utilities.Security.Jwt;
using DataAccess.Conrete.EntityFramework.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebAPI
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
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowOrigin", builder => builder.WithOrigins("http://www.localhost:52468"));
            //});
            // services.AddSwaggerGen(options =>  
            // {  
            //     options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo  
            //     {  
            //         Title = "Place Info Service API",  
            //         Version = "v2",  
            //         Description = "Sample service for Learner",  
            //     });  
            // });  
            services.AddDbContext<FoodDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                };
            });

            services.AddDependencyResolvers(new ICoreModule[] {new CoreModule()});
        }
        protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            /* modelBuilder.Entity<ExchangeType>(entity =>
             {
                 entity.ToTable("ExchangeType");
 
                 entity.Property(e => e.Id).HasColumnName("ID");
 
                 entity.Property(e => e.ExchangeName)
                     .HasMaxLength(10)
                     .IsFixedLength(true);
 
                 entity.Property(e => e.ModDate)
                     .HasColumnType("datetime")
                     .HasDefaultValueSql("(getdate())");
 
                 entity.Property(e => e.Value).HasColumnType("decimal(18, 2)");
             });*/

          

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseSwagger();  
                // app.UseSwaggerUI(options =>options.SwaggerEndpoint("/swagger/v2/swagger.json", "PlaceInfo Services"));
            }

            app.ConfigureCustomExceptionMiddleware();

           // app.UseCors(builder => builder.WithOrigins("http://wwww.localhost:52468").AllowAnyHeader());

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

