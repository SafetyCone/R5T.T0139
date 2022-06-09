using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.D0078;
using R5T.T0063;


namespace R5T.T0139.N007
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ProjectContextProvider"/> implementation of <see cref="IProjectContextProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddProjectContextProvider(this IServiceCollection services,
            IServiceAction<N006.IProjectContextProvider> projectContextProvider_N006Action,
            IServiceAction<IVisualStudioSolutionFileOperator> visualStudioSolutionFileOperatorAction)
        {
            services
                .Run(projectContextProvider_N006Action)
                .Run(visualStudioSolutionFileOperatorAction)
                .AddSingleton<IProjectContextProvider, ProjectContextProvider>();

            return services;
        }
    }
}