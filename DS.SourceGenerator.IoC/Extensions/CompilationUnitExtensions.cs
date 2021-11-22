using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace DS.SourceGenerator.IoC.Extensions
{
    public static class CompilationUnitExtensions
    {
        public static string GetNamespace(this CompilationUnitSyntax root)
        {
            return root.ChildNodes()
                .OfType<NamespaceDeclarationSyntax>()
                .FirstOrDefault()
                .Name
                .ToString();
        }
    }
}
