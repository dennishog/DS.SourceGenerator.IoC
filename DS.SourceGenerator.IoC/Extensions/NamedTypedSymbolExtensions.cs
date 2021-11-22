using DS.SourceGenerator.IoC.Attributes;
using DS.SourceGenerator.IoC.Attributes.Enums;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DS.SourceGenerator.IoC.Extensions
{
    public static class NamedTypedSymbolExtensions
    {
        /// <summary>
        /// Get all InjectConfigurationParameterAttributes from constructor
        /// </summary>
        /// <param name="namedTypeSymbol"></param>
        /// <returns></returns>
        public static IEnumerable<InjectConfigurationParameterAttribute>? GetInjectConfigurationParameterAttributes(this INamedTypeSymbol namedTypeSymbol)
        {
            var constructors = namedTypeSymbol.Constructors;

            // Get constructor with InjectConfigurationParameterAttribute
            var constructorWithAttribute = constructors
                .Where(x => x.GetAttributes()
                    .Any(p => p.AttributeClass!.Name.Equals(nameof(InjectConfigurationParameterAttribute))))
                    .SingleOrDefault();

            // Return null if no constructor exists
            if (constructorWithAttribute == null)
                return null;

            // Return list of attributes
            return constructorWithAttribute
                .GetAttributes()
                    .Where(x => x.AttributeClass!.Name.Equals(nameof(InjectConfigurationParameterAttribute)))
                    .Select(p => new InjectConfigurationParameterAttribute((string)p.ConstructorArguments[0].Value!, (string)p.ConstructorArguments[1].Value!));
        }

        /// <summary>
        /// Gets name and type as string for all constructor parameters
        /// </summary>
        /// <param name="namedTypeSymbol"></param>
        /// <returns></returns>
        public static Dictionary<string, string>? GetConstructorParameters(this INamedTypeSymbol namedTypeSymbol)
        {
            var constructors = namedTypeSymbol.Constructors;

            var constructorWithAttribute = constructors.Where(x => x.GetAttributes().Any(p => p.AttributeClass!.Name.Equals(nameof(InjectConfigurationParameterAttribute)))).SingleOrDefault();

            if (constructorWithAttribute == null)
                return null;

            var parameterList = new Dictionary<string, string>();

            foreach (var parameter in constructorWithAttribute.Parameters)
            {
                var name = parameter.Name;
                var type = parameter.Type.ToString();

                parameterList.Add(name, type);
            }

            return parameterList;
        }

        public static (string interfaceFullName, InjectionMethods injectionMethod)? GetInjectAttribute(this INamedTypeSymbol namedTypeSymbol)
        {
            var attributes = namedTypeSymbol.GetAttributes();

            var injectAttribute = attributes.FirstOrDefault(a => a.AttributeClass?.Name == nameof(InjectAttribute));

            if (injectAttribute == null)
                return null;

            return (injectAttribute.ConstructorArguments[0].Value!.ToString(), (InjectionMethods)injectAttribute.ConstructorArguments[1].Value!);
        }

        public static string GetFullName(this INamedTypeSymbol namedTypeSymbol)
        {
            var ns = namedTypeSymbol.ContainingNamespace;
            var nss = new List<string>();
            while (ns != null)
            {
                if (string.IsNullOrWhiteSpace(ns.Name))
                    break;
                nss.Add(ns.Name);
                ns = ns.ContainingNamespace;
            }
            nss.Reverse();
            if (nss.Any())
                return $"{string.Join(".", nss)}.{namedTypeSymbol.Name}";
            return namedTypeSymbol.Name;
        }
    }
}
