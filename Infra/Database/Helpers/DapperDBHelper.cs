using Core.Interfaces.Infra.Helpers;
using Dapper;
using Domain.Objects;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Infra.Database.Helpers
{
    public class DapperDBHelper : IDapperDBHelper
    {
        private readonly IDbConnection _dbConnection;
        private IDbTransaction _transaction;
        private readonly ConnectionStrings _connectionStrings;

        public DapperDBHelper(IOptions<ConnectionStrings> options)
        {
            _connectionStrings = options.Value;
           
            this._dbConnection = new SqlConnection(_connectionStrings.Mssql);
        }

        public void BeginTransaction()
        {
            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open();
            }

            _transaction = _dbConnection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
                _transaction = null;
            }
        }

        public void RollbackTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _dbConnection?.Dispose();
        }

        public object ExecuteScalar(string sql)
        {
            _dbConnection.Open();
            return _dbConnection.ExecuteScalar(sql);
        }

        public T ExecuteScalar<T>(string sql)
        {
            _dbConnection.Open();
            return _dbConnection.ExecuteScalar<T>(sql);
        }
        public async Task<object> ExecuteScalarAsync(string sql)
        {
            _dbConnection.Open();
            return await _dbConnection.ExecuteScalarAsync(sql);
        }

        public async Task<T> ExecuteScalarAsync<T>(string sql)
        {
            _dbConnection.Open();
            return await _dbConnection.ExecuteScalarAsync<T>(sql);
        }

        public object QuerySingle(string sql)
        {
            _dbConnection.Open();
            return _dbConnection.QuerySingle(sql);
        }

        public T QuerySingle<T>(string sql)
        {
            _dbConnection.Open();
            return _dbConnection.QuerySingle<T>(sql);
        }

        public object QuerySingleOrDefault(string sql)
        {
            _dbConnection.Open();
            return _dbConnection.QuerySingleOrDefault(sql);
        }

        public T QuerySingleOrDefault<T>(string sql)
        {
            _dbConnection.Open();
            return _dbConnection.QuerySingleOrDefault<T>(sql);
        }

        public object QueryFirst(string sql)
        {
            _dbConnection.Open();
            return _dbConnection.QueryFirst(sql);
        }

        public T QueryFirst<T>(string sql)
        {
            _dbConnection.Open();
            return _dbConnection.QueryFirst<T>(sql);
        }

        public object QueryFirstOrDefault(string sql)
        {
            _dbConnection.Open();
            return _dbConnection.QueryFirstOrDefault(sql);
        }

        public T QueryFirstOrDefault<T>(string sql)
        {
            _dbConnection.Open();
            return _dbConnection.QueryFirstOrDefault<T>(sql);
        }

        public object Query(string sql)
        {
            _dbConnection.Open();
            return _dbConnection.Query(sql);
        }

        public T Query<T>(string sql)
        {
            _dbConnection.Open();
            return (T)_dbConnection.Query<T>(sql);
        }

        public async Task<object> QueryAsync(string sql)
        {
            _dbConnection.Open();
            return await _dbConnection.QueryAsync(sql);
        }

        public async Task<T> QueryAsync<T>(string sql)
        {
            _dbConnection.Open();
            return (T)await _dbConnection.QueryAsync<T>(sql);
        }

        public GridReader QueryMultiple(string sql)
        {
            _dbConnection.Open();
            return _dbConnection.QueryMultiple(sql);
        }

        public async Task<GridReader> QueryMultipleAsync(string sql)
        {
            _dbConnection.Open();
            return await _dbConnection.QueryMultipleAsync(sql);
        }

        public IEnumerable<dynamic> Read(GridReader gridReader)
        {
            return gridReader.Read();
        }
        public async Task<IEnumerable<dynamic>> ReadAsync(GridReader gridReader)
        {
            return await gridReader.ReadAsync();
        }
        public T Read<T>(GridReader gridReader)
        {
            return (T)gridReader.Read<T>();
        }
        public async Task<T> ReadAsync<T>(GridReader gridReader)
        {
            return (T)await gridReader.ReadAsync<T>();
        }
        public IEnumerable<dynamic> ReadFirst(GridReader gridReader)
        {
            return gridReader.ReadFirst();
        }
        public async Task<IEnumerable<dynamic>> ReadFirstAsync(GridReader gridReader)
        {
            return await gridReader.ReadFirstAsync();
        }
        public T ReadFirst<T>(GridReader gridReader)
        {
            return gridReader.ReadFirst<T>();
        }
        public async Task<T> ReadFirstAsync<T>(GridReader gridReader)
        {
            return await gridReader.ReadFirstAsync<T>();
        }
        public IEnumerable<dynamic> ReadFirstOrDefault(GridReader gridReader)
        {
            return gridReader.ReadFirstOrDefault();
        }
        public async Task<IEnumerable<dynamic>> ReadFirstOrDefaultAsync(GridReader gridReader)
        {
            return await gridReader.ReadFirstOrDefaultAsync();
        }
        public T ReadFirstOrDefault<T>(GridReader gridReader)
        {
            return gridReader.ReadFirstOrDefault<T>();
        }
        public async Task<T> ReadFirstOrDefaultAsync<T>(GridReader gridReader)
        {
            return await gridReader.ReadFirstOrDefaultAsync<T>();
        }
        public IEnumerable<dynamic> ReadSingle(GridReader gridReader)
        {
            return gridReader.ReadSingle();
        }
        public async Task<IEnumerable<dynamic>> ReadSingleAsync(GridReader gridReader)
        {
            return await gridReader.ReadSingleAsync();
        }
        public T ReadSingle<T>(GridReader gridReader)
        {
            return gridReader.ReadSingle<T>();
        }
        public async Task<T> ReadSingleAsync<T>(GridReader gridReader)
        {
            return await gridReader.ReadSingleAsync<T>();
        }
        public IEnumerable<dynamic> ReadSingleOrDefault(GridReader gridReader)
        {
            return gridReader.ReadSingleOrDefault();
        }
        public async Task<IEnumerable<dynamic>> ReadSingleOrDefaultAsync(GridReader gridReader)
        {
            return await gridReader.ReadSingleOrDefaultAsync();
        }
        public T ReadSingleOrDefault<T>(GridReader gridReader)
        {
            return gridReader.ReadSingleOrDefault<T>();
        }
        public async Task<T> ReadSingleOrDefaultAsync<T>(GridReader gridReader)
        {
            return await gridReader.ReadSingleOrDefaultAsync<T>();
        }
    }
}
