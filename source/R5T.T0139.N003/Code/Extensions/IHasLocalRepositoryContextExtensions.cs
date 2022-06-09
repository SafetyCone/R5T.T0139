using System;
using System.Threading.Tasks;

using R5T.T0139.N003;

using Instances = R5T.T0139.N003.Instances;


namespace System
{
    public static partial class IHasLocalRepositoryContextExtensions
    {
        public static async Task Clone(this IHasLocalRepositoryContext hasContext,
            string cloneUrl)
        {
            var context = hasContext.LocalRepositoryContext_N003;

            await context.GitOperator.Clone(
                cloneUrl,
                context.DirectoryPath);
        }

        public static void DeleteLocalRepositoryDirectory(this IHasLocalRepositoryContext hasContext)
        {
            Instances.FileSystemOperator.DeleteDirectory(hasContext.LocalRepositoryContext_N003.DirectoryPath);
        }

        public static string GetSourceSolutionFilePath(this IHasLocalRepositoryContext hasContext,
            string solutionName)
        {
            var context = hasContext.LocalRepositoryContext_N003;

            var repositoryDirectoryPath = context.RepositoryDirectoryPath();

            var solutionFilePath = Instances.SolutionPathsOperator.GetSourceSolutionFilePath(
                repositoryDirectoryPath,
                solutionName);

            return solutionFilePath;
        }

        public static Task Modify(this IHasLocalRepositoryContext hasContext,
            Func<ILocalRepositoryContext, Task> localRepositoryContextAction)
        {
            return localRepositoryContextAction(hasContext.LocalRepositoryContext_N003);
        }

        public static string RepositoryDirectoryPath(this IHasLocalRepositoryContext hasContext)
        {
            var output = hasContext.LocalRepositoryContext_N003.DirectoryPath;
            return output;
        }

        public static Task VerifyLocalRepositoryDoesNotExist(this IHasLocalRepositoryContext hasContext)
        {
            var context = hasContext.LocalRepositoryContext_N003;

            var exists = Instances.FileSystemOperator.DirectoryExists(context.DirectoryPath);
            if (exists)
            {
                throw new Exception($"Local repository already exists:\n{context.DirectoryPath}");
            }

            return Task.CompletedTask;
        }

        public static Task VerifyLocalRepositoryExists(this IHasLocalRepositoryContext hasContext)
        {
            var context = hasContext.LocalRepositoryContext_N003;

            var exists = Instances.FileSystemOperator.DirectoryExists(context.DirectoryPath);
            if (!exists)
            {
                throw new Exception($"Local repository does not exist:\n{context.DirectoryPath}");
            }

            return Task.CompletedTask;
        }
    }
}
