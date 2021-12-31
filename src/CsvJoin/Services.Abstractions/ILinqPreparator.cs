using CsvJoin.Models;
using System.Collections.Generic;

namespace CsvJoin.Services.Abstractions
{
    public interface ILinqPreparator
    {
        IEnumerable<object> PrepareLeftJoinLinq(IEnumerable<Csv1> csv1s, IEnumerable<Csv2> csv2s);
        IEnumerable<object> PrepareJoinLinq(IEnumerable<Csv1> csv1s, IEnumerable<Csv2> csv2s);
    }
}
