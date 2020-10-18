// Generated by Sichem at 2020-09-30 18:30:48

using System;

namespace ZlibSharp
{
    internal unsafe class Adler32
    {
        public static int adler32(int adler, ReadOnlySpan<byte> buf)
        {
            int sum2 = 0;
            uint n = 0;
            sum2 = (adler >> 16) & 0xffff;
            adler &= 0xffff;
            if (buf.Length == 1)
            {
                adler += buf[0];
                if (adler >= 65521U)
                    adler -= (int)65521U;
                sum2 += adler;
                if (sum2 >= 65521U)
                    sum2 -= (int)65521U;
                return adler | (sum2 << 16);
            }

            if (buf.IsEmpty)
                return (int)1L;

            if (buf.Length < 16)
            {
                for (int i = 0; i < buf.Length; i++)
                {
                    adler += buf[i];
                    sum2 += adler;
                }
                if (adler >= 65521U)
                    adler -= (int)65521U;
                sum2 %= (int)65521U;
                return adler | (sum2 << 16);
            }

            while (buf.Length >= 5552)
            {
                n = 5552 / 16;
                do
                {
                    {
                        adler += buf[0];
                        sum2 += adler;
                    }
                    {
                        adler += buf[0 + 1];
                        sum2 += adler;
                    }
                    {
                        adler += buf[0 + 2];
                        sum2 += adler;
                    }
                    {
                        adler += buf[0 + 2 + 1];
                        sum2 += adler;
                    }
                    {
                        adler += buf[0 + 4];
                        sum2 += adler;
                    }
                    {
                        adler += buf[0 + 4 + 1];
                        sum2 += adler;
                    }
                    {
                        adler += buf[0 + 4 + 2];
                        sum2 += adler;
                    }
                    {
                        adler += buf[0 + 4 + 2 + 1];
                        sum2 += adler;
                    }
                    {
                        adler += buf[8];
                        sum2 += adler;
                    }
                    {
                        adler += buf[8 + 1];
                        sum2 += adler;
                    }
                    {
                        adler += buf[8 + 2];
                        sum2 += adler;
                    }
                    {
                        adler += buf[8 + 2 + 1];
                        sum2 += adler;
                    }
                    {
                        adler += buf[8 + 4];
                        sum2 += adler;
                    }
                    {
                        adler += buf[8 + 4 + 1];
                        sum2 += adler;
                    }
                    {
                        adler += buf[8 + 4 + 2];
                        sum2 += adler;
                    }
                    {
                        adler += buf[8 + 4 + 2 + 1];
                        sum2 += adler;
                    }
                    buf = buf.Slice(16);
                }
                while ((--n) != 0);
                adler %= (int)65521U;
                sum2 %= (int)65521U;
            }
            if (buf.Length != 0)
            {
                while (buf.Length >= 16)
                {
                    {
                        adler += buf[0];
                        sum2 += adler;
                    }
                    {
                        adler += buf[0 + 1];
                        sum2 += adler;
                    }
                    {
                        adler += buf[0 + 2];
                        sum2 += adler;
                    }
                    {
                        adler += buf[0 + 2 + 1];
                        sum2 += adler;
                    }
                    {
                        adler += buf[0 + 4];
                        sum2 += adler;
                    }
                    {
                        adler += buf[0 + 4 + 1];
                        sum2 += adler;
                    }
                    {
                        adler += buf[0 + 4 + 2];
                        sum2 += adler;
                    }
                    {
                        adler += buf[0 + 4 + 2 + 1];
                        sum2 += adler;
                    }
                    {
                        adler += buf[8];
                        sum2 += adler;
                    }
                    {
                        adler += buf[8 + 1];
                        sum2 += adler;
                    }
                    {
                        adler += buf[8 + 2];
                        sum2 += adler;
                    }
                    {
                        adler += buf[8 + 2 + 1];
                        sum2 += adler;
                    }
                    {
                        adler += buf[8 + 4];
                        sum2 += adler;
                    }
                    {
                        adler += buf[8 + 4 + 1];
                        sum2 += adler;
                    }
                    {
                        adler += buf[8 + 4 + 2];
                        sum2 += adler;
                    }
                    {
                        adler += buf[8 + 4 + 2 + 1];
                        sum2 += adler;
                    }
                    buf = buf.Slice(16);
                }

                for (int i = 0; i < buf.Length; i++)
                {
                    adler += buf[i];
                    sum2 += adler;
                }
                adler %= (int)65521U;
                sum2 %= (int)65521U;
            }

            return adler | (sum2 << 16);
        }

        public static int adler32_combine_(int adler1, int adler2, long len2)
        {
            if (len2 < 0)
                return unchecked((int)0xffffffffu);
            len2 %= 65521U;
            uint rem = (uint)len2;
            int sum1 = adler1 & 0xffff;
            int sum2 = (int)(rem * sum1);
            sum2 %= (int)65521U;
            sum1 += (int)((adler2 & 0xffff) + 65521U - 1);
            sum2 += (int)(((adler1 >> 16) & 0xffff) + ((adler2 >> 16) & 0xffff) + 65521U - rem);
            if (sum1 >= 65521U)
                sum1 -= (int)65521U;
            if (sum1 >= 65521U)
                sum1 -= (int)65521U;
            if (sum2 >= ((int)65521U << 1))
                sum2 -= (int)65521U << 1;
            if (sum2 >= 65521U)
                sum2 -= (int)65521U;
            return sum1 | (sum2 << 16);
        }

        public static int adler32_combine(int adler1, int adler2, int len2)
        {
            return adler32_combine_(adler1, adler2, len2);
        }

        public static int adler32_combine64(int adler1, int adler2, long len2)
        {
            return adler32_combine_(adler1, adler2, len2);
        }
    }
}