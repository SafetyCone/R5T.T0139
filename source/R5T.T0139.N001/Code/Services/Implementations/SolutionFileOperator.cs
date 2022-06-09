using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.Lombardy;

using R5T.D0078;
using R5T.T0064;


namespace R5T.T0139.N001.D001
{
    [ServiceImplementationMarker]
    public class SolutionFileOperator : ISolutionFileOperator, IServiceImplementation
    {
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }
        private IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; }


        public SolutionFileOperator(
            IStringlyTypedPathOperator stringlyTypedPathOperator,
            IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator)
        {
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
            this.VisualStudioSolutionFileOperator = visualStudioSolutionFileOperator;
        }

        public Task EnsureHasAllDependencyProjectReferences(
            string solutionFilePath,
            IEnumerable<string> dependencyProjectReferenceFilePaths)
        {
            return this.VisualStudioSolutionFileOperator.EnsureHasAllDependencyProjectReferences(
                solutionFilePath,
                dependencyProjectReferenceFilePaths,
                this.StringlyTypedPathOperator);
        }
    }
}
