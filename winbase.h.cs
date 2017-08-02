using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
	public static partial class API
	{
		public const int INVALID_HANDLE_VALUE = -1;

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr CloseHandle(IntPtr hObject);

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern uint GetPrivateProfileString
		(
			string lpAppName,
			string lpKeyName,
			string lpDefault,
			IntPtr lpReturnedString,
			uint nSize,
			string lpFileName
		);

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WritePrivateProfileString
		(
			string lpAppName,
			string lpKeyName,
			string lpString,
			string lpFileName
		);
	}
}
