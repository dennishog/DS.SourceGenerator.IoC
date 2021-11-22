using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace DS.SourceGenerator.IoC.Extensions
{
    public static class ClassDeclarationExtensions
    {
        public static bool HaveAttribute(this ClassDeclarationSyntax classSyntax, string attributeName)
        {
            return classSyntax.AttributeLists.Count > 0 &&
                   classSyntax.AttributeLists.SelectMany(al => al.Attributes
                           .Where(a => (a.Name as IdentifierNameSyntax)!.Identifier.Text == attributeName.Replace("Attribute", string.Empty)))
                       .Any();
        }
    }
}
