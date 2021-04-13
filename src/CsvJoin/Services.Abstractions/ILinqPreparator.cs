using CsvJoin.Models;
using System.Collections.Generic;

namespace CsvJoin.Services.Abstractions
{
    public interface ILinqPreparator
    {
        IEnumerable<dynamic> PrepareLeftJoinLinq(IEnumerable<Sale> sales, IEnumerable<NewSale> newSales);
        IEnumerable<dynamic> PrepareJoinLinq(IEnumerable<Sale> sales, IEnumerable<NewSale> newSales);
    }
}
