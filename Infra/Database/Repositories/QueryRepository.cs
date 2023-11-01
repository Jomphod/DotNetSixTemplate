using Core.Interfaces.Infra.Database;
using Core.Interfaces.Infra.Helpers;
using Core.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Database.Repositories
{
    public class QueryRepository : IQueryRepository
    {
        private IDBHelper _dbHelper;
        private IServiceProvider _serviceProvider;

        public QueryRepository(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public IDBHelper DBHelper
        {
            get
            {
                if (this._dbHelper == null)
                    this._dbHelper = this._serviceProvider.GetService<IDBHelper>();
                return this._dbHelper;
            }
        }

        public object QueryWithNoPaging(string queryName, string condition, string orderBy)
        {
            var query = this.DBHelper.SqlQuery($"SELECT * FROM SystemQuery");

            //var x = this.DBHelper.SqlQuery(query, condition, orderBy);

            return new { };
        }

        public async Task<object> QueryWithNoPagingAsync(string queryName, string condition, string orderBy)
        {
            throw new NotImplementedException();
        }

        public object QueryWithPaging(string queryName, string condition, string orderBy, int pageNo, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<object> QueryWithPagingAsync(string queryName, string condition, string orderBy, int pageNo, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
