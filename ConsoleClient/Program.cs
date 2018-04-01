using System;
using System.Configuration;
using static StreamsDemo.StreamsExtension;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = ConfigurationManager.AppSettings["sourceFilePath"];

            var destination = ConfigurationManager.AppSettings["destinationFiePath"];

            source = @"C:\Users\Анастасия\Desktop\SourceText.txt";

            destination = @"C:\Users\Анастасия\Source\Repos\NET.S.2018.Petrikevich.09\ConsoleClient\ByByteCopyText.txt";
            Console.WriteLine($"ByteCopy() done. Total bytes: {ByByteCopy(source, destination)}");
            Console.WriteLine(IsContentEquals(source, destination));

            destination = @"C:\Users\Анастасия\Source\Repos\NET.S.2018.Petrikevich.09\ConsoleClient\InMemoryByteCopyText.txt";
            Console.WriteLine($"InMemoryByteCopy() done. Total bytes: {InMemoryByByteCopy(source, destination)}");
            Console.WriteLine(IsContentEquals(source, destination));

            destination = @"C:\Users\Анастасия\Source\Repos\NET.S.2018.Petrikevich.09\ConsoleClient\ByBlockCopyText.txt";
            Console.WriteLine($"ByBlockCopy() done. Total bytes: {ByBlockCopy(source, destination)}");
            Console.WriteLine(IsContentEquals(source, destination));

            destination = @"C:\Users\Анастасия\Source\Repos\NET.S.2018.Petrikevich.09\ConsoleClient\BufferedCopyText.txt";
            Console.WriteLine($"BufferedCopy() done. Total bytes: {BufferedCopy(source, destination)}");
            Console.WriteLine(IsContentEquals(source, destination));

            destination = @"C:\Users\Анастасия\Source\Repos\NET.S.2018.Petrikevich.09\ConsoleClient\ByLineCopyText.txt";
            Console.WriteLine($"ByLineCopy() done. Total bytes: {ByLineCopy(source, destination)}");
            Console.WriteLine(IsContentEquals(source, destination));

            //etc
            Console.ReadKey();
        }
    }
}
