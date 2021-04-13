using CsvJoin.Models;
using CsvJoin.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CsvJoin.Services
{
    public class LinqPreparator : ILinqPreparator
    {
        public IEnumerable<dynamic> PrepareLeftJoinLinq(
            IEnumerable<Csv1> csv1s,
            IEnumerable<Csv2> csv2s)
        {
            return from csv1 in csv1s
                   join csv2 in csv2s on new { csv1.Customer, csv1.Product, csv1.Quantity } equals new { csv2.Customer, csv2.Product, csv2.Quantity } into gj
                   from csv2 in gj.DefaultIfEmpty()
                   select new { csv1.Customer, csv1.Product, csv1.Price, csv1.Quantity, Cost = csv2?.Cost ?? string.Empty };
        }

        public IEnumerable<dynamic> PrepareJoinLinq(
            IEnumerable<Csv1> csv1s,
            IEnumerable<Csv2> csv2s)
        {
            return from csv1 in csv1s
                   join csv2 in csv2s on new { csv1.Customer, csv1.Product, csv1.Quantity } equals new { csv2.Customer, csv2.Product, csv2.Quantity }
                   select new { csv1.Customer, csv1.Product, csv1.Price, csv1.Quantity, csv2.Cost };
        }
    }
}
