using System;

using R5T.Lombardy;

using R5T.D0079;
using R5T.D0083;
using R5T.T0137;
using R5T.T0139.N008;


namespace R5T.T0139.N006
{
    [ContextDefinitionMarker]
    public interface IProjectContext :
        IHasFilePath,
        IHasProjectContext
    {
        IStringlyTypedPathOperator StringlyTypedPathOperator { get; }
        IVisualStudioProjectFileOperator VisualStudioProjectFileOperator { get; }
        IVisualStudioProjectFileReferencesProvider VisualStudioProjectFileReferencesProvider { get; }

        string ProjectFilePath { get; }
    }
}
