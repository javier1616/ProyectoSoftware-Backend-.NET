using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PS.AccessData;
using PS.AccessData.Commands;
using PS.AccessData.Queries;
using PS.Application.Services;
using PS.Domain.Commands;
using PS.Domain.Queries;


namespace PS.TP2_Cine.WebAPI
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
            services.AddControllers();

            var connectionString = Configuration.GetSection("ConnectionString").Value;
            services.AddDbContext<TemplateDbContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<IGenericsRepository, GenericsRepository>();
            services.AddTransient<IPeliculasService, PeliculasService>();
            services.AddTransient<IPeliculasQueries, PeliculasQueries>();
            services.AddTransient<IFuncionesService, FuncionesService>();
            services.AddTransient<IFuncionesQueries, FuncionesQueries>();
            services.AddTransient<ITicketsService, TicketsService>();
            services.AddTransient<ITicketsQueries, TicketsQueries>();
            services.AddTransient<ISalasQueries, SalasQueries>();

            services.AddCors(c => c.AddDefaultPolicy(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));


            services.AddSwaggerGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DBCine - TP2");
            });
        }

    }
}
