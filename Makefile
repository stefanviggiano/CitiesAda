.PHONY: main, clear

main:
	dotnet build
clear:
	rm -r obj
	rm -r bin
	rm cities.csproj
