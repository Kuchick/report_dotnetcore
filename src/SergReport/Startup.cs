using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using SergReport._4;

namespace SergReport
{
    public class Startup
    {
        
         /*
        ////////////////////////////////////////////////////////////**1**

        //Свойство которое будет хранить наше настройки конфигурации
        public IConfiguration MyAppConfig { get; set; }

        //Конструктор в котором мы будем регистрировать нашу конфигурацию
        public Startup(IHostingEnvironment env)
        {
            //С помощью "строителя" - ConfigBuilder создадим новую конфигурацию в памяти
            var builder = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    //Добавляем в коллекцию наше "сообщение"
                    {"message", "Hello from memory!" }
                });
            //С помощью метода Build создаём объект конфигурации
            MyAppConfig = builder.Build();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {         
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(MyAppConfig["message"]);
            });
        }
        /* */

        
          /*
        ///////////////////////////////////////////////////// **2**

        public IConfiguration MyAppConfig { get; set; }


        public Startup(IHostingEnvironment env)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    {"message","Hello from memory!!!" }
                })
                .AddJsonFile("conf.json");


            MyAppConfig = builder.Build();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(MyAppConfig["message"] + MyAppConfig["message2"]);
            });
        }
        /* */


         /*
        ///////////////////////////////////////////////////// **3**

        public IConfiguration MyAppConfig { get; set; }


        public Startup(IHostingEnvironment env)
        {
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("text3.json");


            MyAppConfig = builder.Build();
        }

        private string GetSectionContent(IConfiguration configSection)
        {
            string sectionContent = "";
            foreach (var section in configSection.GetChildren())
            {
                sectionContent += "\"" + section.Key + "\":";
                if (section.Value == null)
                {
                    string subSectionContent = GetSectionContent(section);
                    sectionContent += "{\n" + subSectionContent + "},\n";
                }
                else
                {
                    sectionContent += "\"" + section.Value + "\",\n";
                }
            }
            return sectionContent;
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            string projectJsonContent = GetSectionContent(MyAppConfig);
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("{\n" + projectJsonContent + "}");
            });
        }
        /* */
        
        //    /*
        ///////////////////////////////////////////////////// **4**
        public Startup(IHostingEnvironment env)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory());

            builder.AddTxtFile("meme.txt");
            MyAppConfig = builder.Build();
        }

        public IConfiguration MyAppConfig { get; set; }

    
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            
            var text1 = MyAppConfig["text1"];
            var text2 = MyAppConfig["text2"];
            var style1 = MyAppConfig["style1"];
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"<div'>{text1} <br> <span style=\\{style1}> {text2} </span> </div> ");
            });
        }
        /* */

    }
}
