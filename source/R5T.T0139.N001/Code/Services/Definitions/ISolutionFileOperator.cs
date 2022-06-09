using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.T0139.N001.D001
{
    /// <summary>
    /// Solution file operator for the <see cref="ICodeFileContext"/> context.
    /// </summary>
    [ServiceDefinitionMarker]
    public interface ISolutionFileOperator : IServiceDefinition
    {
        Task EnsureHasAllDependencyProjectReferences(
            string solutionFilePath,
            IEnumerable<string> dependencyProjectReferenceFilePaths);
    }
}
