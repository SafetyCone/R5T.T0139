using System;

using R5T.Lombardy;

using R5T.D0078;
using R5T.D0083;
using R5T.T0064;


namespace R5T.T0139.N005
{
    [ServiceDefinitionMarker]
    public interface ISolutionContextProvider : IServiceDefinition
    {
        IStringlyTypedPathOperator StringlyTypedPathOperator { get; }
        IVisualStudioProjectFileReferencesProvider VisualStudioProjectFileReferencesProvider { get; }
        IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; }
    }
}
