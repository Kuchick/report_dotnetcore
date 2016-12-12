using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SergReport._4
{
    public class TxtConfigProvider : ConfigurationProvider
    {
        public string FilePath { get; set; }

        public TxtConfigProvider(string path)
        {
            FilePath = path;
        }

        public override void Load()
        {
            var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            using (FileStream fs = new FileStream(FilePath, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string line = string.Empty;
                    while((line = sr.ReadLine())!=null)//Пока есть строки в файле
                    {
                        string key = line.Trim();//Удаляем лишние пробельные символы
                        string value = sr.ReadLine();//Считываем значение
                        data.Add(key, value);//Добавляем данные в локальный словарь
                    }
                }
            }
            Data = data; //Присваиваем локальный словарь глобальному определённому в базовом классе
        }

    }
}
