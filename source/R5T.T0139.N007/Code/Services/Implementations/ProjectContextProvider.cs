using System;

using R5T.D0078;
using R5T.T0064;


namespace R5T.T0139.N007
{
    [ServiceImplementationMarker]
    public class ProjectContextProvider : IProjectContextProvider, IServiceImplementation
    {
        public N006.IProjectContextProvider ProjectContextProvider_N006 { get; }
        public IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; }


        public ProjectContextProvider(
            N006.IProjectContextProvider projectContextProvider_N006,
            IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator)
        {
            this.ProjectContextProvider_N006 = projectContextProvider_N006;
            this.VisualStudioSolutionFileOperator = visualStudioSolutionFileOperator;
        }
    }
}
