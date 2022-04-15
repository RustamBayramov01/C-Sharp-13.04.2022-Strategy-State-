using System;

namespace ConsoleApp1
{
    public interface ICompression { void CompressFolder(string compressedArchiveFileName); }

    public class RarCompression : ICompression
    {
        public void CompressFolder(string compressedArchiveFileName)
        {
            Console.WriteLine("Qovluq Rar yanaşmasından istifadə edərək sıxılır : '" + compressedArchiveFileName + ".rar' fayl yaradılmışdır");
        }
    }

    public class ZipCompression : ICompression
    {
        public void CompressFolder(string compressedArchiveFileName)
        {
            Console.WriteLine("Qovluq Zip yanaşmasından istifadə edərək sıxılır: '" + compressedArchiveFileName + ".zip' fayl yaradılmışdır");
        }
    }

    public class CompressionContext
    {
        private ICompression Compression;

        public CompressionContext(ICompression Compression) { this.Compression = Compression; }
        public void SetStrategy(ICompression Compression) { this.Compression = Compression; }
        public void CreateArchive(string compressedArchiveFileName) { Compression.CompressFolder(compressedArchiveFileName); }
    }


    class Program
    {
        static void Main(string[] args)
        {
            CompressionContext ctx = new CompressionContext(new ZipCompression());
            ctx.CreateArchive("DotNetDesignPattern");
            ctx.SetStrategy(new RarCompression());
            ctx.CreateArchive("DotNetDesignPattern");
            Console.Read();
        }
    }
}
