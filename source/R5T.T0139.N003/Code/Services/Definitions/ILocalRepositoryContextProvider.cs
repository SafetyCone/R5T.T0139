using System;

using R5T.D0037;
using R5T.T0064;


namespace R5T.T0139.N003
{
    [ServiceDefinitionMarker]
    public interface ILocalRepositoryContextProvider : IServiceDefinition
    {
        IGitOperator GitOperator { get; }

        // FileSystemOperator service? For now using R5T.T0044.IFileSystemOperator base.
    }
}
