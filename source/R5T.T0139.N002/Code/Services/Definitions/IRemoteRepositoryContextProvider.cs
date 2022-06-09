using System;

using R5T.D0082;
using R5T.T0064;


namespace R5T.T0139.N002
{
    [ServiceDefinitionMarker]
    public interface IRemoteRepositoryContextProvider : IServiceDefinition,
        IHasGitHubOperator
    {
    }
}
