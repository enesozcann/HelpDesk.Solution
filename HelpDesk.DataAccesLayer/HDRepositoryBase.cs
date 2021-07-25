namespace HelpDesk.DataAccesLayer
{
    internal class HDRepositoryBase
    {
        private static HDDatabaseContext _db;
        private static object _obj = new object();

        protected HDRepositoryBase()
        {
        }

        public static HDDatabaseContext HDCreateContext()
        {
            if (_db == null)
            {
                lock (_obj)
                {
                    if (_db == null)
                    {
                        _db = new HDDatabaseContext();
                    }
                }
            }
            return _db;
        }
    }
}