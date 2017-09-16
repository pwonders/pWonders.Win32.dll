using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.Win32
{
	public static partial class API
	{
		public const int INVALID_HANDLE_VALUE = -1;

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr CloseHandle(IntPtr hObject);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int GetPrivateProfileString
		(
			string lpAppName,
			string lpKeyName,
			string lpDefault,
			[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] char[] lpReturnedString,
			int nSize,
			string lpFileName
		);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool WritePrivateProfileString
		(
			string lpAppName,
			string lpKeyName,
			string lpString,
			string lpFileName
		);
	}
}
