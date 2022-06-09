using System;
using System.IO;
using System.Threading.Tasks;

using R5T.D0082;
using R5T.T0132;


namespace R5T.T0139.N002
{
    [FunctionalityMarker]
    public interface IRemoteRepositoryFunctionality : IFunctionalityMarker
    {
        /// <summary>
        /// Non-idempotent.
        /// </summary>
        public async Task CreateRepository_NonIdempotent(
            IHasGitHubOperator hasGitHubOperator,
            string name,
            string description,
            bool isPrivate)
        {
            var repositorySpecification = Instances.GitHubRepositorySpecificationGenerator.GetSafetyConeDefault(
                name,
                description,
                isPrivate);

            // Ignore repository identifier returned.
            await hasGitHubOperator.GitHubOperator.CreateRepository_NonIdempotent(repositorySpecification);
        }

        public async Task ReportIfRepositoryExists(
            IHasGitHubOperator hasGitHubOperator,
            string repositoryName,
            Action<string, bool> reporter)
        {
            var exists = await hasGitHubOperator.GitHubOperator.RepositoryExists_SafetyCone(repositoryName);

            reporter(repositoryName, exists);
        }

        public async Task ReportIfRepositoryExists(
            IHasGitHubOperator hasGitHubOperator,
            string repositoryName,
            Func<string, bool, Task> reporter)
        {
            var exists = await hasGitHubOperator.GitHubOperator.RepositoryExists_SafetyCone(repositoryName);

            await reporter(repositoryName, exists);
        }

        public void ReportIfRepositoryExists(
            string repositoryName,
            bool exists,
            TextWriter output)
        {
            var message = $"Remote repository '{repositoryName}' exists: {exists}";

            output.WriteLine(message);
        }

        public void ReportIfRepositoryExists(
            string repositoryName,
            bool exists)
        {
            this.ReportIfRepositoryExists(
                repositoryName,
                exists,
                Console.Out);
        }

        public Task ReportIfRepositoryExists(
            IHasGitHubOperator hasGitHubOperator,
            string repositoryName)
        {
            return Instances.RemoteRepositoryFunctionality.ReportIfRepositoryExists(
                hasGitHubOperator,
                repositoryName,
                Instances.RemoteRepositoryFunctionality.ReportIfRepositoryExists);
        }

        public async Task VerifyRemoteRepositoryDoesNotExist(
            IHasGitHubOperator hasGitHubOperator,
            string repositoryName)
        {
            var exists = await hasGitHubOperator.GitHubOperator.RepositoryExists_SafetyCone(repositoryName);
            if (exists)
            {
                throw new Exception($"{repositoryName}: Remote repository already exists.");
            }
        }

        public async Task VerifyRemoteRepositoryExists(
            IHasGitHubOperator remoteRhasGitHubOperatorpositoryContextProvider,
            string repositoryName)
        {
            var exists = await remoteRhasGitHubOperatorpositoryContextProvider.GitHubOperator.RepositoryExists_SafetyCone(repositoryName);
            if (!exists)
            {
                throw new Exception($"{repositoryName}: Remote repository does not exist.");
            }
        }

        public Task VerifyRemoteRepositoryDoesNotExist(
            N002.IHasRemoteRepositoryContext hasContext)
        {
            var context = hasContext.RemoteRepositoryContext_N002;

            return this.VerifyRemoteRepositoryDoesNotExist(
                context.GitHubOperator,
                context.Name);
        }

        public Task VerifyRemoteRepositoryExists(
            N002.IHasRemoteRepositoryContext hasContext)
        {
            var context = hasContext.RemoteRepositoryContext_N002;

            return this.VerifyRemoteRepositoryExists(
                context.GitHubOperator,
                context.Name);
        }
    }
}
