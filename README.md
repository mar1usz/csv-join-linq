# CSV Join LINQ
A command-line tool for performing left outer joins on CSV files in C# .NET Core using LINQ:
```
CsvJoin.exe Data sales.csv new_sales.csv > joined_sales.csv
```

## Features:
- Execute LINQ against CSV files
- Generate C# models and LINQ by using T4 Text Templates
- Save results to CSV

## Prerequisites:
- .NET Core 3.1
- Visual Studio 2022

## Build and run:
### VS:
- src\CsvJoin.sln > Build > Transform All T4 Templates
- Verify that the generated files (src\CsvJoin\Models\Csv1.cs, src\CsvJoin\Models\Csv2.cs and src\CsvJoin\Services\LinqPreparator.cs) do not contain code injection
- F5

## Acknowledgements:
- Microsoft.Extensions.DependencyInjection by https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection (MIT license)
- System.Linq by .NET Core (MIT License)
- ServiceStack.Text by https://www.nuget.org/packages/ServiceStack.Text ([license](https://github.com/ServiceStack/ServiceStack.Text/blob/master/license.txt))
