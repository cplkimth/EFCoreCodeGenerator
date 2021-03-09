Run following code to generate codes/

EFCoreCodeGenerator.CodeGenerator.Generate(new {DbContext object}, {a path of project which has DbContext class}, {a path of project which Code Generation Tempate will be generated});

ex)
EFCoreCodeGenerator.CodeGenerator.Generate(new ChinookContext(), @"C:\git\EFCoreCodeGenerator\Examples\ChinookCore.Data", @"C:\git\EFCoreCodeGenerator\Examples\ChinookCore.MP");

Check out README.md in GitHub repository.
https://github.com/cplkimth/EFCoreCodeGenerator