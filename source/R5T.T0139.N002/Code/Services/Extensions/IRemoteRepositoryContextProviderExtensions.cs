using System;
using System.Threading.Tasks;

using R5T.T0139.N002;


namespace System
{
    public static class IRemoteRepositoryContextProviderExtensions
    {
        public static RemoteRepositoryContext GetContext(this IRemoteRepositoryContextProvider remoteRepositoryContextProvider,
            string repositoryName)
        {
            var output = new RemoteRepositoryContext
            {
                GitHubOperator = remoteRepositoryContextProvider.GitHubOperator,
                Name = repositoryName,
            };

            return output;
        }

        public static async Task For(this IRemoteRepositoryContextProvider remoteRepositoryContextProvider,
            string repositoryName,
            Func<IRemoteRepositoryContext, Task> remoteRepositoryModifierAction)
        {
            // Create context.
            var context = remoteRepositoryContextProvider.GetContext(
                repositoryName);

            // Run modifier.
            await context.Modify(remoteRepositoryModifierAction);
        }

        public static async Task In(this IRemoteRepositoryContextProvider remoteRepositoryContextProvider,
            string repositoryName,
            Func<IRemoteRepositoryContext, Task> remoteRepositoryModifierAction)
        {
            // If not exists, In() errors.
            await remoteRepositoryContextProvider.VerifyRemoteRepositoryExists(repositoryName);

            await remoteRepositoryContextProvider.For(
                repositoryName,
                remoteRepositoryModifierAction);
        }

        ///// <summary>
        ///// Although InAcquired() is less useful here (caller has to specify visibility and description for a repository that may already exist)
        ///// Note: values are not checked, and then we would have to check those values, or communicate that they are ignored.
        ///// </summary>
        ///// <param name="remoteRepositoryContextProvider"></param>
        ///// <param name="repositoryName"></param>
        ///// <param name="description"></param>
        ///// <param name="isPrivate"></param>
        ///// <param name="remoteRepositoryModifierAction"></param>
        ///// <returns></returns>
        //public static async Task InAcquired(this IRemoteRepositoryContextProvider remoteRepositoryContextProvider,
        //    string repositoryName,
        //    string description,
        //    bool isPrivate,
        //    Func<IRemoteRepositoryContext, Task> remoteRepositoryModifierAction)
        //{

        //}

        // No InAcquired(), since the caller would have to specify visibility and description for a repository that may already exist, values are not checked, and then we would have to check those values, or communicate that they are ignored.
        // Best to just make the caller know whether the repository has been created, or not, or use For().

        public static async Task InCreated(this IRemoteRepositoryContextProvider remoteRepositoryContextProvider,
            string repositoryName,
            string description,
            bool isPrivate,
            Func<IRemoteRepositoryContext, Task> remoteRepositoryModifierAction)
        {
            // If exists already, InCreated() errors.
            await remoteRepositoryContextProvider.VerifyRemoteRepositoryDoesNotExist(repositoryName);

            // Create repository.
            var repositorySpecification = Instances.GitHubRepositorySpecificationGenerator.GetSafetyConeDefault(
                repositoryName,
                description,
                isPrivate);

            // Ignore repository identifier returned.
            await remoteRepositoryContextProvider.GitHubOperator.CreateRepository_NonIdempotent(repositorySpecification);

            await remoteRepositoryContextProvider.For(
                repositoryName,
                remoteRepositoryModifierAction);
        }

        public static Task VerifyRemoteRepositoryDoesNotExist(this IRemoteRepositoryContextProvider remoteRepositoryContextProvider,
            string repositoryName)
        {
            return Instances.GitHubOperator.VerifyRemoteRepositoryDoesNotExist(
                remoteRepositoryContextProvider,
                repositoryName);
        }

        public static Task VerifyRemoteRepositoryExists(this IRemoteRepositoryContextProvider remoteRepositoryContextProvider,
            string repositoryName)
        {
            return Instances.GitHubOperator.VerifyRemoteRepositoryExists(
                remoteRepositoryContextProvider,
                repositoryName);
        }
    }
}
