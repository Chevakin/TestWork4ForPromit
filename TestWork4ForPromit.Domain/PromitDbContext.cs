using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWork4ForPromit.Domain
{
    public class PromitDbContext : DbContext
    {
        public PromitDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<FrequencyDictionaryString> frequencyDictionaryStrings { get; set; }
    }
}
