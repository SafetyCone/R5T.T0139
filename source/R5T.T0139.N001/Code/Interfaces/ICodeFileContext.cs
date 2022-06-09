using System;

using R5T.Lombardy;

using R5T.D0078;
using R5T.D0079;
using R5T.D0083;
using R5T.D0116;
using R5T.T0137;

using R5T.T0139.N008;

using R5T.T0139.N001.D001;


namespace R5T.T0139.N001
{
    [ContextDefinitionMarker]
    public interface ICodeFileContext : IContextDefinitionMarker,
        IHasCodeFileContext,
        IHasFilePath
    {
        public IProjectFileOperator ProjectFileOperator { get; }
        public ISolutionFileOperator SolutionFileOperator { get; }
        public IUsingDirectivesFormatter UsingDirectivesFormatter { get; }

        public string CodeFilePath { get; }
        public string[] ProjectFilePaths { get; }
        public string[] SolutionFilePaths { get; }
    }
}
