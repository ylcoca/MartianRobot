
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Entities
{
    public class FileManagement : IFile
    {

        public IEnumerable<string> GetFile()
        {
            using IHost host = Host.CreateDefaultBuilder().Build();

            IConfiguration config = host.Services.GetRequiredService<IConfiguration>();
            string filePath = config.GetValue<string>("Setting:FilePath");


            return File.ReadLines($"{filePath}");
        }
    }
}
