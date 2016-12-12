using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SergReport._4
{
    public static class TxtConfigHelper
    {

        public static IConfigurationBuilder AddTxtFile(
            this IConfigurationBuilder builder, string path)
        {
            if(builder == null || string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Something wrong!");
            }

            var source = new TxtConfSource(path);
            builder.Add(source);
            return builder;
        }
    }
}
