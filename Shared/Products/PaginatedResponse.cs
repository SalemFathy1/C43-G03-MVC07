using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Products
{
    public record PaginatedResponse<T>(int PageIndex, int PageSize, int TotalCount, IEnumerable<T> data);
}
