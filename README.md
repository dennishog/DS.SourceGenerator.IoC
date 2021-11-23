# DS.SourceGenerator.IoC

##Goal
To be able to automatically generate an extension method on IServiceCollection that can be used in startup/program with all registrations of classes.
The package is not intended to replace any MS extension methods, such as AddDbContext, etc.

##Installation
Install package DS.SourceGenerator.IoC from nuget using package manager

##Usage
```
    [Inject(typeof(ISomeService))]
    public class SomeService : ISomeService
    {
        [InjectConfigurationParameter("applicationName", "Application:Name")]
        public SomeService(ILogger<SomeService> logger, string applicationName)
        {

        }
    }
```

InjectAttribute is used by supplying the interface that should be used. There is an optional second parameter indicating how the service should be instantiated. Default is Transient.

InjectConfigurationParameter makes it possible to read from IConfiguration according to the provided path. The first parameter indicates which parameter in the constructor, and the second the path in IConfiguration to fetch value from.
