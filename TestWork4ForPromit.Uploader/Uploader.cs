using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWork4ForPromit.Uploader
{
    public class Uploader : IDisposable
    {
        private FileStream _file;

        public void Dispose()
        {
            if (_file != null)
            {
                _file.Dispose();
            }
        }

        public void Start()
        {
            _file = GetFIle();
        }

        private FileStream GetFIle()
        {
            FileStream file = null;

            do
            {
                var filePath = GetPath();

                try
                {
                    file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                }
                catch(FileNotFoundException)
                {
                    Console.WriteLine("Файл не найден");
                }
                catch(UnauthorizedAccessException)
                {
                    Console.WriteLine("Не удалось получить доступ к файлу");
                }
                catch(IOException ex)
                {
                    Console.WriteLine($"Неизвестаная ошибка с файловой системой:\n Сообщение: {ex.Message}\n HR: {ex.HResult}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Неизвестная ошибка:\n Сообщение: {ex.Message}\n HR: {ex.HResult}");
                }

            } while (FileIsCorrect(file) == false);

            return file;
        }

        private bool FileIsCorrect(FileStream file)
        {
            return file != null
                && file.Length <= 104857600
                && new Utf8Checker().IsUtf8(file); 
        }

        private string GetPath()
        {
            Console.WriteLine("Введите, пожалуйста, путь к файлу:");

            return Console.ReadLine();
        }
    }
}
