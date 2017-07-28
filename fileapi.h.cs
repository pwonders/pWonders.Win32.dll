using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
	public static partial class g
	{
		[DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		public static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, int dwShareMode, IntPtr lpSecurityAttributes, int dwCreationDisposition, int dwFlagsAndAttributes, IntPtr hTemplateFile);

		public const uint GENERIC_READ = 0x80000000;
		public const uint GENERIC_WRITE = 0x40000000;
		public const int FILE_SHARE_READ = 0x00000001;
		public const int FILE_SHARE_WRITE = 0x00000002;
		public const int OPEN_EXISTING = 3;
		public const int FILE_ATTRIBUTE_NORMAL = 0x00000080;
	}
}
