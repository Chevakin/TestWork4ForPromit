using System;
using System.Collections.Generic;
using System.IO;

namespace TestWork4ForPromit.Uploader
{
    public class FileAnalyzer
    {
        private readonly string _path;

        private const int _maxLengthFile = 104857600;

        private const int _minLengthWord = 3;

        private const int _maxLengthWord = 20;

        public FileAnalyzer(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException($"\"{nameof(path)}\" не может быть неопределенным или пустым.", nameof(path));
            }

            _path = path;
        }

        public IEnumerable<string> Start()
        {
            foreach (var str in File.ReadAllLines(_path))
            {
                foreach (var word in str.Split(' '))
                {
                    if (WordIsCorrect(word))
                    {
                        yield return word;
                    }
                }
            }
        }

        public static bool FileIsCorrect(string filename)
        {
            FileStream file;

            try
            {
                file = new FileStream(filename, FileMode.Open, FileAccess.Read);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден");

                return false;
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Не удалось получить доступ к файлу");

                return false;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Неизвестаная ошибка с файловой системой:\n Сообщение: {ex.Message}\n HR: {ex.HResult}");

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неизвестная ошибка:\n Сообщение: {ex.Message}\n HR: {ex.HResult}");

                return false;
            }

            var result =  file != null
                && file.Length <= _maxLengthFile
                && new Utf8Checker().IsUtf8(file);

            if (file != null)
            {
                file.Dispose();
            }

            return result;
        }

        private bool WordIsCorrect(string word)
        {

            return word.Length > _minLengthWord
                || word.Length <= _maxLengthWord;
        }
    }
}