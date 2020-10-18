using System;
using System.IO;
using System.IO.Compression;
using NUnit.Framework;
using ZlibSharp;

namespace Tests
{
    public class Tests
    {
        private byte[] loremipsum;

        [SetUp]
        public void Setup()
        {
            string dir = TestContext.CurrentContext.TestDirectory;

            loremipsum = File.ReadAllBytes(Path.Combine(dir, "loremipsum.txt"));
        }

        [Test]
        public void Test1()
        {
            byte[] dst = new byte[1024 * 1024];
            byte[] src = loremipsum;
            int dstLength = dst.Length;
            int code = Compress.compress2(dst, ref dstLength, src, src.Length, 5);
            Assert.AreEqual(code, 0);

            var inflated = new MemoryStream();
            using (var inflater = new DeflateStream(new MemoryStream(dst, 0, dstLength), CompressionMode.Decompress))
                inflater.CopyTo(inflated);

            Console.WriteLine(inflated.Length);
        }
    }
}