// Generated by Sichem at 2020-09-30 18:30:48

using static ZlibSharp.ZUtil;

namespace ZlibSharp
{
    public unsafe class Compress
    {
        public static int compress2(byte[] dest, ref int destLen, byte[] source, int sourceLen, int level)
        {
            z_stream_s stream = new z_stream_s();
            int err = 0;
            int max = int.MaxValue;
            int left = destLen;
            err = (int)Deflate.deflateInit_(stream, level, "1.2.11");
            if (err != 0)
                return err;
            stream.next_out = dest;
            stream.avail_out = 0;
            stream.next_in = source;
            stream.avail_in = 0;
            do
            {
                if (stream.avail_out == 0)
                {
                    stream.avail_out = left > ((int)max) ? max : left;
                    left -= (int)stream.avail_out;
                }
                if (stream.avail_in == 0)
                {
                    stream.avail_in = sourceLen > ((int)max) ? max : sourceLen;
                    sourceLen -= (int)stream.avail_in;
                }
                err = (int)Deflate.deflate(stream, sourceLen != 0 ? 0 : 4);
            }
            while (err == 0);
            destLen = stream.total_out;
            Deflate.deflateEnd(stream);
            return err == 1 ? 0 : err;
        }

        public static int compress(byte[] dest, ref int destLen, byte[] source, int sourceLen)
        {
            return compress2(dest, ref destLen, source, sourceLen, -1);
        }

        public static int compressBound(int sourceLen)
        {
            return sourceLen + (sourceLen >> 12) + (sourceLen >> 14) + (sourceLen >> 25) + 13;
        }
    }
}