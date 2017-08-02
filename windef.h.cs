using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
	public static partial class API
	{
		[StructLayout(LayoutKind.Sequential)]
   		public struct RECT
		{
			public int left;
			public int top;
			public int right;
			public int bottom;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct POINT
		{
			int x;
			int y;
		}
	}
}
