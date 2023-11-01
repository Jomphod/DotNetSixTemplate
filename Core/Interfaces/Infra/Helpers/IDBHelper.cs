using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Infra.Helpers
{
    public interface IDBHelper
    {
        // Transaction Management
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();

        // Execution
        void ExecuteSql(string sql);
        Task ExecuteSqlAsync(string sql);
        void ExecuteSqlInterpolated(string sql);
        Task ExecuteSqlInterpolatedAsync(string sql);
        void ExecuteSqlRaw(string command);
        Task ExecuteSqlRawAsync(string command);
        object SqlQuery(string sql, string condition = "", string orderBy = "");
    }
}
