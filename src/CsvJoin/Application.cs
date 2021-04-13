using CsvJoin.Models;
using CsvJoin.Services.Abstractions;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CsvJoin
{
    public class Application
    {
        private readonly ILinqPreparator _preparator;

        public Application(ILinqPreparator preparator) =>
            _preparator = preparator;

        public void Run(string[] args)
        {
            if (args.Length < 3)
            {
                throw new ArgumentException(nameof(args));
            }

            string directory = args.First();
            string[] fileNames = args.Skip(1).Take(2).ToArray();

            using var reader1 = new StreamReader(@$"{directory}\{fileNames[0]}");
            using var reader2 = new StreamReader(@$"{directory}\{fileNames[1]}");

            var sales = CsvSerializer.DeserializeFromReader<IEnumerable<Sale>>(reader1);
            var newSales = CsvSerializer.DeserializeFromReader<IEnumerable<NewSale>>(reader2);

            var linq = _preparator.PrepareLeftJoinLinq(sales, newSales);

            var output = Console.OpenStandardOutput();

            using StreamWriter writer = new StreamWriter(output);

            CsvSerializer.SerializeToWriter(linq, writer);
        }
    }
}
