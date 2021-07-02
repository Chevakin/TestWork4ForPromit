using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWork4ForPromit.Domain;

namespace TestWork4ForPromit.Downloader
{
    public class Downloader
    {
        private const int _countStringShow = 5;

        public void Start()
        {
            var str = GetString();
            var service = new Service();
            var strings = service.GetFiveMostPopularStrings(str, _countStringShow);

            ShowStrings(strings);
        }

        private void ShowStrings(IEnumerable<string> strings)
        {
            foreach (var str in strings)
            {
                Console.WriteLine(str);
            }
        }

        private string GetString()
        {
            do
            {
                Console.WriteLine("Введите, пожалуйста, строку:");

                var str = Console.ReadLine();

                if (string.IsNullOrEmpty(str))
                {
                    Console.WriteLine("Строка не может быть пустой");

                    continue;
                }

                return str;
            } while (true);
        }
    }
}
