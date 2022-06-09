using System;
using System.Threading.Tasks;

using R5T.D0082.T000;

using R5T.T0139.N002;


namespace System
{
    public static class IHasRemoteRepositoryContextExtensions
    {
        public static async Task<bool> Exists(this IHasRemoteRepositoryContext hasContext)
        {
            var context = hasContext.RemoteRepositoryContext_N002;

            var output = await context.GitHubOperator.RepositoryExists_SafetyCone(
                context.Name);

            return output;
        }

        public static Task CreateRemoteRepository(this IHasRemoteRepositoryContext hasContext,
            string repositoryDescription,
            bool isPrivate)
        {
            var context = hasContext.RemoteRepositoryContext_N002;

            return Instances.RemoteRepositoryFunctionality.CreateRepository_NonIdempotent(
                context,
                context.Name,
                repositoryDescription,
                isPrivate);
        }

        public static Task DeleteRemoteRepository(this IHasRemoteRepositoryContext hasContext)
        {
            var context = hasContext.RemoteRepositoryContext_N002;

            return context.GitHubOperator.DeleteRepository_SafetyCone(context.Name);
        }

        public static async Task<string> GetCloneUrl(this IHasRemoteRepositoryContext hasContext)
        {
            var context = hasContext.RemoteRepositoryContext_N002;

            var output = await context.GitHubOperator.GetRepositoryCloneUrl_SafetyCone(
                context.Name);

            return output;
        }

        public static async Task<string> GetDescription(this IHasRemoteRepositoryContext hasContext)
        {
            var context = hasContext.RemoteRepositoryContext_N002;

            var output = await context.GitHubOperator.GetDescription_SafetyCone(
                context.Name);

            return output;
        }

        public static Task InGitHubRepository(this IHasRemoteRepositoryContext hasContext,
            Func<IGitHubRepository, Task> gitHubRepositoryAction)
        {
            var context = hasContext.RemoteRepositoryContext_N002;

            return context.GitHubOperator.InGitHubRepository_SafetyCone(
                context.Name,
                gitHubRepositoryAction);
        }

        public static async Task<bool> IsPrivate(this IHasRemoteRepositoryContext hasContext)
        {
            var context = hasContext.RemoteRepositoryContext_N002;

            var output = await context.GitHubOperator.IsPrivate_SafetyCone(
                context.Name);

            return output;
        }

        public static Task Modify(this IHasRemoteRepositoryContext context,
            Func<IRemoteRepositoryContext, Task> remoteRepositoryModifierAction)
        {
            return remoteRepositoryModifierAction(context.RemoteRepositoryContext_N002);
        }

        public static Task VerifyRemoteRepositoryDoesNotExist(this IHasRemoteRepositoryContext hasContext)
        {
            var context = hasContext.RemoteRepositoryContext_N002;

            return Instances.GitHubOperator.VerifyRemoteRepositoryDoesNotExist(
                context,
                context.Name);
        }

        public static Task VerifyRemoteRepositoryExists(this IHasRemoteRepositoryContext hasContext)
        {
            var context = hasContext.RemoteRepositoryContext_N002;

            return Instances.GitHubOperator.VerifyRemoteRepositoryExists(
                context,
                context.Name);
        }
    }
}
