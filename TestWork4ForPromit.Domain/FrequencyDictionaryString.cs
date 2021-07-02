using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWork4ForPromit.Domain
{
    [Table("FrequencyDictionary")]
    public class FrequencyDictionaryString
    {
        [Key]
        [MinLength(3), MaxLength(20)]
        public string Str { get; set; }

        [MinLength(0)]
        public int Frequency { get; set; }

        public FrequencyDictionaryString(string str, int frequency)
            : this()
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException($"\"{nameof(str)}\" не может быть неопределенным или пустым.", nameof(str));
            }
            if (frequency < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(frequency)} не может быть меньше нуля");
            }

            Str = str;
            Frequency = frequency;
        }

        private FrequencyDictionaryString()
        {
        }
    }
}
