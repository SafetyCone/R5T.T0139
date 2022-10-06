using System;

using R5T.D0078;
using R5T.T0137;


namespace R5T.T0139.N007
{
    [ContextDefinitionMarker]
    public interface IProjectContext : IHasProjectContext,
        N006.IHasProjectContext
    {
        IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; }

        string[] SolutionFilePaths { get; }
    }
}
