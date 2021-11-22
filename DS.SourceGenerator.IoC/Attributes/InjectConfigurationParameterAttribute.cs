using System;

namespace DS.SourceGenerator.IoC.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor, Inherited = false, AllowMultiple = true)]
    public class InjectConfigurationParameterAttribute : Attribute
    {
        public string Parameter { get; set; }
        public string ConfigurationPath { get; set; }

        public InjectConfigurationParameterAttribute(string parameter, string configurationPath)
        {
            Parameter = parameter;
            ConfigurationPath = configurationPath;
        }
    }
}
