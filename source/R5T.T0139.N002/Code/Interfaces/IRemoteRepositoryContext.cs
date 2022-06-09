using System;

using R5T.D0082;
using R5T.T0137;


namespace R5T.T0139.N002
{
    [ContextDefinitionMarker]
    public interface IRemoteRepositoryContext : IContextDefinitionMarker,
        IHasRemoteRepositoryContext,
        IHasGitHubOperator
    {
        string Name { get; }
    }
}
