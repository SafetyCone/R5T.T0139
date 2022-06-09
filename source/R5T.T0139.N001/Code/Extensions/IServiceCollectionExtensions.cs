using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Lombardy;

using R5T.D0078;
using R5T.D0079;
using R5T.D0083;
using R5T.D0116;
using R5T.T0063;


namespace R5T.T0139.N001
{
    using R5T.T0139.N001.D001;


    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="CodeFileContextProvider"/> implementation of <see cref="ICodeFileContextProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddCodeFileContextProvider(this IServiceCollection services,
            IServiceAction<IProjectFileOperator> projectFileOperatorAction,
            IServiceAction<ISolutionFileOperator> solutionFileOperatorAction,
            IServiceAction<IUsingDirectivesFormatter> usingDirectivesFormatterAction)
        {
            services
                .Run(projectFileOperatorAction)
                .Run(solutionFileOperatorAction)
                .Run(usingDirectivesFormatterAction)
                .AddSingleton<ICodeFileContextProvider, CodeFileContextProvider>();

            return services;
        }
    }
}

namespace R5T.T0139.N001.D001
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="SolutionFileOperator"/> implementation of <see cref="ISolutionFileOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddSolutionFileOperator(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<IVisualStudioSolutionFileOperator> visualStudioSolutionFileOperatorAction)
        {
            services
                .Run(stringlyTypedPathOperatorAction)
                .Run(visualStudioSolutionFileOperatorAction)
                .AddSingleton<ISolutionFileOperator, SolutionFileOperator>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ProjectFileOperator"/> implementation of <see cref="IProjectFileOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddProjectFileOperator(this IServiceCollection services,
            IServiceAction<IVisualStudioProjectFileOperator> visualStudioProjectFileOperatorAction,
            IServiceAction<IVisualStudioProjectFileReferencesProvider> visualStudioProjectFileReferencesProviderAction)
        {
            services
                .Run(visualStudioProjectFileOperatorAction)
                .Run(visualStudioProjectFileReferencesProviderAction)
                .AddSingleton<IProjectFileOperator, ProjectFileOperator>();

            return services;
        }   
    }
}
