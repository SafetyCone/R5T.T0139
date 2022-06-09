using System;

using R5T.T0139.N008;

using Instances = R5T.T0139.N008.X001.Instances;


namespace System
{
    public static partial class IHasDirectoryPathExtensions
    {
        public static bool DirectoryExists(this IHasDirectoryPath hasDirectoryPath)
        {
            var output = Instances.FileSystemOperator.DirectoryExists(hasDirectoryPath.DirectoryPath);
            return output;
        }
    }
}
