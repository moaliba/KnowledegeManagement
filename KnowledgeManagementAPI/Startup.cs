using DataSource;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


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
            services.AddDbContext<ReadAndWriteDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("KnowledgeManagementDBConnection")));
            ////services.AddScoped<IReadDbContext, ReadDbContext>();
            ////services.AddScoped<IWriteDBContext, WriteDBContext>(x => x.GetService<WriteDBContext>());
            ////services.AddScoped<IUnitOfWork, WriteDBContext>(x => x.GetService<WriteDBContext>());
            ///////////////////////////////////////////////////////
            ////services.AddScoped<ITeamRepository, TeamRepository>();
            //services.AddScoped<ITeamRepository, TeamRepository>(x => x.GetService<TeamRepository>());
            ///////////////////////////////////////////////////////

            //services.AddScoped<IHandleCommand<DefineTeamCommand>, DefineTeamCommandHandler>();
            //services.AddScoped<IRequestHandler<MediatRCommandEnvelope<DefineTeamCommand>, Unit>, MediatRHandlerAdopte<DefineTeamCommand>>();

            ////services.AddCommandHandlersFromAssembly<DefineTeamCommandHandler>();
            ////services.AddQueryHandlersFromAssembly<GetAllTeamsQueryhandler>();

            ////services.AddBehavior<DefineTeamCommand, LoggingStation<DefineTeamCommand>>();
            ////services.AddScoped<Filters.UnitOfWorkFilter>();
            services.AddApplicationServices();
            // services.AddScoped<PersianConvertorFilterAttribute>();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();

                      //  builder.AllowCredentials();
                    });
            });

            services.AddControllers(config =>
            {
                config.RespectBrowserAcceptHeader = true;
                config.ReturnHttpNotAcceptable = true;
                config.Filters.Add<Filters.UnitOfWorkFilter>();
               // config.Filters.Add(new HttpResponseExceptionFilter());
            });

            //.AddXmlDataContractSerializerFormatters();

            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KnowledgeManagementAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) //|| env.IsProduction()          
                                     // app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/error-local-development");
            else
            {
                app.UseExceptionHandler("/error");
                app.UseHsts();
            }

            //app.UseExceptionHandler(c => c.Run(async context =>
            //{
            //    var exception = context.Features
            //        .Get<IExceptionHandlerPathFeature>()
            //        .Error;
            //    var response = new { error = exception.Message , code=context.Response.StatusCode};
            //    await context.Response.WriteAsJsonAsync(response);
            //}));

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KnowledgeManagementAPI v1"));


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
