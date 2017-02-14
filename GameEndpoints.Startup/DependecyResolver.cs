using GameEndpoints.Business.Services;
using GameEndpoints.Domain.Contracts.Repositories;
using GameEndpoints.Domain.Contracts.Services;
using GameEndpoints.Infrastructure.Data;
using GameEndpoints.Infrastructure.Repositories;
using Microsoft.Practices.Unity;

namespace GameEndpoints.Startup
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<AppDataContext, AppDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IGameResultRepository, GameResultRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IGameResultService, GameResultService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPlayerRepository, PlayerRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPlayerService, PlayerService>(new HierarchicalLifetimeManager());
        }
    }
}