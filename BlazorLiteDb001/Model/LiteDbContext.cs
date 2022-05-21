using BlazorLiteDb001.Data;
using LiteDB;
using Microsoft.Extensions.Options;

namespace BlazorLiteDb001.Model
{
    public interface ILiteDbContext
    {
        LiteDatabase Database { get; }
    }

    public class LiteDbContext : ILiteDbContext
    {
        public LiteDatabase Database { get; }
        public LiteDbContext(IOptions<LiteDbOptions> options)
        {
            Database = new LiteDatabase(options.Value.DatabaseLocation);
        }
    }
}
