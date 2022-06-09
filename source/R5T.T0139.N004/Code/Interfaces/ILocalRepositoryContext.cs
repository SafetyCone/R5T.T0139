using System;


namespace R5T.T0139.N004
{
    public interface ILocalRepositoryContext : IHasLocalRepositoryContext,
        N003.IHasLocalRepositoryContext,
        N002.IHasRemoteRepositoryContext
    {
    }
}
