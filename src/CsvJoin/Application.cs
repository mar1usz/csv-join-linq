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
        private static readonly Stream Output = Console.OpenStandardOutput();

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

            using var stream1 = GetStream(directory, fileNames[0]);
            using var stream2 = GetStream(directory, fileNames[1]);

            var csv1s = CsvSerializer
                .DeserializeFromStream<IEnumerable<Csv1>>(stream1);
            var csv2s = CsvSerializer
                .DeserializeFromStream<IEnumerable<Csv2>>(stream2);

            var linq = _preparator.PrepareLeftJoinLinq(csv1s, csv2s);
            CsvSerializer.SerializeToStream(linq, Output);
        }

        private FileStream GetStream(string directory, string fileName)
        {
            string path = Path.Join(directory, fileName);
            return File.OpenRead(path);
        }
    }
}
