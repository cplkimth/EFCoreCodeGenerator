using Chinook.Data;

namespace Chinook.DataClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = DbContextFactory.Create();
            Console.WriteLine(context.Procedures.usp_GetSystemTimeAsync().Result[0].Now);

            var result = context.Procedures.usp_GeEmployeeRecursivelyAsync(1).Result;
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}