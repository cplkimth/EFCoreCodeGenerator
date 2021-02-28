#region
using System;
using ChinookCore.Data;
using EFCoreCodeGenerator;
#endregion

namespace ChinookCore.MP
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(Dao.Artist.GetCount());
#if Linux
            MidnightPeachCore.CodeGenerator.Generate(new ChinookContext(), "/home/thkim/git/MidnightPeachCore/Example/Chinook.Data");
#else
            CodeGenerator.Generate(new ChinookContext(), @"C:\git\EFCoreCodeGenerator\Examples\ChinookCore.Data", @"C:\git\EFCoreCodeGenerator\Examples\ChinookCore.MP");          
#endif
        }
    }
}