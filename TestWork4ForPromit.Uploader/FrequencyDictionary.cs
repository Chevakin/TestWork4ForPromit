using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TestWork4ForPromit.Uploader
{
    public class FrequencyDictionary : IEnumerable<KeyValuePair<string, int>>
    {
        private readonly Dictionary<string, int> _dictionary;

        public FrequencyDictionary()
        {
            _dictionary = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        }

        public void Remove(string str)
        {
            _dictionary.Remove(str);
        }

        public void Add(string str)
        {
            if (_dictionary.ContainsKey(str))
            {
                _dictionary[str]++;
            }
            else
            {
                _dictionary.Add(str.ToLower(), 1);
            }
        }

        public IEnumerator<KeyValuePair<string, int>> GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, int>>)_dictionary).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_dictionary).GetEnumerator();
        }
    }
}