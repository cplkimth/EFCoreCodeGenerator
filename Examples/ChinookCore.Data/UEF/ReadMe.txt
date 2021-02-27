
1. You can generate framework by executing following code.
Lovanpis.UsingEntityFrameworkCore.CodeGenerator.Generate(new ChinookCore.Data.ChinookContext(), @"C:\git\EFCoreCodeGenerator\Examples\ChinookCore.Data");            


2. Partial classes of each entiy are located in following directory. The files will be generated only if they are NOT exist.
C:\git\EFCoreCodeGenerator\Examples\ChinookCore.Data\UEF\Entities


3. Partial classes of each DAO are located in following directory. The files will be generated only if they are NOT exist.
C:\git\EFCoreCodeGenerator\Examples\ChinookCore.Data\UEF\Dao


4. Most codes are located in following path. The file is overwriten on every generating.
C:\git\EFCoreCodeGenerator\Examples\ChinookCore.Data\UEF\Generated.cs


5. You can set connection string in static constructor of C:\git\EFCoreCodeGenerator\Examples\ChinookCore.Data\UEF\DbContextFactory.cs.
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        // 연결문자열 설정
        
        optionsBuilder.UseLoggerFactory(ChinookContextLoggerFactory.GetInstance(LoggerType.Console));
    }
}