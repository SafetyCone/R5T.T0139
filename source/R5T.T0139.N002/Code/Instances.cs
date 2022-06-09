using System;

using R5T.D0082.T001;


namespace R5T.T0139.N002
{
    public static class Instances
    {
        public static IGitHubOperator GitHubOperator { get; } = N002.GitHubOperator.Instance;
        public static IRemoteRepositoryFunctionality RemoteRepositoryFunctionality { get; } = N002.RemoteRepositoryFunctionality.Instance;
        public static IGitHubRepositorySpecificationGenerator GitHubRepositorySpecificationGenerator { get; }
    }
}
