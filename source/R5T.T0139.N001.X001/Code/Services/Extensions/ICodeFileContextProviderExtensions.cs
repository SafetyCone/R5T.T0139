using System;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0139.N001;

using Instances = R5T.T0139.N001.X001.Instances;


namespace System
{
    public static class ICodeFileContextProviderExtensions
    {
        public static Task<CodeFileContext> GetCodeFileContext(this ICodeFileContextProvider codeFileContextProvider,
            string codeFilePath)
        {
            // Look up the directory hierarchy to find parent project files.
            var projectFilePaths = Instances.ProjectPathsOperator.FindProjectFilesInFileDirectoryOrDirectParentDirectories(
                codeFilePath)
                .Now();

            // Now look up the directory hierarchy to find parent solution files.
            var solutionFilePaths = Instances.SolutionPathsOperator.FindSolutionFilesInFileDirectoryOrDirectParentDirectories(
                // Use code file path instead of project file path, for now. TODO
                codeFilePath)
                .Now();

            // And only the solution files that contain the project file.
            //codeFileContextProvider.SolutionFileOperator. TODO

            var output = codeFileContextProvider.GetCodeFileContext(
                codeFilePath,
                projectFilePaths,
                solutionFilePaths);

            return output;
        }
    }
}
