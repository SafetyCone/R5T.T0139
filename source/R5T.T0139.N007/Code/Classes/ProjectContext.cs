using System;

using R5T.D0078;
using R5T.T0137;


namespace R5T.T0139.N007
{
    [ContextImplementationMarker]
    public class ProjectContext : IProjectContext
    {
        public N006.IProjectContext ProjectContext_N006 { get; set; }

        public IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; set; }

        public string[] SolutionFilePaths { get; set; }

        public IProjectContext ProjectContext_N007 => this;
    }
}
