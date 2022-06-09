using System;

using R5T.Lombardy;

using R5T.D0078;
using R5T.D0079;
using R5T.D0083;
using R5T.D0116;
using R5T.T0062;
using R5T.T0063;


namespace R5T.T0139.N001
{
    using R5T.T0139.N001.D001;


    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="CodeFileContextProvider"/> implementation of <see cref="ICodeFileContextProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ICodeFileContextProvider> AddCodeFileContextProviderAction(this IServiceAction _,
            IServiceAction<IProjectFileOperator> projectFileOperatorAction,
            IServiceAction<ISolutionFileOperator> solutionFileOperatorAction,
            IServiceAction<IUsingDirectivesFormatter> usingDirectivesFormatterAction)
        {
            var serviceAction = _.New<ICodeFileContextProvider>(services => services.AddCodeFileContextProvider(
                projectFileOperatorAction,
                solutionFileOperatorAction,
                usingDirectivesFormatterAction));

            return serviceAction;
        }
    }
}


namespace R5T.T0139.N001.D001
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="SolutionFileOperator"/> implementation of <see cref="ISolutionFileOperator"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ISolutionFileOperator> AddSolutionFileOperatorAction(this IServiceAction _,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<IVisualStudioSolutionFileOperator> visualStudioSolutionFileOperatorAction)
        {
            var serviceAction = _.New<ISolutionFileOperator>(services => services.AddSolutionFileOperator(
                stringlyTypedPathOperatorAction,
                visualStudioSolutionFileOperatorAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ProjectFileOperator"/> implementation of <see cref="IProjectFileOperator"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IProjectFileOperator> AddProjectFileOperatorAction(this IServiceAction _,
            IServiceAction<IVisualStudioProjectFileOperator> visualStudioProjectFileOperatorAction,
            IServiceAction<IVisualStudioProjectFileReferencesProvider> visualStudioProjectFileReferencesProviderAction)
        {
            var serviceAction = _.New<IProjectFileOperator>(services => services.AddProjectFileOperator(
                visualStudioProjectFileOperatorAction,
                visualStudioProjectFileReferencesProviderAction));

            return serviceAction;
        }
    }
}
