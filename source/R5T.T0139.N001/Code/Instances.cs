using System;

using R5T.B0002;
using R5T.F0016;
using R5T.T0044;


namespace R5T.T0139.N001
{
    public static class Instances
    {
        public static IFileSystemOperator FileSystemOperator { get; } = T0044.FileSystemOperator.Instance;
        public static INamespaceName NamespaceName { get; } = B0002.NamespaceName.Instance;
        public static IProjectReferencesOperator ProjectReferencesOperator { get; } = F0016.ProjectReferencesOperator.Instance;
    }
}
