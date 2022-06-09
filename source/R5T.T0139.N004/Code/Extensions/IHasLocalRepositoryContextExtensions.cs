using System;
using System.Threading.Tasks;

using R5T.T0139.N004;


namespace System
{
    public static partial class IHasLocalRepositoryContextExtensions
    {
        public static async Task CreateAndClone(this IHasLocalRepositoryContext hasContext,
            string repositoryDescription,
            bool isPrivate)
        {
            var context = hasContext.LocalRepositoryContext_N004;

            // Create.
            await context.CreateRemoteRepository(
                repositoryDescription,
                isPrivate);

            // Clone locally.
            await hasContext.Clone();
        }

        public static async Task Clone(this IHasLocalRepositoryContext hasContext)
        {
            var context = hasContext.LocalRepositoryContext_N004;

            var cloneUrl = await context.GetCloneUrl();

            await context.Clone(cloneUrl);
        }

        public static Task DeleteBothLocalAndRemote(this IHasLocalRepositoryContext hasContext)
        {
            var context = hasContext.LocalRepositoryContext_N004;

            context.DeleteLocalRepositoryDirectory();

            return context.DeleteRemoteRepository();
        }

        public static Task Modify(this IHasLocalRepositoryContext hasContext,
            Func<ILocalRepositoryContext, Task> localRepositoryContextAction)
        {
            return localRepositoryContextAction(hasContext.LocalRepositoryContext_N004);
        }

        public static async Task VerifyDoesNotExist(this IHasLocalRepositoryContext hasContext)
        {
            var context = hasContext.LocalRepositoryContext_N004;

            await context.VerifyRemoteRepositoryDoesNotExist();
            await context.VerifyLocalRepositoryDoesNotExist();
        }

        public static async Task VerifyExists(this IHasLocalRepositoryContext hasContext)
        {
            var context = hasContext.LocalRepositoryContext_N004;

            await context.VerifyRemoteRepositoryExists();
            await context.VerifyLocalRepositoryExists();
        }
    }
}
