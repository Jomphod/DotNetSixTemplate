using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using static Dapper.SqlMapper;

namespace Core.Interfaces.Infra.Helpers
{
    public interface IDapperDBHelper
    {
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void Dispose();
        object ExecuteScalar(string sql);
        T ExecuteScalar<T>(string sql);
        Task<object> ExecuteScalarAsync(string sql);
        Task<T> ExecuteScalarAsync<T>(string sql);
        object QuerySingle(string sql);
        T QuerySingle<T>(string sql);
        object QuerySingleOrDefault(string sql);
        T QuerySingleOrDefault<T>(string sql);
        object QueryFirst(string sql);
        T QueryFirst<T>(string sql);
        object QueryFirstOrDefault(string sql);
        T QueryFirstOrDefault<T>(string sql);
        object Query(string sql);
        T Query<T>(string sql);
        Task<object> QueryAsync(string sql);
        Task<T> QueryAsync<T>(string sql);
        GridReader QueryMultiple(string sql);
        Task<GridReader> QueryMultipleAsync(string sql);
        IEnumerable<dynamic> Read(GridReader gridReader);
        Task<IEnumerable<dynamic>> ReadAsync(GridReader gridReader);
        T Read<T>(GridReader gridReader);
        Task<T> ReadAsync<T>(GridReader gridReader);
        IEnumerable<dynamic> ReadFirst(GridReader gridReader);
        Task<IEnumerable<dynamic>> ReadFirstAsync(GridReader gridReader);
        T ReadFirst<T>(GridReader gridReader);
        Task<T> ReadFirstAsync<T>(GridReader gridReader);
        IEnumerable<dynamic> ReadFirstOrDefault(GridReader gridReader);
        Task<IEnumerable<dynamic>> ReadFirstOrDefaultAsync(GridReader gridReader);
        T ReadFirstOrDefault<T>(GridReader gridReader);
        Task<T> ReadFirstOrDefaultAsync<T>(GridReader gridReader);
        IEnumerable<dynamic> ReadSingle(GridReader gridReader);
        Task<IEnumerable<dynamic>> ReadSingleAsync(GridReader gridReader);
        T ReadSingle<T>(GridReader gridReader);
        Task<T> ReadSingleAsync<T>(GridReader gridReader);
        IEnumerable<dynamic> ReadSingleOrDefault(GridReader gridReader);
        Task<IEnumerable<dynamic>> ReadSingleOrDefaultAsync(GridReader gridReader);
        T ReadSingleOrDefault<T>(GridReader gridReader);
        Task<T> ReadSingleOrDefaultAsync<T>(GridReader gridReader);
    }
}
