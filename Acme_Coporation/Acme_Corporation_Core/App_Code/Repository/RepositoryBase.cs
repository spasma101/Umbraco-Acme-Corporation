using System;
using System.Data.SqlClient;
using System.Reflection;
using log4net;

namespace  Acme_Corporation_Core.App_Code.Repository
{
    public abstract class RepositoryBase
    {
        protected ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected string ConnectionString;

        protected RepositoryBase(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected TResult ExecuteQuery<TResult>(Func<SqlConnection, TResult> func)
        {
            TResult item;

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    item = func.Invoke(connection);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("ERROR: TaxiInsurer.RepositoryBase: {0}", ex));

                throw;
            }

            return item;
        }
    }
}
