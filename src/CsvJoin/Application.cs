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

        public Application(ILinqPreparator preparator)
        {
            _preparator = preparator;
        }

        public void Run(string[] args)
        {
            if (args.Length < 3)
            {
                throw new ArgumentException(nameof(args));
            }

            string directory = args.First();
            string[] fileNames = args.Skip(1).Take(2).ToArray();

            using var reader1 = GetReader(directory, fileNames[0]);
            using var reader2 = GetReader(directory, fileNames[1]);

            var csv1s = CsvSerializer
                .DeserializeFromReader<IEnumerable<Csv1>>(reader1);
            var csv2s = CsvSerializer
                .DeserializeFromReader<IEnumerable<Csv2>>(reader2);

            var linq = _preparator.PrepareLeftJoinLinq(csv1s, csv2s);

            var output = Console.Out;

            CsvSerializer.SerializeToWriter(linq, output);
        }

        private StreamReader GetReader(string directory, string fileName)
        {
            string path = Path.Combine(
                Environment.CurrentDirectory,
                directory,
                fileName);

            return File.OpenText(path);
        }
    }
}
