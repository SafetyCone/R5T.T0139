using System;
using System.IO;
using System.Threading.Tasks;

using R5T.D0082;
using R5T.T0132;


namespace R5T.T0139.N002
{
    [DraftFunctionalityMarker]
    public interface IGitHubOperator : IDraftFunctionalityMarker
    {
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
            IHasGitHubOperator hasGitHubOperator,
            string repositoryName)
        {
            var exists = await hasGitHubOperator.GitHubOperator.RepositoryExists_SafetyCone(repositoryName);
            if (!exists)
            {
                throw new Exception($"{repositoryName}: Remote repository does not exist.");
            }
        }
    }
}
