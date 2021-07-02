using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWork4ForPromit.Domain
{
    public class Service
    {
        public void AddStrings(FrequencyDictionary dictionary)
        {
            if (dictionary is null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }

            var context = PromitDbContextFactory.GetDbContext();

            foreach (var pair in dictionary)
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
    }
}
