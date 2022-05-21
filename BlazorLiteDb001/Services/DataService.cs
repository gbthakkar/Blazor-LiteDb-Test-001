using LiteDB;

namespace BlazorLiteDb001.Services
{
    public class DataService : IDisposable
    {
        private readonly string _connStr;
        private bool _disposed;
        private ILiteDatabase _db;

        public DataService(string connStr)
        {
            if (string.IsNullOrEmpty(connStr))
                throw new ArgumentNullException("missing connection string");

            _connStr = connStr;
        }

        private ILiteDatabase Db
        {
            get
            {
                //if (_db is null)
                //{
                //    _db = new LiteDatabase(_connStr);
                //    return _db;
                //}
                //else
                //{
                //    return _db;
                //}
                return _db ??= new LiteDatabase(_connStr); // whole remarked block above, can be replaced by this one, it's a C# 8 convension
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_db != null)
                        _db.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
