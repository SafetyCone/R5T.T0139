using System;

using R5T.Lombardy;

using R5T.D0079;
using R5T.D0083;
using R5T.T0062;
using R5T.T0063;


namespace R5T.T0139.N006
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ProjectContextProvider"/> implementation of <see cref="IProjectContextProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IProjectContextProvider> AddProjectContextProviderAction(this IServiceAction _,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<IVisualStudioProjectFileOperator> visualStudioProjectFileOperatorAction,
            IServiceAction<IVisualStudioProjectFileReferencesProvider> VisualStudioProjectFileReferencesProviderAction)
        {
            var serviceAction = _.New<IProjectContextProvider>(services => services.AddProjectContextProvider(
                stringlyTypedPathOperatorAction,
                visualStudioProjectFileOperatorAction,
                VisualStudioProjectFileReferencesProviderAction));

            return serviceAction;
        }
    }
}
