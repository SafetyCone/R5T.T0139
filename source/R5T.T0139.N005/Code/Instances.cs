using System;

using R5T.T0041;
using R5T.T0044;
using R5T.T0113;


namespace R5T.T0139.N005
{
    public static class Instances
    {
        public static IFileSystemOperator FileSystemOperator { get; } = T0044.FileSystemOperator.Instance;
        public static IPathOperator PathOperator { get; } = T0041.PathOperator.Instance;
        public static ISolutionOperator SolutionOperator { get; } = T0113.SolutionOperator.Instance;
    }
}
