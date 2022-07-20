// See https://aka.ms/new-console-template for more information

using Chinook.Data;
using EFCoreCodeGenerator;

Console.WriteLine("Hello, World!");

CodeGenerator.Generate(new ChinookContext(), @"C:\git\EFCoreCodeGenerator\Chinook.Data");