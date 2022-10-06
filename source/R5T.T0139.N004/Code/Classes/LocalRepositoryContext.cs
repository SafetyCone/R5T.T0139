using System;

using R5T.T0137;


namespace R5T.T0139.N004
{
    [ContextImplementationMarker]
    public class LocalRepositoryContext : ILocalRepositoryContext
    {
        public N003.ILocalRepositoryContext LocalRepositoryContext_N003 { get; set; }
        public N002.IRemoteRepositoryContext RemoteRepositoryContext_N002 { get; set; }

        public ILocalRepositoryContext LocalRepositoryContext_N004 => this;
    }
}
