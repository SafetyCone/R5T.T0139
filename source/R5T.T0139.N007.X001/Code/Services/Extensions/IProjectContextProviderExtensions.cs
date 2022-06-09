using System;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0139.N007;

using Instances = R5T.T0139.N007.X001.Instances;


namespace System
{
    public static partial class IProjectContextProviderExtensions
    {
        public static Task In(this IProjectContextProvider projectContextProvider,
            string projectFilePath,
            Func<IProjectContext, Task> projectModifierAction)
        {
            var solutionFilePaths = Instances.SolutionPathsOperator.FindSolutionFilesInFileDirectoryOrDirectParentDirectories(
                projectFilePath)
                .Now();

            return projectContextProvider.For(
                projectFilePath,
                solutionFilePaths,
                projectModifierAction);
        }
    }
}