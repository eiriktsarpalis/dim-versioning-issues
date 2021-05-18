# dim-versioning-issues

Showcases compile-time and runtime errors related to the diamond problem when introducing new DIMs to existing interfaces.
This solution contains 3 projects:

* `CoreLib` contains a set of core interface implementations in BCL.
* `ThirdPartyLibrary` simulates a nuget package that implements the core interfaces.
* `ConsoleApp` is a console application depending on `ThirdPartyLibrary`.

To reproduce a compile-time error:
```
dotnet build -p:DefineConstants=IS_DIM_ADDED

(6,36): error CS8705: Interface member 'IMyEnumerable<T>.TryGetNonEnumeratedCount(out int)' does not have a most specific implementation. Neither 'IMyReadOnlyCollection<T>.IMyEnumerable<T>.TryGetNonEnumeratedCount(out int)', nor 'IMyCollection<T>.IMyEnumerable<T>.TryGetNonEnumeratedCount(out int)' are most specific. [C:\Users\eitsarpa\source\repos\DIM\ThirdPartyLibrary\ThirdPartyLibrary.csproj]
```
To reproduce a runtime diamond error:
```
dotnet build -p:DefineConstants='IS_DIM_ADDED%3BIS_DIM_ADDED_TO_NUGET_LIBRARY' # compile everything with DIM extensions enabled.
dotnet build ThirdPartyLibrary -o ConsoleApp/bin/Debug/net5.0/ # Recompile the 3P library to simulate a dependency that is DIM-unaware
dotnet run --no-build --project ConsoleApp

Unhandled exception. System.MissingMethodException: Method not found: 'Boolean CoreLib.IMyEnumerable`1.TryGetNonEnumeratedCount(Int32 ByRef)'.
   at ConsoleApp.Program.Main()
```
