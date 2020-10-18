
namespace ZlibSharp
{
	public unsafe delegate void* zalloc_delegate(void* opaque, uint count, uint elementSize);

	public unsafe delegate void zfree_delegate(void* opaque, void* ptr);

	public unsafe delegate block_state deflate_func(ZUtil.internal_state state, int flush);

	public unsafe delegate uint inflate_func(void* in_desc, byte** next);
}
