using Core.Interfaces.Infra.Database;
using Core.Interfaces.Infra.Helpers;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Database.Helpers
{
    public class DBHelper : IDBHelper
    {
        private readonly DataContext _context;
        private IDbContextTransaction _transaction;

        public DBHelper(DataContext context)
        {
            _context = context;
        }
        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
                await _transaction.CommitAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
                await _transaction.RollbackAsync();
        }

        public void ExecuteSql(string sql)
        {
            FormattableString fs = $"{sql}";
            _context.Database.OpenConnection();
            _context.Database.ExecuteSql(fs);
            _context.Database.CloseConnection();

        }

        public async Task ExecuteSqlAsync(string sql)
        {
            FormattableString sqlString = $"{sql}";
            await _context.Database.ExecuteSqlAsync(sqlString);
        }

        public  void ExecuteSqlInterpolated(string sql)
        {
            FormattableString sqlString = $"{sql}";
            _context.Database.ExecuteSqlInterpolated(sqlString);
        }

        public async Task ExecuteSqlInterpolatedAsync(string sql)
        {
            FormattableString sqlString = $"{sql}";
            await _context.Database.ExecuteSqlInterpolatedAsync(sqlString);
        }

        public void ExecuteSqlRaw(string sql)
        {
            _context.Database.ExecuteSqlRaw(sql);
        }

        public async Task ExecuteSqlRawAsync(string sql)
        {
            await _context.Database.ExecuteSqlRawAsync(sql);
        }

        public object SqlQuery(string sql, string condition, string orderBy)
        {
            //_context.Database.OpenConnection();
            var dt = new DataTable();
            dt.Columns.Add("query_name");
            dt.Columns.Add("query_value");
            var x = _context.Database.SqlQueryRaw<DataRow>(sql).AsEnumerable().Select(x =>
            {
                var dr = dt.NewRow();
                dr["query_name"] = (string)x["query_name"];
                dr["query_value"] = (string)x["query_value"];
                return dr;
            }).CopyToDataTable();

            //var x1 = x.CopyToDataTable<DataRow>();
            

            //_context.Database.CloseConnection();
            return x;
        }
    }
}
