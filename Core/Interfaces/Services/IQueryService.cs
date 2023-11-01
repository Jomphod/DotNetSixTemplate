using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IQueryService
    {
        object QueryWithNoPaging(string queryName, string condition = "", string orderBy = "");
        object QueryWithPaging(string queryName, string condition = "", string orderBy = "", int pageNo = 1, int pageSize = 20);
        Task<object> QueryWithNoPagingAsync(string queryName, string condition = "", string orderBy = "");
        Task<object> QueryWithPagingAsync(string queryName, string condition = "", string orderBy = "", int pageNo = 1, int pageSize = 20);
    }
}
