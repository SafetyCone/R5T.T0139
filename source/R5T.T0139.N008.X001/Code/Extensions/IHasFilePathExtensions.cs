using System;

using R5T.T0139.N008;

using Instances = R5T.T0139.N008.X001.Instances;


namespace System
{
    public static partial class IHasFilePathExtensions
    {
        public static bool DirectoryExists(this IHasFilePath hasFilePath)
        {
            var directoryPath = hasFilePath.GetDirectoryPath();

            var output = Instances.FileSystemOperator.DirectoryExists(directoryPath);
            return output;
        }

        public static bool FileExists(this IHasFilePath hasFilePath)
        {
            var output = Instances.FileSystemOperator.FileExists(hasFilePath.FilePath);
            return output;
        }

        public static string GetDirectoryPath(this IHasFilePath hasFilePath)
        {
            var directoryPath = Instances.PathOperator.GetDirectoryPathOfFilePath(hasFilePath.FilePath);
            return directoryPath;
        }
    }
}