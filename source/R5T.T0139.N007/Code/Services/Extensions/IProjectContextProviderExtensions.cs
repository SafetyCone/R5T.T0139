using System;
using System.Threading.Tasks;

using R5T.T0139.N007;

using N006 = R5T.T0139.N006;


namespace System
{
    public static partial class IProjectContextProviderExtensions
    {
        public static async Task For(this IProjectContextProvider projectContextProvider,
            N006.IProjectContext projectContext_N006,
            string[] solutionFilePaths,
            Func<IProjectContext, Task> projectModifierAction)
        {
            // Get the context.
            var context = projectContextProvider.GetContext(
                projectContext_N006,
                solutionFilePaths);

            // Modify.
            await context.Modify(projectModifierAction);
        }

        public static Task For(this IProjectContextProvider projectContextProvider,
            string projectFilePath,
            string[] solutionFilePaths,
            Func<IProjectContext, Task> projectModifierAction)
        {
            return projectContextProvider.ProjectContextProvider_N006.For(
                projectFilePath,
                projectContext_N006 =>
                {
                    return projectContextProvider.For(
                        projectContext_N006,
                        solutionFilePaths,
                        projectModifierAction);    
                });
        }

        public static ProjectContext GetContext(this IProjectContextProvider projectContextProvider,
            N006.IProjectContext projectContext_N006,
            string[] solutionFilePaths)
        {
            var output = new ProjectContext
            {
                ProjectContext_N006 = projectContext_N006,

                VisualStudioSolutionFileOperator = projectContextProvider.VisualStudioSolutionFileOperator,

                SolutionFilePaths = solutionFilePaths,
            };

            return output;
        }

        public static Task In(this IProjectContextProvider projectContextProvider,
            string projectFilePath,
            string[] solutionFilePaths,
            Func<IProjectContext, Task> projectModifierAction)
        {
            return projectContextProvider.ProjectContextProvider_N006.In(
                projectFilePath,
                projectContext_N006 =>
                {
                    return projectContextProvider.For(
                        projectContext_N006,
                        solutionFilePaths,
                        projectModifierAction);
                });
        }
    }
}
