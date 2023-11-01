using Core.Interfaces.Infra.Database;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class QueryService : IQueryService
    {
        private readonly IQueryRepository _queryRepository;

        public QueryService(IQueryRepository queryRepository)
        {
            this._queryRepository = queryRepository;
        }

        public byte[] QueryToCSV(string query)
        {
            throw new NotImplementedException();
        }

        public object QueryWithNoPaging(string queryName, string condition, string orderBy)
        {
            return _queryRepository.QueryWithNoPaging(queryName, condition, orderBy);
        }

        public object QueryWithPaging(string queryName, string condition, string orderBy, int pageNo, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<object> QueryWithNoPagingAsync(string queryName, string condition, string orderBy)
        {
            throw new NotImplementedException();
        }

        public Task<object> QueryWithPagingAsync(string queryName, string condition, string orderBy, int pageNo, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
