using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32
{
	public static partial class g
	{
		// https://github.com/File-New-Project/EarTrumpet/blob/master/EarTrumpet/Services/AccentColorService.cs, 2017-06-29.
		// https://www.quppa.net/blog/2013/01/02/retrieving-windows-8-theme-colours/, 2017-08-02.

		[DllImport("uxtheme.dll", EntryPoint = "#94", CharSet = CharSet.Unicode)]
		public static extern int GetImmersiveColorSetCount();

		[DllImport("uxtheme.dll", EntryPoint = "#95", CharSet = CharSet.Unicode)]
		public static extern int GetImmersiveColorFromColorSetEx(int dwImmersiveColorSet, int dwImmersiveColorType, bool bIgnoreHighContrast, int dwHighContrastCacheMode);

		[DllImport("uxtheme.dll", EntryPoint = "#96", CharSet = CharSet.Unicode)]
		public static extern int GetImmersiveColorTypeFromName(string name);

		[DllImport("uxtheme.dll", EntryPoint = "#98", CharSet = CharSet.Unicode)]
		public static extern int GetImmersiveUserColorSetPreference(bool bForceCheckRegistry, bool bSkipCheckOnFail);

		[DllImport("uxtheme.dll", EntryPoint = "#100", CharSet = CharSet.Unicode)]
		public static extern IntPtr GetImmersiveColorNamedTypeByIndex(int dwIndex);
	}
}
