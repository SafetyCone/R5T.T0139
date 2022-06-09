using System;

using R5T.D0078;
using R5T.T0062;
using R5T.T0063;


namespace R5T.T0139.N007
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ProjectContextProvider"/> implementation of <see cref="IProjectContextProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IProjectContextProvider> AddProjectContextProviderAction(this IServiceAction _,
            IServiceAction<N006.IProjectContextProvider> projectContextProvider_N006Action,
            IServiceAction<IVisualStudioSolutionFileOperator> visualStudioSolutionFileOperatorAction)
        {
            var serviceAction = _.New<IProjectContextProvider>(services => services.AddProjectContextProvider(
                projectContextProvider_N006Action,
                visualStudioSolutionFileOperatorAction));

            return serviceAction;
        }
    }
}