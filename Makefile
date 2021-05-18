COMPILE_TIME_DIAMOND:
	dotnet build -p:DefineConstants=IS_DIM_ADDED

RUNTIME_DIAMOND:
	dotnet build -p:DefineConstants='IS_DIM_ADDED%3BIS_DIM_ADDED_TO_NUGET_LIBRARY'
	dotnet build ThirdPartyLibrary -o ConsoleApp/bin/Debug/net5.0/ # Recompile the 3P library to simulate a dependency that is DIM-unaware
	dotnet run --no-build --project ConsoleApp