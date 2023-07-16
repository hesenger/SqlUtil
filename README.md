# SqlUtil

[![Nuget Package](https://img.shields.io/nuget/v/SqlUtil.svg)](https://www.nuget.org/packages/SqlUtil/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/SqlUtil.svg)](https://www.nuget.org/packages/SqlUtil/)

SqlUtil started as a thin layer to help data driven applications
interact with a database by helping in mapping and tracking data into classes.

It has grown and changed over time to focus in helper functionalities
to allow fast and easy to debug persistence layer, without touch
critical parts like queries, that eventually require to be optimized.

The current implementation of the tool is heavily focused in attending
the needs of a DDD application striving to keep the domain layer
clean and free of persistence concerns, pretty much the Persistence Ignorance
principle.

## Contributing

Important to mention that the tool is used in a few projects in production
but it started as a personal experiment to play around with TDD so tests
are an important part of the project.

Regardless of the above any contribution is welcome.

## Usage

The tool is available as a nuget package and can be installed using the
dotnet cli:

```bash
dotnet add package SqlUtil
```

WIP section 😢
