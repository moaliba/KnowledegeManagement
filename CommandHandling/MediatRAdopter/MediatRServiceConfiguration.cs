﻿using CommandHandling.Abstractions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CommandHandling.MediatRAdopter
{
    public static class MediatRServiceConfiguration
    {

        public static IServiceCollection AddCommandHandlersFromAssembly<T>(this IServiceCollection services)
        => AddCommandHandlersFromAssembly(services, Assembly.GetAssembly(typeof(T)));

        public static IServiceCollection AddCommandHandlersFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            foreach (var (handlerType, commandTypes) in assembly.GetTypesOfHandlersAndCommands())
                foreach (var commandType in commandTypes)
                {
                    WrapCommandHandlerByType(handlerType, commandType, services);
                }

            return services.AddMediatR(assembly)
                .AddScoped<ICommandBus, MediatRCommandBusAdopter>();
        }

        public static IEnumerable<(Type handlerType, IEnumerable<Type> commandTypes)> GetTypesOfHandlersAndCommands(this Assembly assembly)
        => assembly.GetTypes()
            .Where(IsCommandHandler)
            .Select(@class => (
                handlerType: @class,
                commandTypes: @class.GetInterfacesOfType(typeof(IHandleCommand<>))
                            .Select(i => i.GetGenericArguments()[0])));

        static bool IsCommandHandler(this Type @class)
        => @class.IsClass && @class.GetInterfacesOfType(typeof(IHandleCommand<>)).Any();

        static void WrapCommandHandlerByType(Type handlerType, Type commandType, IServiceCollection services)
        => typeof(MediatRServiceConfiguration)
        .GetMethod(nameof(WrapCommandHandler), BindingFlags.Static | BindingFlags.NonPublic)
        .MakeGenericMethod(handlerType, commandType)
        .Invoke(null, new object[] { services });

        static void WrapCommandHandler<THandler, TCommand>(IServiceCollection services)
             where TCommand : Acommand
             where THandler : class, IHandleCommand<TCommand>
        {
            //To optimize the CPU load by spending some more memory:
            services.AddScoped<IHandleCommand<TCommand>, THandler>();
            services.AddScoped(serviceProvider =>
            {
                //var ourHandler = ActivatorUtilities.CreateInstance<THandler>(serviceProvider);
                var ourHandler = serviceProvider.GetService<IHandleCommand<TCommand>>();
                return new MediatRHandlerAdopte<TCommand>(ourHandler)
                        as IRequestHandler<MediatRCommandEnvelope<TCommand>, Unit>;
            });
        }

        public static IServiceCollection AddBehavior<TCommand, TBehavior>(this IServiceCollection services)
            where TCommand : Acommand
            where TBehavior : class, ICommandStation<TCommand>
        => AddBehaviorType(typeof(TCommand), typeof(TBehavior), services);

        public static IServiceCollection AddBehavior(this IServiceCollection services, Type behaviorType, Assembly assembly)
        {
            foreach (var cmd in assembly.GetTypes().Where(t => t.BaseType == typeof(Acommand)))
            {
                AddBehaviorType(cmd, behaviorType.MakeGenericType(cmd), services);
            }

            return services;
        }

        public static IServiceCollection AddBehaviorType(Type command, Type behavior, IServiceCollection services)
        {
            var mediatRPipelineType = typeof(IPipelineBehavior<,>)
                                        .MakeGenericType(typeof(MediatRCommandEnvelope<>)
                                        .MakeGenericType(command), typeof(Unit));


            object WrapBehavior(IServiceProvider serviceProvider)
                => ActivatorUtilities.CreateInstance(serviceProvider, typeof(MediatRPipelineBehaviorAdopter<>).MakeGenericType(command)
                                                , new[] { ActivatorUtilities.CreateInstance(serviceProvider, behavior) });

            services.AddTransient(mediatRPipelineType, WrapBehavior);
            return services;
        }

        static bool IsBehavior(this Type @class)
       => @class.IsClass && @class.GetInterfacesOfType(typeof(ICommandStation<>)).Any();

        public static IServiceCollection AddAllBehaviors(this IServiceCollection services, Assembly assembly)
        {
            foreach (var behaviorType in assembly.GetTypes().Where(IsBehavior))
            {
                AddBehavior(services, behaviorType, assembly);
            }

            return services;
        }
    }
}
