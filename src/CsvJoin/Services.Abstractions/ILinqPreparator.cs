using CsvJoin.Models;
using System.Collections.Generic;

namespace CsvJoin.Services.Abstractions
{
    public interface ILinqPreparator
    {
        IEnumerable<dynamic> PrepareLeftJoinLinq(IEnumerable<Csv1> csv1s, IEnumerable<Csv2> csv2s);
        IEnumerable<dynamic> PrepareJoinLinq(IEnumerable<Csv1> csv1s, IEnumerable<Csv2> csv2s);
    }
}
