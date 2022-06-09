using System;
using System.Threading.Tasks;

using R5T.T0139.N004;

using N002 = R5T.T0139.N002;
using N003 = R5T.T0139.N003;


namespace System
{
    public static partial class ILocalRepositoryContextProviderExtensions
    {
        public static LocalRepositoryContext GetContext(this ILocalRepositoryContextProvider _,
            N003.ILocalRepositoryContext localRepositoryContext,
            N002.IRemoteRepositoryContext remoteRepositoryContext)
        {
            var output = new LocalRepositoryContext
            {
                LocalRepositoryContext_N003 = localRepositoryContext,
                RemoteRepositoryContext_N002 = remoteRepositoryContext,
            };

            return output;
        }

        public static Task For(this ILocalRepositoryContextProvider localRepositoryContextProvider,
            N003.ILocalRepositoryContext localRepositoryContext,
            N002.IRemoteRepositoryContext remoteRepositoryContext,
            Func<ILocalRepositoryContext, Task> localRepositoryModifierAction)
        {
            // Get context.
            var context = localRepositoryContextProvider.GetContext(
                localRepositoryContext,
                remoteRepositoryContext);

            // Run modifier.
            return context.Modify(localRepositoryModifierAction);
        }

        public static Task For(this ILocalRepositoryContextProvider localRepositoryContextProvider,
            string repositoryName,
            string localRepositoryDirectoryPath,
            Func<ILocalRepositoryContext, Task> localRepositoryModifierAction)
        {
            return localRepositoryContextProvider.RemoteRepositoryContextProvider_N002.For(
                repositoryName,
                remoteRepositoryContext =>
                {
                    return localRepositoryContextProvider.LocalRepositoryContextProvider_N003.For(
                        localRepositoryDirectoryPath,
                        localRepositoryContext =>
                        {
                            return localRepositoryContextProvider.For(
                                localRepositoryContext,
                                remoteRepositoryContext,
                                localRepositoryModifierAction);
                        });
                });
        }

        public static Task In(this ILocalRepositoryContextProvider localRepositoryContextProvider,
            string repositoryName,
            string directoryPath,
            Func<ILocalRepositoryContext, Task> localRepositoryModifierAction)
        {
            return localRepositoryContextProvider.RemoteRepositoryContextProvider_N002.In(
                repositoryName,
                remoteRepositoryContext =>
                {
                    return localRepositoryContextProvider.LocalRepositoryContextProvider_N003.In(
                        directoryPath,
                        localRepositoryContext =>
                        {
                            return localRepositoryContextProvider.For(
                                localRepositoryContext,
                                remoteRepositoryContext,
                                localRepositoryModifierAction);
                        });
                });
        }

        // No acquired. Repositories are too important to acquire (create if they don't exist, or use if they do).
        // Callers should know whether the repository exists.

        /// <summary>
        /// Creates the remote repository, then clones the repository locally.
        /// </summary>
        public static Task InCreatedThenCloned(this ILocalRepositoryContextProvider localRepositoryContextProvider,
            string repositoryName,
            string description,
            bool isPrivate,
            string directoryPath,
            Func<ILocalRepositoryContext, Task> localRepositoryModifierAction)
        {
            return localRepositoryContextProvider.RemoteRepositoryContextProvider_N002.InCreated(
                repositoryName,
                description,
                isPrivate,
                async remoteRepositoryContext =>
                {
                    var cloneUrl = await remoteRepositoryContext.RemoteRepositoryContext_N002.GetCloneUrl();

                    await localRepositoryContextProvider.LocalRepositoryContextProvider_N003.InCloned(
                        directoryPath,
                        cloneUrl,
                        localRepositoryContext =>
                        {
                            return localRepositoryContextProvider.For(
                                localRepositoryContext,
                                remoteRepositoryContext,
                                localRepositoryModifierAction);
                        });
                });
        }
    }
}
