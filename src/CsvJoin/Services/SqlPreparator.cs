using CsvJoin.Models;
using CsvJoin.Services.Abstractions;
using System;
using System.Collections.Generic;

namespace CsvJoin.Services
{
    public class LinqPreparator : ILinqPreparator
    {
        public IEnumerable<dynamic> PrepareJoinLinq(IEnumerable<Csv1> csv1s, IEnumerable<Csv2> csv2s)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<dynamic> PrepareLeftJoinLinq(IEnumerable<Csv1> csv1s, IEnumerable<Csv2> csv2s)
        {
            throw new NotImplementedException();
        }
    }
}
