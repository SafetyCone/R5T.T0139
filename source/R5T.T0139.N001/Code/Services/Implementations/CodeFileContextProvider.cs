using System;

using R5T.D0116;
using R5T.T0064;

using R5T.T0139.N001.D001;


namespace R5T.T0139.N001
{
    [ServiceImplementationMarker]
    public class CodeFileContextProvider : ICodeFileContextProvider, IServiceImplementation
    {
        public IProjectFileOperator ProjectFileOperator { get; }
        public ISolutionFileOperator SolutionFileOperator { get; }
        public IUsingDirectivesFormatter UsingDirectivesFormatter { get; }


        public CodeFileContextProvider(
            IProjectFileOperator projectFileOperator,
            ISolutionFileOperator solutionFileOperator,
            IUsingDirectivesFormatter usingDirectivesFormatter)
        {
            this.ProjectFileOperator = projectFileOperator;
            this.SolutionFileOperator = solutionFileOperator;
            this.UsingDirectivesFormatter = usingDirectivesFormatter;
        }
    }
}
