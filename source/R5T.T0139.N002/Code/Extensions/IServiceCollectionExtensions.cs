using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.D0082;
using R5T.T0063;


namespace R5T.T0139.N002
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="RemoteRepositoryContextProvider"/> implementation of <see cref="IRemoteRepositoryContextProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddRemoteRepositoryContextProvider(this IServiceCollection services,
            IServiceAction<D0082.IGitHubOperator> gitHubOperatorAction)
        {
            services
                .Run(gitHubOperatorAction)
                .AddSingleton<IRemoteRepositoryContextProvider, RemoteRepositoryContextProvider>();

            return services;
        }
    }
}
