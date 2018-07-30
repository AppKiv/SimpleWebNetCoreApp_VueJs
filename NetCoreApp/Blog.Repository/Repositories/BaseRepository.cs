using System;
using System.Data;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Npgsql;
using System.Threading.Tasks;

namespace Blog.Repository
{

    public abstract class BaseRepository 
    {
        private string connectionString;
        private readonly Settings _config;
        private readonly ILogger<BaseRepository> _logger;

        public BaseRepository(ILogger<BaseRepository> logger, IOptions<Settings> config)
        {
            _config = config.Value;
            _logger = logger;
            connectionString = _config.MainDbConnectionString;
        }

        //https://gist.github.com/jsauve/ffa2f0dc534aee3a3f16
        //http://www.joesauve.com/async-dapper-and-async-sql-connection-management/
        
        protected async Task<T> WithConnectionAsync<T>(Func<IDbConnection, Task<T>> getData)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    await connection.OpenAsync(); // Asynchronously open a connection to the database
                    return await getData(connection); // Asynchronously execute getData, which has been passed in as a Func<IDBConnection, Task<T>>
                }
            }
            catch (TimeoutException ex)
            {
                var msg = String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName);
                _logger.LogError(ex, msg);
                throw new Exception(msg, ex);
            }
            catch (NpgsqlException ex)
            {
                var msg = String.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName);
                _logger.LogError(ex, msg);
                throw new Exception(msg, ex);
            }
        }

        protected T WithConnectionSync<T>(Func<IDbConnection, T> getData)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open(); 
                    return getData(connection); // execute getData, which has been passed in as a Func<IDBConnection, Task<T>>
                }
            }
            catch (TimeoutException ex)
            {
                var msg = String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName);
                _logger.LogError(ex, msg);
                throw new Exception(msg, ex);
            }
            catch (NpgsqlException ex)
            {
                var msg = String.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName);
                _logger.LogError(ex, msg);
                throw new Exception(msg, ex);
            }
        }

    }

}
