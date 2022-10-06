using System;

using R5T.T0137;


namespace R5T.T0139.N004
{
    [ContextDefinitionMarker]
    public interface ILocalRepositoryContext : IHasLocalRepositoryContext,
        N003.IHasLocalRepositoryContext,
        N002.IHasRemoteRepositoryContext
    {
    }
}
