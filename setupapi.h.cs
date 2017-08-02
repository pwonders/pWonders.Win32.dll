using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.Win32
{
	public static partial class API
	{
		[DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
		public static extern IntPtr SetupOpenInfFile(string FileName, string InfClass, int InfStyle, IntPtr ErrorLine);

		public const int INF_STYLE_OLDNT = 0x00000001;
		public const int INF_STYLE_WIN4 = 0x00000002;

		[DllImport("setupapi.dll", SetLastError = true)]
		public static extern void SetupCloseInfFile(IntPtr InfHandle);

		[DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
		public static extern bool SetupGetLineText(IntPtr Context, IntPtr InfHandle, string Section, string Key, IntPtr ReturnBuffer, int ReturnBufferSize, ref int RequiredSize);
		[DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
		public static extern bool SetupGetLineText(IntPtr Context, IntPtr InfHandle, string Section, string Key, StringBuilder ReturnBuffer, int ReturnBufferSize, IntPtr RequiredSize);
	}
}
