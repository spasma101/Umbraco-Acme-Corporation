using System.Collections.Generic;
using DapperExtensions;

namespace  Acme_Corporation_Core.App_Code.Repository
{
    public abstract class Repository<T> : RepositoryBase where T : class
    {
        protected Repository(string connectionString) : base(connectionString) { }

        public T Get(int id)
        {
            return ExecuteQuery(connection => connection.Get<T>(id));
        }

        public IEnumerable<T> List()
        {
            return ExecuteQuery(connection => connection.GetList<T>());
        }

        public int Add(T item)
        {
            return ExecuteQuery<int>(connection => connection.Insert(item));
        }

        public bool Delete(int id)
        {
            return ExecuteQuery(
                connection =>
                {
                    var item = connection.Get<T>(id);
                    return connection.Delete(item);
                });
        }

        public bool Update(T item)
        {
            return ExecuteQuery(connection => connection.Update(item));
        }
    }
}
