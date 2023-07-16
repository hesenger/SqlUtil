build:
	@dotnet restore --use-lock-file
	@dotnet build --nologo --no-restore

test:
	@dotnet restore --locked-mode
	@dotnet build --nologo --configuration Release
	@dotnet test --nologo --no-build --no-restore --configuration Release
