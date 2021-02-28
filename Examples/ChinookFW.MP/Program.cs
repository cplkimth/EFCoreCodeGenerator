﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChinookFW.Data;
using EFCoreCodeGenerator;

namespace ChinookFW.MP
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(Dao.Artist.GetCount());
#if Linux
            MidnightPeachCore.CodeGenerator.Generate(new ChinookContext(), "/home/thkim/git/MidnightPeachCore/Example/Chinook.Data");
#else
            CodeGenerator.Generate(new ChinookContext(), @"C:\git\EFCoreCodeGenerator\Examples\ChinookFW.Data", @"C:\git\EFCoreCodeGenerator\Examples\ChinookFW.MP");            
#endif
        }
    }
}
