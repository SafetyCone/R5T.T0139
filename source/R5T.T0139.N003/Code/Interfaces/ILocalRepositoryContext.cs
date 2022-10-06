using System;

using R5T.D0037;
using R5T.T0137;
using R5T.T0139.N008;


namespace R5T.T0139.N003
{
    [ContextDefinitionMarker]
    public interface ILocalRepositoryContext :
        IHasDirectoryPath,
        IHasLocalRepositoryContext
    {
        IGitOperator GitOperator { get; }
    }
}
