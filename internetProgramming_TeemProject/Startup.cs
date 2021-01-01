using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using internetProgramming_TeemProject.Data;
using internetProgramming_TeemProject.Services;
using internetProgramming_TeemProject.Entities;
using internetProgramming_TeemProject.Models;
using AutoMapper;
using System;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using static internetProgramming_TeemProject.Services.LoginRequestDTO;

namespace internetProgramming_TeemProject
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

            //services.AddDbContext<InstituteContext>(opt =>
            //opt.UseInMemoryDatabase("InstituteList"));

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IInstituteRepository, InstituteRepository>();

            services.AddDbContext<ProjectDbContext>(options =>
            {
                options.UseSqlite("Data Source=routine.db");
            });
           
            services.AddDbContext<ProjectDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                            .AddEntityFrameworkStores<ProjectDbContext>();
            services.Configure<Models.TokenManagement>(Configuration.GetSection("tokenConfig"));

            var token = Configuration.GetSection("tokenConfig").Get<Models.TokenManagement>();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                //Token Validation Parameters
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    //获取或设置要使用的Microsoft.IdentityModel.Tokens.SecurityKey用于签名验证。
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.
                    GetBytes(token.Secret)),
                    //获取或设置一个System.String，它表示将使用的有效发行者检查代币的发行者。
                    ValidIssuer = token.Issuer,
                    //获取或设置一个字符串，该字符串表示将用于检查的有效受众反对令牌的观众。
                    ValidAudience = token.Audience,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
            services.AddScoped<IAuthenticateService, TokenAuthenticationService>();
            services.AddScoped<IUserService, UserService>();
        }
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseExceptionHandler(appBuilder =>
                    {
                        appBuilder.Run(async context =>
                        {
                            context.Response.StatusCode = 500;
                            await context.Response.WriteAsync("Unexpected Error!");
                        });
                    });
                }


                /*app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("api/institute", "接口文档");
                });*/
                app.UseDefaultFiles();
                app.UseHttpsRedirection();



                app.UseStaticFiles();

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
