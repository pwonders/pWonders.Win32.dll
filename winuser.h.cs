using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.Win32
{
	public static partial class g
	{
		[DllImport("user32.dll", SetLastError = true)]
		public static extern int GetRawInputDeviceList([In, Out] RAWINPUTDEVICELIST[] pRawInputDeviceList, ref int puiNumDevices, int cbSize);

		[StructLayout(LayoutKind.Sequential)]
		public struct RAWINPUTDEVICELIST
		{
			public IntPtr hDevice;
			public int dwType;
		}

		public const int RIM_TYPEMOUSE = 0;
		public const int RIM_TYPEKEYBOARD = 1;
		public const int RIM_TYPEHID = 2;

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		public static extern int GetRawInputDeviceInfo(IntPtr hDevice, int uiCommand, IntPtr pData, ref int pcbSize);
		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		public static extern int GetRawInputDeviceInfo(IntPtr hDevice, int uiCommand, StringBuilder pData, ref int pcbSize);
		[DllImport("user32.dll", SetLastError = true)]
		public static extern int GetRawInputDeviceInfo(IntPtr hDevice, int uiCommand, ref RID_DEVICE_INFO pData, ref int pcbSize);

		public const int RIDI_PREPARSEDDATA = 0x20000005;
		public const int RIDI_DEVICENAME = 0x20000007;
		public const int RIDI_DEVICEINFO = 0x2000000b;

		[StructLayout(LayoutKind.Explicit)]
		public struct RID_DEVICE_INFO
		{
			[FieldOffset(0)]
			public int cbSize;
			[FieldOffset(4)]
			public int dwType;
			[FieldOffset(8)]
			public RID_DEVICE_INFO_MOUSE mouse;
			[FieldOffset(8)]
			public RID_DEVICE_INFO_KEYBOARD keyboard;
			[FieldOffset(8)]
			public RID_DEVICE_INFO_HID hid;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RID_DEVICE_INFO_MOUSE
		{
			public int dwId;
			public int dwNumberOfButtons;
			public int dwSampleRate;
			public int fHasHorizontalWheel;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RID_DEVICE_INFO_KEYBOARD
		{
			public int dwType;
			public int dwSubType;
			public int dwKeyboardMode;
			public int dwNumberOfFunctionKeys;
			public int dwNumberOfIndicators;
			public int dwNumberOfKeysTotal;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RID_DEVICE_INFO_HID
		{
			public int dwVendorId;
			public int dwProductId;
			public int dwVersionNumber;
			public ushort usUsagePage;
			public ushort usUsage;
		}

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool RegisterRawInputDevices(RAWINPUTDEVICE[] pRawInputDevices, int uiNumDevices, int cbSize);

		[StructLayout(LayoutKind.Sequential)]
		public struct RAWINPUTDEVICE
		{
			public ushort usUsagePage;
			public ushort usUsage;
			public int dwFlags;
			public IntPtr hwndTarget;
		}

		public const ushort HID_USAGE_PAGE_GENERIC = 0x01;
		public const ushort HID_USAGE_GENERIC_MOUSE = 0x02;
		public const ushort HID_USAGE_GENERIC_KEYBOARD = 0x06;

		public const int RIDEV_REMOVE = 0x00000001;
		public const int RIDEV_EXCLUDE = 0x00000010;
		public const int RIDEV_PAGEONLY = 0x00000020;
		public const int RIDEV_NOLEGACY = 0x00000030;
		public const int RIDEV_INPUTSINK = 0x00000100;
		public const int RIDEV_CAPTUREMOUSE = 0x00000200;
		public const int RIDEV_NOHOTKEYS = 0x00000200;
		public const int RIDEV_APPKEYS = 0x00000400;
		public const int RIDEV_EXINPUTSINK = 0x00001000;
		public const int RIDEV_DEVNOTIFY = 0x00002000;

		public const int WM_INPUT_DEVICE_CHANGE = 0x00FE;
		public const int GIDC_ARRIVAL = 1;
		public const int GIDC_REMOVAL = 2;
		public const int WM_INPUT = 0x00FF;

		[DllImport("user32.dll", SetLastError = true)]
		public static extern int GetRawInputData(IntPtr hRawInput, int uiCommand, ref RAWINPUTHEADER pData, ref int pcbSize, int cbSizeHeader);
		[DllImport("user32.dll", SetLastError = true)]
		public static extern int GetRawInputData(IntPtr hRawInput, int uiCommand, IntPtr pData, ref int pcbSize, int cbSizeHeader);

		public const int RID_HEADER = 0x10000005;
		public const int RID_INPUT = 0x10000003;

		[StructLayout(LayoutKind.Explicit)]
		public struct RAWINPUT
		{
			[FieldOffset(0)]
			public RAWINPUTHEADER header;
			[FieldOffset(16)]
			public RAWMOUSE mouse;
			[FieldOffset(16)]
			public RAWKEYBOARD keyboard;
			[FieldOffset(16)]
			public RAWHID hid;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RAWINPUTHEADER
		{
			public int dwType;
			public int dwSize;
			public IntPtr hDevice;
			public IntPtr wParam;
		}

		[StructLayout(LayoutKind.Explicit)]
		public struct RAWMOUSE
		{
			[FieldOffset(0)]
			public ushort usFlags;
			[FieldOffset(2)]
			public uint ulButtons;
			[FieldOffset(2)]
			public ushort usButtonFlags;
			[FieldOffset(4)]
			public ushort usButtonData;
			[FieldOffset(6)]
			public int ulRawButtons;
			[FieldOffset(10)]
			public int lLastX;
			[FieldOffset(14)]
			public int lLastY;
			[FieldOffset(18)]
			public int ulExtraInformation;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RAWKEYBOARD
		{
			public ushort MakeCode;
			public ushort Flags;
			public ushort Reserved;
			public ushort VKey;
			public int Message;
			public int ExtraInformation;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RAWHID
		{
			int dwSizeHid;
			int dwCount;
			/*[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			byte[] bRawData;*/
		}

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool SystemParametersInfo(int uiAction, int uiParam, IntPtr pvParam, int fWinIni);
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool SystemParametersInfo(int uiAction, int uiParam, ref int pvParam, int fWinIni);

		public const int SPI_GETWHEELSCROLLLINES = 0x0068;
		public const int SPI_SETWHEELSCROLLLINES = 0x0069;
		public const int SPI_GETWHEELSCROLLCHARS = 0x006C;
		public const int SPI_SETWHEELSCROLLCHARS = 0x006D;

		public const int SPIF_UPDATEINIFILE = 1;
		public const int SPIF_SENDWININICHANGE = 2;
		public const int SPIF_SENDCHANGE = 2;

		public enum ColorTypes
		{
			COLOR_SCROLLBAR = 0,
			COLOR_BACKGROUND = 1,
			COLOR_ACTIVECAPTION = 2,
			COLOR_INACTIVECAPTION = 3,
			COLOR_MENU = 4,
			COLOR_WINDOW = 5,
			COLOR_WINDOWFRAME = 6,
			COLOR_MENUTEXT = 7,
			COLOR_WINDOWTEXT = 8,
			COLOR_CAPTIONTEXT = 9,
			COLOR_ACTIVEBORDER = 10,
			COLOR_INACTIVEBORDER = 11,
			COLOR_APPWORKSPACE = 12,
			COLOR_HIGHLIGHT = 13,
			COLOR_HIGHLIGHTTEXT = 14,
			COLOR_BTNFACE = 15,
			COLOR_BTNSHADOW = 16,
			COLOR_GRAYTEXT = 17,
			COLOR_BTNTEXT = 18,
			COLOR_INACTIVECAPTIONTEXT = 19,
			COLOR_BTNHIGHLIGHT = 20,

			COLOR_3DDKSHADOW = 21,
			COLOR_3DLIGHT = 22,
			COLOR_INFOTEXT = 23,
			COLOR_INFOBK = 24,

			Color_BtnAltFace = 25,  // Not officially defined.

			COLOR_HOTLIGHT = 26,
			COLOR_GRADIENTACTIVECAPTION = 27,
			COLOR_GRADIENTINACTIVECAPTION = 28,

			COLOR_MENUHILIGHT = 29,
			COLOR_MENUBAR = 30,
		}

		[DllImport("user32.dll")]
		public static extern Int32 GetSysColor(ColorTypes nIndex);

		[DllImport("user32.dll")]
		public static extern bool SetSysColors(int cElements, int[] lpaElements, int[] lpaRgbValues);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public int Left;
			public int Top;
			public int Right;
			public int Bottom;
		}

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

		[StructLayout(LayoutKind.Sequential)]
		public struct WINCOMPATTRDATA
		{
			public int attribute;
			public IntPtr pData;
			public int dataSize;
		}

		public const int WCA_ACCENT_POLICY = 19;

		[StructLayout(LayoutKind.Sequential)]
		public struct AccentPolicy
		{
			public int AccentState;
			public AccentFlags AccentFlags;
			public int GradientColor;
			public int AnimationId;
		}

		public const int ACCENT_DISABLED = 0;
		public const int ACCENT_ENABLE_GRADIENT = 1;
		public const int ACCENT_ENABLE_TRANSPARENTGRADIENT = 2;
		public const int ACCENT_ENABLE_BLURBEHIND = 3;
		public const int ACCENT_INVALID_STATE = 4;

		public enum AccentFlags
		{
			Unknown = 0x2,
			DrawLeftBorder = 0x20,
			DrawTopBorder = 0x40,
			DrawRightBorder = 0x80,
			DrawBottomBorder = 0x100,
			DrawAllBorders = (DrawLeftBorder | DrawTopBorder | DrawRightBorder | DrawBottomBorder),
		}

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool SetWindowCompositionAttribute(IntPtr hwnd, ref WINCOMPATTRDATA pAttrData);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);

		public const int HWND_TOP = 0;
		public const int HWND_BOTTOM = 1;
		public const int HWND_TOPMOST = -1;
		public const int HWND_NOTOPMOST = -2;

		public const int SWP_NOSIZE = 0x0001;
		public const int SWP_NOMOVE = 0x0002;
		public const int SWP_NOZORDER = 0x0004;
		public const int SWP_NOREDRAW = 0x0008;
		public const int SWP_NOACTIVATE = 0x0010;
		public const int SWP_FRAMECHANGED = 0x0020;
		public const int SWP_SHOWWINDOW = 0x0040;
		public const int SWP_HIDEWINDOW = 0x0080;
		public const int SWP_NOCOPYBITS = 0x0100;
		public const int SWP_NOOWNERZORDER = 0x0200;
		public const int SWP_DRAWFRAME = SWP_FRAMECHANGED;
		public const int SWP_NOREPOSITION = SWP_NOOWNERZORDER;
		public const int SWP_NOSENDCHANGING = 0x0400;
		public const int SWP_DEFERERASE = 0x2000;
		public const int SWP_ASYNCWINDOWPOS = 0x4000;

		[DllImport("user32.dll")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		public const int WM_NCHITTEST = 0x0084;

		public const int HTERROR = (-2);
		public const int HTTRANSPARENT = (-1);
		public const int HTNOWHERE = 0;
		public const int HTCLIENT = 1;
		public const int HTCAPTION = 2;
		public const int HTSYSMENU = 3;
		public const int HTGROWBOX = 4;
		public const int HTSIZE = HTGROWBOX;
		public const int HTMENU = 5;
		public const int HTHSCROLL = 6;
		public const int HTVSCROLL = 7;
		public const int HTMINBUTTON = 8;
		public const int HTMAXBUTTON = 9;
		public const int HTLEFT = 10;
		public const int HTRIGHT = 11;
		public const int HTTOP = 12;
		public const int HTTOPLEFT = 13;
		public const int HTTOPRIGHT = 14;
		public const int HTBOTTOM = 15;
		public const int HTBOTTOMLEFT = 16;
		public const int HTBOTTOMRIGHT = 17;
		public const int HTBORDER = 18;
		public const int HTREDUCE = HTMINBUTTON;
		public const int HTZOOM = HTMAXBUTTON;
		public const int HTSIZEFIRST = HTLEFT;
		public const int HTSIZELAST = HTBOTTOMRIGHT;
		public const int HTOBJECT = 19;
		public const int HTCLOSE = 20;
		public const int HTHELP = 21;
	}
}
