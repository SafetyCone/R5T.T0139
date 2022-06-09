using System;

using R5T.Lombardy;

using R5T.D0079;
using R5T.D0083;
using R5T.T0064;


namespace R5T.T0139.N006
{
    [ServiceDefinitionMarker]
    public interface IProjectContextProvider : IServiceDefinition
    {
        IStringlyTypedPathOperator StringlyTypedPathOperator { get; }
        IVisualStudioProjectFileOperator VisualStudioProjectFileOperator { get; }
        IVisualStudioProjectFileReferencesProvider VisualStudioProjectFileReferencesProvider { get; }
    }
}
