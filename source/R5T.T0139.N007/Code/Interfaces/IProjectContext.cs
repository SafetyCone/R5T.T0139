using System;

using R5T.D0078;


namespace R5T.T0139.N007
{
    public interface IProjectContext : IHasProjectContext,
        N006.IHasProjectContext
    {
        IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; }

        string[] SolutionFilePaths { get; }
    }
}
