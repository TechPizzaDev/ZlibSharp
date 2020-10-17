// Generated by Sichem at 2020-09-30 18:30:56

using System;
using System.Runtime.InteropServices;
using static CRuntime;

namespace ZlibSharp
{
	unsafe class ZUtil
	{
		public static sbyte*[] z_errmsg = { "need dictionary", "stream end", "", "file error", "stream error", "data error", "insufficient memory", "buffer error", "incompatible version", "" };
		[StructLayout(LayoutKind.Sequential)]
		public class z_stream_s
	{
		public byte* next_in;
		public uint avail_in;
		public int total_in;
		public byte* next_out;
		public uint avail_out;
		public int total_out;
		public string msg;
		public internal_state state;
		public zalloc_delegate zalloc;
		public zfree_delegate zfree;
		public void * opaque;
		public int data_type;
		public int adler;
		public int reserved;
		}
		[StructLayout(LayoutKind.Sequential)]
		public struct gz_header_s
	{
		public int text;
		public int time;
		public int xflags;
		public int os;
		public byte* extra;
		public uint extra_len;
		public uint extra_max;
		public byte* name;
		public uint name_max;
		public byte* comment;
		public uint comm_max;
		public int hcrc;
		public int done;
		}
		[StructLayout(LayoutKind.Sequential)]
		public struct gzFile_s
	{
		public uint have;
		public byte* next;
		public long pos;
		}
		[StructLayout(LayoutKind.Sequential)]
		public struct gz_state
	{
		public gzFile_s x;
		public int mode;
		public int fd;
		public sbyte* path;
		public uint size;
		public uint want;
		public byte* _in_;
		public byte* _out_;
		public int direct;
		public int how;
		public long start;
		public int eof;
		public int past;
		public int level;
		public int strategy;
		public long skip;
		public int seek;
		public int err;
		public string msg;
		public z_stream_s strm;
		}
		public static sbyte* zlibVersion()
		{
			return "1.2.11";
		}

		public static int zlibCompileFlags()
		{
			int flags = 0;
			flags = (int)(0);
			switch ((int)(sizeof(uint))){
case 2:break;case 4:flags += (int)(1);break;case 8:flags += (int)(2);break;default: flags += (int)(3);}

			switch ((int)(sizeof(int))){
case 2:break;case 4:flags += (int)(1 << 2);break;case 8:flags += (int)(2 << 2);break;default: flags += (int)(3 << 2);}

			switch ((int)(sizeof(void *))){
case 2:break;case 4:flags += (int)(1 << 4);break;case 8:flags += (int)(2 << 4);break;default: flags += (int)(3 << 4);}

			switch ((int)(sizeof(z_off_t))){
case 2:break;case 4:flags += (int)(1 << 6);break;case 8:flags += (int)(2 << 6);break;default: flags += (int)(3 << 6);}

			return (int)(flags);
		}

		public static sbyte* zError(int err)
		{
			return z_errmsg[2 - (err)];
		}

		public static void * zcalloc(void * opaque, uint items, uint size)
		{
			(void)(opaque);
			return (sizeof(uint)) > (2)?malloc((ulong)(items * size)):calloc((ulong)(items), (ulong)(size));
		}

		public static void zcfree(void * opaque, void * ptr)
		{
			(void)(opaque);
			free(ptr);
		}

}
}