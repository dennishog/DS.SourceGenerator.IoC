using DS.SourceGenerator.IoC.Attributes;
using DS.SourceGenerator.IoC.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DS.SourceGenerator.IoC.Generators.SyntaxRecievers
{
    internal class ClassDeclarationReciever : ISyntaxReceiver
    {
        public IList<ClassDeclarationSyntax> InjectAttributeClasses { get; } = new List<ClassDeclarationSyntax>();

        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is ClassDeclarationSyntax classDeclarationSyntax &&
                classDeclarationSyntax.HaveAttribute(nameof(InjectAttribute)))
            {
                InjectAttributeClasses.Add(classDeclarationSyntax);
            }
        }
    }
}
