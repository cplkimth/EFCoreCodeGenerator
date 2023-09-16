using System.Threading.Channels;
using Chinook.Data;
using EFCoreCodeGenerator;
using EFCoreCodeGeneratorV2.Models;
using CodeGenerator = EFCoreCodeGeneratorV2.CodeGenerator;

// CodeGenerator.Generate(@"d:\git\EFCoreCodeGenerator\Examples\.NetCore\Chinook.Data", new ChinookContext());
// CodeGenerator.Generate(@"d:\git\EFCoreCodeGenerator\Examples\.NetCore\Chinook.Data", new ChinookContext());

// Package package = new Package{ Name = "Chinook" };

CodeGenerator.Generate(@"D:\git\EFCoreCodeGenerator\Examples\.NetCore\Chinook.MP\Chinook.json");

Console.WriteLine();
