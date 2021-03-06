using System;
using System.Text;

namespace LibuvSharp
{
	public static class IUVStreamExtensions
	{
		public static void Read(this IUVStream stream, Encoding enc, Action<string> callback)
		{
			stream.Data += (data) => callback(enc.GetString(data.Array, data.Offset, data.Count));
		}

		public static void Write(this IUVStream stream, byte[] data, int index, int count)
		{
			stream.Write(data, index, count, null);
		}

		public static void Write(this IUVStream stream, byte[] data, int count, Action<bool> callback)
		{
			stream.Write(data, 0, count, callback);
		}
		public static void Write(this IUVStream stream, byte[] data, int count)
		{
			stream.Write(data, count, null);
		}

		public static void Write(this IUVStream stream, byte[] data, Action<bool> callback)
		{
			stream.Write(data, data.Length, callback);
		}
		public static void Write(this IUVStream stream, byte[] data)
		{
			stream.Write(data, null);
		}

		public static void Write(this IUVStream stream, ArraySegment<byte> data, Action<bool> callback)
		{
			stream.Write(data.Array, data.Offset, data.Count, callback);
		}
		public static void Write(this IUVStream stream, ArraySegment<byte> data)
		{
			stream.Write(data, null);
		}

		public static int Write(this IUVStream stream, Encoding enc, string text, Action<bool> callback)
		{
			var bytes = enc.GetBytes(text);
			stream.Write(bytes, callback);
			return bytes.Length;
		}
		public static int Write(this IUVStream stream, Encoding enc, string text)
		{
			return stream.Write(enc, text, null);
		}

		public static void Shutdown(this IUVStream stream)
		{
			stream.Shutdown(null);
		}
	}
}

