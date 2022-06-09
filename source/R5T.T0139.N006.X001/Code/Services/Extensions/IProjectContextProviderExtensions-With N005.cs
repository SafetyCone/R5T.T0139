using System;
using System.Threading.Tasks;

using R5T.D0079;

using R5T.T0139.N006;

using N005 = R5T.T0139.N005;

using Instances = R5T.T0139.N006.Instances;


namespace System
{
    public static partial class IProjectContextProviderExtensions
    {
        public static Task For(this IProjectContextProvider projectContextProvider,
            string projectName,
            N005.ISolutionContext solutionContext,
            Func<IProjectContext, Task> projectModifierAction)
        {
            var projectFilePath = projectContextProvider.GetProjectFilePath(
                projectName,
                solutionContext);

            return projectContextProvider.For(
                projectFilePath,
                projectModifierAction);
        }

        public static string GetProjectFilePath(this IProjectContextProvider _,
            string projectName,
            N005.ISolutionContext solutionContext)
        {
            var solutionDirectoryPath = solutionContext.SolutionDirectoryPath();

            var projectDirectoryPath = Instances.ProjectPathsOperator.GetProjectDirectoryPath(
                solutionDirectoryPath,
                projectName);

            var projectFilePath = Instances.ProjectPathsOperator.GetProjectFilePath(
                projectDirectoryPath,
                projectName);

            return projectFilePath;
        }

        public static Task In(this IProjectContextProvider projectContextProvider,
            string projectName,
            N005.ISolutionContext solutionContext,
            Func<IProjectContext, Task> projectModifierAction)
        {
            var projectFilePath = projectContextProvider.GetProjectFilePath(
                projectName,
                solutionContext);

            return projectContextProvider.In(
                projectFilePath,
                projectModifierAction);
        }

        public static Task InAcquired(this IProjectContextProvider projectContextProvider,
            string projectName,
            N005.ISolutionContext solutionContext,
            VisualStudioProjectType projectType,
            Func<IProjectContext, Task> projectModifierAction)
        {
            var projectFilePath = projectContextProvider.GetProjectFilePath(
                projectName,
                solutionContext);

            return projectContextProvider.InAcquired(
                projectFilePath,
                projectType,
                projectModifierAction);
        }

        public static Task InCreated(this IProjectContextProvider projectContextProvider,
            string projectName,
            N005.ISolutionContext solutionContext,
            VisualStudioProjectType projectType,
            Func<IProjectContext, Task> projectModifierAction)
        {
            var projectFilePath = projectContextProvider.GetProjectFilePath(
                projectName,
                solutionContext);

            return projectContextProvider.InAcquired(
                projectFilePath,
                projectType,
                projectModifierAction);
        }
    }
}
