using System.Threading.Channels;
using Chinook.Data;
using EFCoreCodeGenerator;
using CodeGenerator = EFCoreCodeGenerator.CodeGenerator;

// CodeGenerator.Generate(@"D:\git\EFCoreCodeGenerator\Examples\.NetCore\Chinook.MP\Chinook.json");
CodeGenerator.Generate(new ChinookContext());

Console.WriteLine();
