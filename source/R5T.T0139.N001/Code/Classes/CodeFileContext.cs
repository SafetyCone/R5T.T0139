using System;

using R5T.D0116;
using R5T.T0137;

using R5T.T0139.N001.D001;
using R5T.T0139.N008;

namespace R5T.T0139.N001
{
    [ContextImplementationMarker]
    public class CodeFileContext : ICodeFileContext, IContextImplementationMarker
    {
        public IProjectFileOperator ProjectFileOperator { get; set; }
        public ISolutionFileOperator SolutionFileOperator { get; set; }
        public IUsingDirectivesFormatter UsingDirectivesFormatter { get; set; }

        public string CodeFilePath { get; set; }
        public string[] ProjectFilePaths { get; set; }
        public string[] SolutionFilePaths { get; set; }

        ICodeFileContext IHasCodeFileContext.CodeFileContext => this;
        string IHasFilePath.FilePath => this.CodeFilePath;
    }
}
