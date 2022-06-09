using System;

using R5T.D0082;
using R5T.T0064;


namespace R5T.T0139.N002
{
    [ServiceImplementationMarker]
    public class RemoteRepositoryContextProvider : IRemoteRepositoryContextProvider, IServiceImplementation
    {
        public D0082.IGitHubOperator GitHubOperator { get; }


        public RemoteRepositoryContextProvider(
            D0082.IGitHubOperator gitHubOperator)
        {
            this.GitHubOperator = gitHubOperator;
        }
    }
}
