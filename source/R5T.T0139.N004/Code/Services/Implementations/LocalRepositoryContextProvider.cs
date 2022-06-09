using System;

using R5T.T0064;


namespace R5T.T0139.N004
{
    [ServiceImplementationMarker]
    public class LocalRepositoryContextProvider : ILocalRepositoryContextProvider, IServiceImplementation
    {
        public N003.ILocalRepositoryContextProvider LocalRepositoryContextProvider_N003 { get; }
        public N002.IRemoteRepositoryContextProvider RemoteRepositoryContextProvider_N002 { get; }


        public LocalRepositoryContextProvider(
            N003.ILocalRepositoryContextProvider localRepositoryContextProvider,
            N002.IRemoteRepositoryContextProvider remoteRepositoryContextProvider)
        {
            this.LocalRepositoryContextProvider_N003 = localRepositoryContextProvider;
            this.RemoteRepositoryContextProvider_N002 = remoteRepositoryContextProvider;
        }
    }
}
