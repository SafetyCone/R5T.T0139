using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.T0139.N001.D001
{
    /// <summary>
    /// Project file operator for the <see cref="ICodeFileContext"/> context.
    /// </summary>
    [ServiceDefinitionMarker]
    public interface IProjectFileOperator : IServiceDefinition
    {
        /// <summary>
        /// Ensures that a project file has access to the provided project references.
        /// <inheritdoc cref="F0016.Glossary.ProjectReferencesAvailable"/>
        /// <inheritdoc cref="F0016.Glossary.RecursiveProjectReferencesSet"/>
        /// <inheritdoc cref="F0016.Glossary.InclusiveProjectReferencesSet"/>
        /// </summary>
        /// <param name="projectFilePath">The project file path to modify.</param>
        /// <param name="projectReferenceFilePaths">The project reference dependency file paths you want to be available to the project file.</param>
        /// <returns></returns>
        Task EnsureProjectReferencesAreAvailable(
            string projectFilePath,
            IEnumerable<string> projectReferenceFilePaths);
    }
}
