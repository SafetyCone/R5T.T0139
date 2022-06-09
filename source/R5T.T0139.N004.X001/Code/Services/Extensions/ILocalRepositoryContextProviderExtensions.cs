using System;
using System.Threading.Tasks;

using R5T.T0139.N004;

using N002 = R5T.T0139.N002;
using N003 = R5T.T0139.N003;

using Instances = R5T.T0139.N004.X001.Instances;


namespace System
{
    public static partial class ILocalRepositoryContextProviderExtensions
    {
        public static Task For_ByRepositoriesDirectoryPath(this ILocalRepositoryContextProvider localRepositoryContextProvider,
            string repositoryName,
            string repositoriesDirectoryPath,
            Func<ILocalRepositoryContext, Task> localRepositoryModifierAction)
        {
            var repositoryDirectoryPath = localRepositoryContextProvider.GetRepositoryDirectoryPath(
                repositoryName,
                repositoriesDirectoryPath);

            return localRepositoryContextProvider.For(
                repositoryName,
                repositoryDirectoryPath,
                localRepositoryModifierAction);
        }

        public static string GetRepositoryDirectoryPath(this ILocalRepositoryContextProvider _,
            string repositoryName,
            string repositoriesDirectoryPath)
        {
            var repositoryDirectoryName = Instances.RepositoryNameOperator.GetRepositoryDirectoryName(repositoryName);

            var repositoryDirectoryPath = Instances.PathOperator.GetDirectoryPath(
                repositoriesDirectoryPath,
                repositoryDirectoryName);

            return repositoryDirectoryPath;
        }

        //public static async Task For(this ILocalRepositoryContextProvider localRepositoryContextProvider,
        //    string repositoryName,
        //    Func<ILocalRepositoryContext, Task> localRepositoryModifierAction)
        //{
        //    // Get the directory path.
        //    var repositoryDirectoryPath = await localRepositoryContextProvider.GetRepositoryDirectoryPath(repositoryName);

        //    await localRepositoryContextProvider.For(
        //        repositoryName,
        //        repositoryDirectoryPath,
        //        localRepositoryModifierAction);
        //}

        //public static async Task<string> GetRepositoryDirectoryPath(this ILocalRepositoryContextProvider localRepositoryContextProvider,
        //    string repositoryName)
        //{
        //    var repositoriesDirectoryPath = await localRepositoryContextProvider.RepositoriesDirectoryPathProvider.GetRepositoriesDirectoryPath();

        //    var repositoryDirectoryName = Instances.RepositoryNameOperator.GetRepositoryDirectoryName(repositoryName);

        //    var repositoryDirectoryPath = Instances.PathOperator.GetDirectoryPath(
        //        repositoriesDirectoryPath,
        //        repositoryDirectoryName);

        //    return repositoryDirectoryPath;
        //}

        //public static async Task In(this ILocalRepositoryContextProvider localRepositoryContextProvider,
        //    string repositoryName,
        //    Func<ILocalRepositoryContext, Task> localRepositoryModifierAction)
        //{
        //    var directoryPath = await localRepositoryContextProvider.GetRepositoryDirectoryPath(repositoryName);

        //    await localRepositoryContextProvider.In(
        //        repositoryName,
        //        directoryPath,
        //        localRepositoryModifierAction);
        //}

        //public static async Task InCreatedThenCloned(this ILocalRepositoryContextProvider localRepositoryContextProvider,
        //    string repositoryName,
        //    string description,
        //    bool isPrivate,
        //    Func<ILocalRepositoryContext, Task> localRepositoryModifierAction)
        //{
        //    var directoryPath = await localRepositoryContextProvider.GetRepositoryDirectoryPath(repositoryName);

        //    await localRepositoryContextProvider.InCreatedThenCloned(
        //        repositoryName,
        //        description,
        //        isPrivate,
        //        directoryPath,
        //        localRepositoryModifierAction);
        //}
    }
}
