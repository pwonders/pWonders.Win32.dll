using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
	public static partial class API
	{
		[DllImport("shell32.dll", CharSet = CharSet.Auto)]
		public static extern int SHGetFileInfo(string pszPath, int dwFileAttributes, out SHFILEINFO psfi, int cbFileInfo, int flags);

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SHFILEINFO
		{
			public IntPtr hIcon;
			public int iIcon;
			public int dwAttributes;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string szDisplayName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
			public string szTypeName;
		}

		public const int SHGFI_DISPLAYNAME = 0x000000200;
	}
}
