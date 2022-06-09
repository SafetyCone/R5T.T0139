using System;
using System.Threading.Tasks;

using R5T.T0139.N001;


namespace System
{
    public static class ICodeFileContextProviderExtensions
    {
        public static Task<CodeFileContext> GetCodeFileContext(this ICodeFileContextProvider codeFileContextProvider,
            string codeFilePath,
            string[] projectFilePaths,
            string[] solutionFilePaths)
        {
            var output = new CodeFileContext
            {
                ProjectFileOperator = codeFileContextProvider.ProjectFileOperator,
                SolutionFileOperator = codeFileContextProvider.SolutionFileOperator,
                UsingDirectivesFormatter = codeFileContextProvider.UsingDirectivesFormatter,

                CodeFilePath = codeFilePath,
                ProjectFilePaths = projectFilePaths,
                SolutionFilePaths = solutionFilePaths,
            };

            return Task.FromResult(output);
        }

        /// <summary>
        /// Create a code file context without searching for project and solution files.
        /// </summary>
        public static Task<CodeFileContext> GetCodeFileContext_WithoutProjectAndSolutionSearch(this ICodeFileContextProvider codeFileContextProvider,
            string codeFilePath)
        {
            var output = codeFileContextProvider.GetCodeFileContext(
                codeFilePath,
                Array.Empty<string>(),
                Array.Empty<string>());

            return output;
        }
    }
}
