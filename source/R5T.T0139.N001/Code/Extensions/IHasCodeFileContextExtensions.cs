using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0133;

using R5T.T0139.N001;

using Instances = R5T.T0139.N001.Instances;


namespace System
{
    public static class IHasCodeFileContextExtensions
    {
        public static Task WriteCompilation(this IHasCodeFileContext hasContext,
            CompilationRequirements<NamespaceDeclarationSyntax> compilationRequirements)
        {
            var compilationUnit = SyntaxFactory.CompilationUnit()
                .AddMembers(compilationRequirements.Node);

            return hasContext.WriteCompilation(
                CompilationRequirements.From(
                    compilationUnit,
                    compilationRequirements.NamespaceNames,
                    compilationRequirements.NameAliases,
                    compilationRequirements.ProjectReferenceFilePaths));
        }

        public static async Task WriteCompilation(this IHasCodeFileContext hasContext,
            CompilationRequirements<CompilationUnitSyntax> compilationRequirements,
            string compilationUnitLocalNamespaceName)
        {
            var context = hasContext.CodeFileContext;
            var compilationUnit = compilationRequirements.Node;

            // Add the compilation requirements's using namespace declarations to the compilation.
            compilationUnit = compilationUnit.AddUsings(
                compilationRequirements.NamespaceNames);

            compilationUnit = compilationUnit.AddUsings(
                compilationRequirements.NameAliases);

            // The format (block and order) the compilation's using declarations.
            compilationUnit = await context.UsingDirectivesFormatter.FormatUsingDirectives(
                compilationUnit,
                compilationUnitLocalNamespaceName);

            // Now actually write the compilation.
            // Check that the directory exists.
            Instances.FileSystemOperator.EnsureDirectoryForFileExists(context.CodeFilePath);

            // Then write the file.
            await compilationUnit.WriteToFile(context.CodeFilePath);

            // Add the compilation requirements's project references to the code file context's projects.
            // Get all recursive project references of the project.
            // For each compilation requirement project reference, check if it's already in the recursive references of the project.
            // If not, add the project reference.
            foreach (var projectFilePath in context.ProjectFilePaths)
            {
                await context.ProjectFileOperator.EnsureProjectReferencesAreAvailable(
                    projectFilePath,
                    compilationRequirements.ProjectReferenceFilePaths);
            }

            // Run Olympia functionality to add all recursive project reference dependencies to the code file context's solutions.
            foreach (var solutionFilePath in context.SolutionFilePaths)
            {
                await context.SolutionFileOperator.EnsureHasAllDependencyProjectReferences(
                    solutionFilePath,
                    compilationRequirements.ProjectReferenceFilePaths);
            }
        }

        /// <summary>
        /// Uses the <see cref="R5T.B0002.X001.NamespaceNames.NoNamespacesNamespaceName"/> value for the compilation unit local namespace name.
        /// </summary>
        public static Task WriteCompilation(this IHasCodeFileContext hasContext,
            CompilationRequirements<CompilationUnitSyntax> compilationRequirements)
        {
            return hasContext.WriteCompilation(
                compilationRequirements,
                Instances.NamespaceName.NoNamespacesNamespaceName());
        }

        public static async Task WriteNode<TNode>(this IHasCodeFileContext hasContext,
            CompilationRequirements<TNode> compilationRequirements)
            where TNode : SyntaxNode
        {
            await compilationRequirements.Node.WriteToFile(
                hasContext.CodeFileContext.CodeFilePath);
        }
    }
}
