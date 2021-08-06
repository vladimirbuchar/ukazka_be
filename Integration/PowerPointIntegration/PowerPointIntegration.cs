using Core.DataTypes;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace Integration.PowerPointIntegration
{
    public class PowerPointIntegration : IPowerPointIntegration
    {
        private readonly string _fileRepositoryPath;
        public PowerPointIntegration(IConfiguration configuration)
        {
            _fileRepositoryPath = string.Format("{0}{1}", Directory.GetCurrentDirectory(), configuration.GetSection("FileRepository").Value);
        }
        public async System.Threading.Tasks.Task<List<PowerPointSlide>> ConvertToHtmlAsync(string root, string file)
        {
            return null;
        
        }
    }
}
