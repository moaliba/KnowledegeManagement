using CommandHandlers.TeamHandlers;
using CommandHandling.Abstractions;
using CommandHandling.MediatRAdopter;
using Commands.TeamCommands;
using DataAccess.Repositories;
using DataSource;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UseCases.RepositoryContracts;
using UseCases.RepositoryInfrastractureContracts;

namespace KnowledgeManagementAPI
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
            services.AddDbContext<WriteDBContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("KnowledgeManagementDBConnection")));
            services.AddDbContext<WriteDBContext>();
            services.AddScoped<IWriteDBContext, WriteDBContext>(x => x.GetService<WriteDBContext>());
            services.AddScoped<IUnitOfWork, WriteDBContext>(x => x.GetService<WriteDBContext>());
            ///////////////////////////////////////////////////////
            services.AddScoped<ITeamRepository, TeamRepository>();
            //services.AddScoped<ITeamRepository, TeamRepository>(x => x.GetService<TeamRepository>());
            ///////////////////////////////////////////////////////

            //services.AddScoped<IHandleCommand<DefineTeamCommand>, DefineTeamCommandHandler>();
            //services.AddScoped<IRequestHandler<MediatRCommandEnvelope<DefineTeamCommand>, Unit>, MediatRHandlerAdopte<DefineTeamCommand>>();

            services.AddCommandHandlersFromAssembly<DefineTeamCommandHandler>();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                    });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KnowledgeManagementAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KnowledgeManagementAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
