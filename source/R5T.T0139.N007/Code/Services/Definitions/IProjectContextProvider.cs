using System;

using R5T.D0078;
using R5T.T0064;


namespace R5T.T0139.N007
{
    [ServiceDefinitionMarker]
    public interface IProjectContextProvider : IServiceDefinition
    {
        N006.IProjectContextProvider ProjectContextProvider_N006 { get; }
        IVisualStudioSolutionFileOperator VisualStudioSolutionFileOperator { get; }
    }
}
