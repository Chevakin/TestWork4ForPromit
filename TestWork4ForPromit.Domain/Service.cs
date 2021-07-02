using System;
using System.Collections.Generic;
using System.Linq;

namespace TestWork4ForPromit.Domain
{
    public class Service
    {
        public void AddStrings(IEnumerable<KeyValuePair<string, int>> pairs)
        {
            if (pairs is null)
            {
                throw new ArgumentNullException(nameof(pairs));
            }

            using var context = PromitDbContextFactory.GetDbContext();

            foreach (var pair in pairs)
            {
                var str = context.frequencyDictionaryStrings.FirstOrDefault(s => s.Str == pair.Key);

                if (str == null)
                {
                    context.frequencyDictionaryStrings.Add(new FrequencyDictionaryString(pair.Key, pair.Value));
                }
                else
                {
                    str.Frequency += pair.Value;
                }

                context.SaveChanges();
            }
        }

        public IEnumerable<string> GetMostPopularStrings(string str, int count)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException($"\"{nameof(str)}\" не может быть неопределенным или пустым.", nameof(str));
            }

            using var context = PromitDbContextFactory.GetReadOnlyDbContext();

            var dictonaryStrings = context.frequencyDictionaryStrings
                .OrderByDescending(s => s.Frequency)
                .Where(s => s.Str.StartsWith(str))
                .Take(count)
                .ToArray();

            if (dictonaryStrings.Length == 1)
            {
                return dictonaryStrings.Select(s => s.Str);
            }

            for (var i = 0; i < dictonaryStrings.Length - 1; i++)
            {
                var str1 = dictonaryStrings[i];
                var str2 = dictonaryStrings[i + 1];

                if (str1.Frequency == str2.Frequency)
                {
                    if (string.Compare(str1.Str, str2.Str, StringComparison.InvariantCulture) > 0)
                    {
                        var temp = str1;

                        dictonaryStrings[i] = str2;
                        dictonaryStrings[i + 1] = temp;
                    }
                }
            }

            return dictonaryStrings.Select(s => s.Str);
        }
    }
}
