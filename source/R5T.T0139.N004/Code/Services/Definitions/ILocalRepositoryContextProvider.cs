using System;

using R5T.T0064;


namespace R5T.T0139.N004
{
    [ServiceDefinitionMarker]
    public interface ILocalRepositoryContextProvider : IServiceDefinition
    {
        N002.IRemoteRepositoryContextProvider RemoteRepositoryContextProvider_N002 { get; }
        N003.ILocalRepositoryContextProvider LocalRepositoryContextProvider_N003 { get; }
    }
}
