using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
	public static partial class API
	{
		// https://github.com/File-New-Project/EarTrumpet/blob/master/EarTrumpet/Services/AccentColorService.cs, 2017-06-29.
		// https://www.quppa.net/blog/2013/01/02/retrieving-windows-8-theme-colours/, 2017-08-02.

		[DllImport("uxtheme.dll", EntryPoint = "#94")]
		public static extern int GetImmersiveColorSetCount();

		[DllImport("uxtheme.dll", EntryPoint = "#95")]
		public static extern int GetImmersiveColorFromColorSetEx(int dwImmersiveColorSet, int dwImmersiveColorType, bool bIgnoreHighContrast, int dwHighContrastCacheMode);

		[DllImport("uxtheme.dll", EntryPoint = "#96", CharSet = CharSet.Unicode)]
		public static extern int GetImmersiveColorTypeFromName(string name);

		[DllImport("uxtheme.dll", EntryPoint = "#98")]
		public static extern int GetImmersiveUserColorSetPreference(bool bForceCheckRegistry, bool bSkipCheckOnFail);

		[DllImport("uxtheme.dll", EntryPoint = "#100")]
		public static extern IntPtr GetImmersiveColorNamedTypeByIndex(int dwIndex);

		// TODO: WM_THEMECHANGED, IsThemeActive.

		[DllImport("uxtheme.dll")]
		public static extern bool IsThemeActive();

		[DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
		public static extern IntPtr OpenThemeData(IntPtr hwnd, string pszClassList);

		[DllImport("uxtheme.dll")]
		public static extern int CloseThemeData(IntPtr hTheme);

		[DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
		public static extern int DrawThemeTextEx(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, string pszText, int iCharCount, int dwFlags, ref RECT pRect, ref DTTOPTS pOptions);

		[DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
		public extern static int GetThemeTextExtent(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, string pszText, int iCharCount, int dwTextFlags, IntPtr pBoundingRect, out RECT pExtentRect);

		[StructLayout(LayoutKind.Sequential)]
		public struct DTTOPTS
		{
			public int dwSize;
			public int dwFlags;
			public int crText;
			public int crBorder;
			public int crShadow;
			public int iTextShadowType;
			public POINT ptShadowOffset;
			public int iBorderSize;
			public int iFontPropId;
			public int iColorPropId;
			public int iStateId;
			public bool fApplyOverlay;
			public int iGlowSize;
			public IntPtr pfnDrawTextCallback;
			public IntPtr lParam;
		}
	}
}
