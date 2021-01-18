using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServerGame.DataBase;

namespace ServerGame
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
            string t = Configuration["DataBaseType"];
            string c = Configuration.GetConnectionString(nameof(ApplicationDBContext));
            ApplicationDBContext.SetDBOptions(Configuration["DataBaseType"], Configuration.GetConnectionString(nameof(ApplicationDBContext)));

            TimeSpan timeToPersistGamesResult = string.IsNullOrEmpty(Configuration["TimeToPersistGamesResult"]) ? TimeSpan.FromMinutes(5) : TimeSpan.Parse(Configuration["TimeToPersistGamesResult"]);
            TimeSpan timeToAttLeaderboadsGames = string.IsNullOrEmpty(Configuration["TimeToAttLeaderboardsGames"]) ? TimeSpan.FromMinutes(5) : TimeSpan.Parse(Configuration["TimeToAttLeaderboardsGames"]);
            MemoryDBGame.Instance.SetTimeInterval(timeToPersistGamesResult);
            MemoryDBLeaderboard.Instance.SetTimeInterval(timeToAttLeaderboadsGames);

            services.AddControllers();

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
