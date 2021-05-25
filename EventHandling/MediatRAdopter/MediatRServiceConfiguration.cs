using EventHandling.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatRAdopter.EventHandling;
using MediatR;

namespace EventHandling.MediatRAdopter
{
    public static class MediatRServiceConfiguration
    {
        static bool IsEventHandler(this Type @class)
        => @class.IsClass && @class.GetInterfacesOfType(typeof(IHandleEvent<>)).Any();

        public static IEnumerable<(Type handlerType, IEnumerable<Type> EventTypes)> GetTypesOfHandlersAndEvents(params Assembly[] assemblies)
        => assemblies.SelectMany(asm => asm.GetTypes().Where(IsEventHandler))
            .Select(@class => (
                handlerType: @class,
                EventTypes: @class.GetInterfacesOfType(typeof(IHandleEvent<>))
                            .Select(i => i.GetGenericArguments()[0])));

        static void WrapEventHandler<THandler, TEvent>(IServiceCollection services)
             where TEvent : AnEvent
             where THandler : class, IHandleEvent<TEvent>
        {
            //The following line may optimize the performance a bit.
            services.AddScoped<THandler>();
            services.AddScoped(serviceProvider =>
            {
                //var ourHandler = ActivatorUtilities.CreateInstance<THandler>(serviceProvider);
                var ourHandler = serviceProvider.GetService<THandler>();
                return new MediatRHandlerAdopter<TEvent>(ourHandler)
                        as INotificationHandler<MediatREventEnvelope<TEvent>>;
            });
        }

        static void WrapEventHandlerByType(Type handlerType, Type EventType, IServiceCollection services)
        => typeof(MediatRServiceConfiguration)
        .GetMethod(nameof(WrapEventHandler), BindingFlags.Static | BindingFlags.NonPublic)
        .MakeGenericMethod(handlerType, EventType)
        .Invoke(null, new object[] { services });

        public static IServiceCollection AddEventHandlersFromAssembly<T>(this IServiceCollection services)
        => AddEventHandlersFromAssembly(services, Assembly.GetAssembly(typeof(T)));

        public static IServiceCollection AddEventHandlersFromAssembly(this IServiceCollection services, params Assembly[] assemblies)
        {
            foreach (var (handlerType, EventTypes) in GetTypesOfHandlersAndEvents(assemblies))
                foreach (var EventType in EventTypes)
                {
                    WrapEventHandlerByType(handlerType, EventType, services);
                }
            //AddAllBehaviors(services, assembly);
            return services.AddMediatR(assemblies)
                .AddScoped<IEventBus, MediatREventBusAdopter>();
        }


        public static IServiceCollection AddBehavior<TEvent, TBehavior>(this IServiceCollection services)
            where TEvent : AnEvent
            where TBehavior : class, IEventPipelineBehavior<TEvent>
        => AddBehaviorType(typeof(TEvent), typeof(TBehavior), services);

        public static IServiceCollection AddBehavior(this IServiceCollection services, Type behaviorType, Assembly assembly)
        {
            foreach (var cmd in assembly.GetTypes().Where(t => t.BaseType == typeof(AnEvent)))
            {
                AddBehaviorType(cmd, behaviorType.MakeGenericType(cmd), services);
            }

            return services;
        }

        public static IServiceCollection AddBehaviorType(Type @event, Type behavior, IServiceCollection services)
        {
            var mediatRPipelineType = typeof(IPipelineBehavior<,>)
                                        .MakeGenericType(typeof(MediatREventEnvelope<>)
                                        .MakeGenericType(@event), typeof(Unit));


            object WrapBehavior(IServiceProvider serviceProvider)
                => ActivatorUtilities.CreateInstance(serviceProvider, typeof(MediatRPipelineBehaviorAdopter<>).MakeGenericType(@event)
                                                , new[] { ActivatorUtilities.CreateInstance(serviceProvider, behavior) });

            services.AddTransient(mediatRPipelineType, WrapBehavior);
            return services;
        }

        static bool IsBehavior(this Type @class)
       => @class.IsClass && @class.GetInterfacesOfType(typeof(IEventPipelineBehavior<>)).Any();

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
