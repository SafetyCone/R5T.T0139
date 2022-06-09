using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.D0079;
using R5T.D0083;
using R5T.T0064;


namespace R5T.T0139.N001.D001
{
    [ServiceImplementationMarker]
    public class ProjectFileOperator : IProjectFileOperator, IServiceImplementation
    {
        private IVisualStudioProjectFileOperator VisualStudioProjectFileOperator { get; }
        private IVisualStudioProjectFileReferencesProvider VisualStudioProjectFileReferencesProvider { get; }


        public ProjectFileOperator(
            IVisualStudioProjectFileOperator visualStudioProjectFileOperator,
            IVisualStudioProjectFileReferencesProvider visualStudioProjectFileReferencesProvider)
        {
            this.VisualStudioProjectFileOperator = visualStudioProjectFileOperator;
            this.VisualStudioProjectFileReferencesProvider = visualStudioProjectFileReferencesProvider;
        }

        public async Task EnsureProjectReferencesAreAvailable(
            string projectFilePath,
            IEnumerable<string> projectReferenceFilePaths)
        {
            var newProjectReferencesToAdd = await Instances.ProjectReferencesOperator.GetProjectReferencesToAdd(
                projectFilePath,
                projectReferenceFilePaths,
                this.VisualStudioProjectFileReferencesProvider.GetProjectReferencesForProject);

            await this.VisualStudioProjectFileOperator.AddProjectReferences(
                projectFilePath,
                newProjectReferencesToAdd);
        }
    }
}
