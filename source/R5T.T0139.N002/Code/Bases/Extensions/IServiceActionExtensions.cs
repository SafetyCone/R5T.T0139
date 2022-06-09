﻿using System;

using R5T.D0082;
using R5T.T0062;
using R5T.T0063;


namespace R5T.T0139.N002
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="RemoteRepositoryContextProvider"/> implementation of <see cref="IRemoteRepositoryContextProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IRemoteRepositoryContextProvider> AddRemoteRepositoryContextProviderAction(this IServiceAction _,
            IServiceAction<D0082.IGitHubOperator> gitHubOperatorAction)
        {
            var serviceAction = _.New<IRemoteRepositoryContextProvider>(services => services.AddRemoteRepositoryContextProvider(
                gitHubOperatorAction));

            return serviceAction;
        }
    }
}
