using System;
using System.Collections.Generic;
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
            var strings = analyzer.Start();
            var dictionary = GetDictionary(strings);

            DeleteIncorrectWord(dictionary);

            return dictionary;
        }

        private void DeleteIncorrectWord(FrequencyDictionary dictionary)
        {
            if (dictionary is null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }

            foreach (var pair in dictionary)
            {
                if (pair.Value < 4)
                {
                    dictionary.Remove(pair.Key);
                }
            }
        }

        private FrequencyDictionary GetDictionary(IEnumerable<string> strings)
        {
            var dictionary = new FrequencyDictionary();

            foreach (var str in strings)
            {
                dictionary.Add(str);
            }

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
