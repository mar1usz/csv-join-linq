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
            IEnumerable<Sale> sales,
            IEnumerable<NewSale> newSales)
        {
            return from sale in sales
                   join newSale in newSales on new { sale.Customer, sale.Product, sale.Quantity } equals new { newSale.Customer, newSale.Product, newSale.Quantity } into gj
                   from newSale in gj.DefaultIfEmpty()
                   select new { sale.Customer, sale.Product, sale.Price, sale.Quantity, Cost = newSale?.Cost ?? null };
        }

        public IEnumerable<dynamic> PrepareJoinLinq(
            IEnumerable<Sale> sales,
            IEnumerable<NewSale> newSales)
        {
            return from sale in sales
                   join newSale in newSales on new { sale.Customer, sale.Product, sale.Quantity } equals new { newSale.Customer, newSale.Product, newSale.Quantity }
                   select new { sale.Customer, sale.Product, sale.Price, sale.Quantity, newSale.Cost };
        }
    }
}
