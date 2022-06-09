using System;

using R5T.F0019;
using R5T.T0040;
using R5T.T0044;


namespace R5T.T0139.N003
{
    public static class Instances
    {
        public static IFileSystemOperator FileSystemOperator { get; } = T0044.FileSystemOperator.Instance;
        public static IGitOperator GitOperator { get; } = F0019.GitOperator.Instance;
        public static ISolutionPathsOperator SolutionPathsOperator { get; } = T0040.SolutionPathsOperator.Instance;
    }
}
