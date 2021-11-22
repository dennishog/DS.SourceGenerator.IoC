using DS.SourceGenerator.IoC.Attributes.Enums;
using System;

namespace DS.SourceGenerator.IoC.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class InjectAttribute : Attribute
    {
        public Type Interface { get; set; }
        public InjectionMethods InjectionMethod { get; }

        public InjectAttribute(Type @interface, InjectionMethods injectionMethod = InjectionMethods.Transient)
        {
            Interface = @interface;
            InjectionMethod = injectionMethod;
        }
    }
}
