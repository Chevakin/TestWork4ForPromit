using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWork4ForPromit.Uploader
{
    public class Uploader
    {
        private readonly FrequencyDictionary _dictionary = new FrequencyDictionary();
        
        public void Start()
        {
            FillDictionary();
        }

        private void FillDictionary()
        {
            var pathFile = GetCheckedPath();

            var analyzer = new FileAnalyzer(pathFile);
            analyzer.Start(_dictionary);
        }

        private string GetCheckedPath()
        {
            string filePath; 

            do
            {
                filePath = GetPath();

            } while (FileAnalyzer.FileIsCorrect(filePath) == false);

            return filePath;
        }

        private string GetPath()
        {
            Console.WriteLine("Введите, пожалуйста, путь к файлу:");

            return Console.ReadLine();
        }
    }
}
