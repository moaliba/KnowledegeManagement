using DataSource;
using Microsoft.Extensions.DependencyInjection;
using ReadModels;
using DataAccess;
using UseCases.RepositoryContracts;
using DataAccess.Repositories;
using Commands.TeamCommands;
using CommandHandling.MediatRAdopter;
using CommandHandlers.TeamHandlers;
using QueryHandling.MediatRAdopter;
using ReadModels.Query.Team;
using EventHandling.MediatRAdopter;
using System.Reflection;
using UseCases.Reactors;
using ReadModels.Projectors;

namespace KnowledgeManagementAPI
{
    public static class IOCConfig
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ReadAndWriteDbContext>();
            services.AddScoped<IWriteDbContext>(x => x.GetService<ReadAndWriteDbContext>());
            services.AddScoped<IReadDbContext>(x=>x.GetService<ReadAndWriteDbContext>());
            services.AddScoped<IUnitOfWork>(x => x.GetService<ReadAndWriteDbContext>());

            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddMessageHandlers();
            services.AddStation<DefineTeamCommand, LoggingStation<DefineTeamCommand>>();
            services.AddScoped<Filters.UnitOfWorkFilter>();


            //EventHandling.MediatRAdopter.MediatRServiceConfiguration.WrapEventHandler<ProvinceAddedProjector, ProvinceAdded>(services);
            //services.AddEventHandlersFromAssembly<ProvinceAddedProjector>();
        }

        static void AddMessageHandlers(this IServiceCollection services)
        {
            services.AddCommandHandlersFromAssembly<DefineTeamCommandHandler>();
            services.AddQueryHandlersFromAssembly<GetAllTeamsQuery>();
            services.AddEventHandlersFromAssembly(Assembly.GetAssembly(typeof(TeamDefinedReactor))
                                                 , Assembly.GetAssembly(typeof(TeamListProjector))
                                                 );
        }
    }
}
