using LiteDB;

namespace BlazorLiteDb001.Model
{
    public class ServiceTbl : BaseRepository<ServiceTbl>
    {
        public ServiceTbl(ILiteDbContext db)
            : base(db)
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; } = "";
        public bool IsActive { get; set; }=true;
    }
}
