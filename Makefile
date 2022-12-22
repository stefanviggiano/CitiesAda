.PHONY: main, clear

main:
	dotnet build
clear:
	rm -r Cities/obj
	rm -r Cities/bin
	rm Cities/cities.csproj
