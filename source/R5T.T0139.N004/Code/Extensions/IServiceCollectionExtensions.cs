using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0063;


namespace R5T.T0139.N004
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="LocalRepositoryContextProvider"/> implementation of <see cref="ILocalRepositoryContextProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddLocalRepositoryContextProvider(this IServiceCollection services,
            IServiceAction<N003.ILocalRepositoryContextProvider> localRepositoryContextProviderAction,
            IServiceAction<N002.IRemoteRepositoryContextProvider> remoteRepositoryContextProviderAction)
        {
            services
                .Run(localRepositoryContextProviderAction)
                .Run(remoteRepositoryContextProviderAction)
                .AddSingleton<ILocalRepositoryContextProvider, LocalRepositoryContextProvider>();

            return services;
        }
    }
}
