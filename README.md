# Calc
A simple command line .NET tool to calculate arithmetic expressions, written for fun and education.

* Supports `+ - * /` and `( )` operators
* Doesn't support variables
* For avaliable command line options see the [help message](https://github.com/Expurple/Images/blob/master/Calc/0.2.0.0help.png)

## Latest version (0.2.0.0)

Added three command line options for output formatting:
* `-p`, `--precision` - set output presicion
* `-E`, `--scientific-output` - force output in scientific notation
* `-d`, `--decimal-output` - force output in decimal notation

Usage example:

![](https://raw.githubusercontent.com/Expurple/Images/master/Calc/0.2.0.0usage.png)

## How to build

I use Visual Studio, its `.sln` and `.csproj` files are included in the repository, it should work out of the box.

If you wish to build from the command line:

1) `dotnet --version` (make sure that you have .NET 5 installed)
2) `git clone https://github.com/Expurple/Calc.git some/local/path/to/Calc`
3) `cd some/local/path/to/Calc`
4) `dotnet run` (it should build the project an then run in without arguments, you will see a Calc help message then)
5) Now on Windows you should have `bin/Debug/net5.0/Calc.exe` to run, or a similar file on other systems.

## Tests

I use [NUnit](https://nunit.org) for testing.

Tests are located in a separate project `Tests.csproj` in `Tests/` folder.

I run the tests in Visual Studio's test explorer, but you can use `dotnet test` from the command line, or something else.

## Versioning

I use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/Expurple/Calc/tags). 

## Author

* **Dmitry Alexandrov** - [Expurple](https://github.com/Expurple)

    You can contact me at adk230@yandex.ru

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

Feel free to use and modify the project.
