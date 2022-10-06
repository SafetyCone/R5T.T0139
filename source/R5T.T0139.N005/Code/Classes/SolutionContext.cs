using System;

using R5T.Lombardy;

using R5T.D0078;
using R5T.D0083;
using R5T.T0137;
using R5T.T0139.N008;


namespace R5T.T0139.N005
{
    [ContextImplementationMarker]
    public class SolutionContext : ISolutionContext
    {
        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; set; }
        public IVisualStudioProjectFileReferencesProvider VisualStudioProjectFileReferencesProvider { get; set; }
        public IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; set; }

        public string SolutionFilePath { get; set; }

        ISolutionContext IHasSolutionContext.SolutionContext => this;
        string IHasFilePath.FilePath => this.SolutionFilePath;
    }
}
