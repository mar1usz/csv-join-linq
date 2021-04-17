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

            string path1 = Path.Combine(
                Environment.CurrentDirectory,
                directory,
                fileNames[0]);

            string path2 = Path.Combine(
                Environment.CurrentDirectory,
                directory,
                fileNames[1]);

            using var stream1 = File.OpenRead(path1);

            using var stream2 = File.OpenRead(path2);

            var csv1s = CsvSerializer
                .DeserializeFromStream<IEnumerable<Csv1>>(stream1);

            var csv2s = CsvSerializer
                .DeserializeFromStream<IEnumerable<Csv2>>(stream2);

            var linq = _preparator.PrepareLeftJoinLinq(csv1s, csv2s);

            var output = Console.OpenStandardOutput();

            CsvSerializer.SerializeToStream(linq, output);
        }
    }
}
