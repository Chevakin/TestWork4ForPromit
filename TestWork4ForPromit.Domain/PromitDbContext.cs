using Microsoft.EntityFrameworkCore;

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
