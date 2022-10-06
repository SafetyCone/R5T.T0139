using System;

using R5T.Lombardy;

using R5T.D0079;
using R5T.D0083;
using R5T.T0137;
using R5T.T0139.N008;


namespace R5T.T0139.N006
{
    [ContextImplementationMarker]
    public class ProjectContext : IProjectContext
    {
        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; set; }
        public IVisualStudioProjectFileOperator VisualStudioProjectFileOperator { get; set; }
        public IVisualStudioProjectFileReferencesProvider VisualStudioProjectFileReferencesProvider { get; set; }

        public string ProjectFilePath { get; set; }

        public IProjectContext ProjectContext_N006 => this;
        string IHasFilePath.FilePath => this.ProjectFilePath;
    }
}
