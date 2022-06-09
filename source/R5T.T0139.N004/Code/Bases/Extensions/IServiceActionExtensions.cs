using System;

using R5T.T0062;
using R5T.T0063;


namespace R5T.T0139.N004
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="LocalRepositoryContextProvider"/> implementation of <see cref="ILocalRepositoryContextProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ILocalRepositoryContextProvider> AddLocalRepositoryContextProviderAction(this IServiceAction _,
            IServiceAction<N003.ILocalRepositoryContextProvider> localRepositoryContextProviderAction,
            IServiceAction<N002.IRemoteRepositoryContextProvider> remoteRepositoryContextProviderAction)
        {
            var serviceAction = _.New<ILocalRepositoryContextProvider>(services => services.AddLocalRepositoryContextProvider(
                localRepositoryContextProviderAction,
                remoteRepositoryContextProviderAction));

            return serviceAction;
        }
    }
}
