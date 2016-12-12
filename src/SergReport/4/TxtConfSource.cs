using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SergReport._4
{
    public class TxtConfSource : IConfigurationSource
    {

        public string FilePath { get; set; }

        public TxtConfSource(string path)
        {
            FilePath = path;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            string filepath = builder.GetFileProvider().GetFileInfo(FilePath).PhysicalPath;
            return new TxtConfigProvider(filepath);
        }
    }
}
