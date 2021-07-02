using System;
using TestWork4ForPromit.Domain;

namespace TestWork4ForPromit.Uploader
{
    public class Uploader
    {
        public void Start()
        {
            var dictionary =  GetDictionary();
            var service = new Service();

            service.AddStrings(dictionary);

            Console.WriteLine("-----Загрузка выполнена успешна-----");
        }

        private FrequencyDictionary GetDictionary()
        {
            var pathFile = GetCheckedPath();

            var analyzer = new FileAnalyzer(pathFile);
            var dictionary = new FrequencyDictionary();

            analyzer.Start(dictionary);

            return dictionary;
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
