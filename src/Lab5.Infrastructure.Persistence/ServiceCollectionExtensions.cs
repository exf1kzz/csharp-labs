using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection collection)
    {
        collection.AddScoped<IPersistenceContext, PersistenceContext>();

        collection.AddSingleton<IAccountRepository, AccountRepository>();
        collection.AddSingleton<ISessionRepository, SessionRepository>();

        return collection;
    }
}