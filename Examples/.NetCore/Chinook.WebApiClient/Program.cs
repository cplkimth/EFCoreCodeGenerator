
using System.Net;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Readers;

namespace Chinook.WebApiClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestReader();
            return;
            ChangeMisgeneratedCode();

            ApiClient.BaseAddress = "https://localhost:7098/";

            var jwtToken = ApiClient.Auth.SignInAsync(new AuthInfo { UserName = "4", Password = "Andrew" }).Result;
            ApiClient.JwtToken = jwtToken;

            Console.WriteLine(ApiClient.Auth.IdentifyAsync().Result);
            Console.WriteLine(ApiClient.Track.GetFirstAsync().Result.Name);
        }

        private static void ChangeMisgeneratedCode()
        {
            const string Source = "System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull";
            const string Target = "System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault";

            const string FilePath = @"C:\git\EFCoreCodeGenerator\Chinook.WebApiClient\nswag.g.cs";

            var text = File.ReadAllText(FilePath);
            text = text.Replace(Source, Target);
            File.WriteAllText(FilePath, text);
        }

        private static void TestReader()
        {
            var httpClient = new HttpClient();
            

            var stream = httpClient.GetStreamAsync("https://localhost:7098/swagger/v1/swagger.json").Result;

            // Read V3 as YAML
            var openApiDocument = new OpenApiStreamReader().Read(stream, out var diagnostic);

            // Write V2 as JSON
            var outputString = openApiDocument.Serialize(OpenApiSpecVersion.OpenApi2_0, OpenApiFormat.Json);
            Console.WriteLine(outputString);
        }
    }
}