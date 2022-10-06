using System;

using R5T.Lombardy;

using R5T.D0078;
using R5T.D0083;
using R5T.T0137;
using R5T.T0139.N008;


namespace R5T.T0139.N005
{
    [ContextDefinitionMarker]
    public interface ISolutionContext :
        IHasFilePath,
        IHasSolutionContext
    {
        IStringlyTypedPathOperator StringlyTypedPathOperator { get; }
        IVisualStudioProjectFileReferencesProvider VisualStudioProjectFileReferencesProvider { get; }
        IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; }

        string SolutionFilePath { get; set; }
    }
}
