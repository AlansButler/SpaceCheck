using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Web;

namespace SpaceCheck
{
	public class WNetWrapper
	{

		// Maps the NETRESOURCE structure defined in winnetwk.h and used by WNetAddConnection2A.
		/*
		[StructLayout(LayoutKind.Sequential)]
		public struct NetResource
		{
			public Int32 dwScope;
			public Int32 dwType;
			public Int32 dwDisplayType;
			public Int32 dwUsage;
			public String lpLocalName;
			public String lpRemoteName;
			public String lpComment;
			public String lpProvider;
		}
		 */

		/*

		//https://support.microsoft.com/en-us/kb/173011
		public const int RESOURCETYPE_DISK = 1;
    public const int  RESOURCETYPE_PRINT = 2;
    public const int  RESOURCETYPE_ANY = 0;
    public const int  RESOURCE_CONNECTED = 1;
    public const int  RESOURCE_REMEMBERED = 3;
    public const int  RESOURCE_GLOBALNET = 2;
    public const int  RESOURCEDISPLAYTYPE_DOMAIN = 1;
    public const int  RESOURCEDISPLAYTYPE_GENERIC = 0;
    public const int  RESOURCEDISPLAYTYPE_SERVER = 2;
    public const int  RESOURCEDISPLAYTYPE_SHARE = 3;
    public const int  RESOURCEUSAGE_CONNECTABLE = 1;
    public const int  RESOURCEUSAGE_CONTAINER = 2;
		//Error Constants:
    public const int ERROR_ACCESS_DENIED = 5;
    public const int ERROR_ALREADY_ASSIGNED = 85;
    public const int ERROR_BAD_DEV_TYPE = 66;
    public const int ERROR_BAD_DEVICE = 1200;
    public const int ERROR_BAD_NET_NAME = 67;
    public const int ERROR_BAD_PROFILE = 1206;
    public const int ERROR_BAD_PROVIDER = 1204;
    public const int ERROR_BUSY = 170;
    public const int ERROR_CANCELLED = 1223;
    public const int ERROR_CANNOT_OPEN_PROFILE = 1205;
    public const int ERROR_DEVICE_ALREADY_REMEMBERED = 1202;
    public const int ERROR_EXTENDED_ERROR = 1208;
    public const int ERROR_INVALID_PASSWORD = 86;
    public const int ERROR_NO_NET_OR_BAD_PATH = 1203;

		//http://www.cs.uofs.edu/~beidler/Ada/win32/win32-winnetwk.html

		 */ 
		/*
		[StructLayout(LayoutKind.Sequential)]
		public class NetResource
		{
			public int dwScope = 0;
			public int dwType = RESOURCETYPE_DISK;
			public int dwDisplayType = RESOURCEDISPLAYTYPE_SERVER;
			public int dwUsage = RESOURCEUSAGE_CONNECTABLE;

			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpLocalName;

			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpRemoteName = null;

			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpComment;

			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpProvider;
		};
		 */

		//declare the structures to hold info
		/*
		public enum RESOURCE_SCOPE
		{
			RESOURCE_CONNECTED = 0x00000001,
			RESOURCE_GLOBALNET = 0x00000002,
			RESOURCE_REMEMBERED = 0x00000003,
			RESOURCE_RECENT = 0x00000004,
			RESOURCE_CONTEXT = 0x00000005
		}


		public enum RESOURCE_TYPE
		{
			RESOURCETYPE_ANY = 0x00000000,
			RESOURCETYPE_DISK = 0x00000001,
			RESOURCETYPE_PRINT = 0x00000002,
			RESOURCETYPE_RESERVED = 0x00000008,
		}


		public enum RESOURCE_USAGE
		{
			RESOURCEUSAGE_CONNECTABLE = 0x00000001,
			RESOURCEUSAGE_CONTAINER = 0x00000002,
			RESOURCEUSAGE_NOLOCALDEVICE = 0x00000004,
			RESOURCEUSAGE_SIBLING = 0x00000008,
			RESOURCEUSAGE_ATTACHED = 0x00000010,
			RESOURCEUSAGE_ALL = (RESOURCEUSAGE_CONNECTABLE | RESOURCEUSAGE_CONTAINER | RESOURCEUSAGE_ATTACHED),
		}


		public enum RESOURCE_DISPLAYTYPE
		{
			RESOURCEDISPLAYTYPE_GENERIC = 0x00000000,
			RESOURCEDISPLAYTYPE_DOMAIN = 0x00000001,
			RESOURCEDISPLAYTYPE_SERVER = 0x00000002,
			RESOURCEDISPLAYTYPE_SHARE = 0x00000003,
			RESOURCEDISPLAYTYPE_FILE = 0x00000004,
			RESOURCEDISPLAYTYPE_GROUP = 0x00000005,
			RESOURCEDISPLAYTYPE_NETWORK = 0x00000006,
			RESOURCEDISPLAYTYPE_ROOT = 0x00000007,
			RESOURCEDISPLAYTYPE_SHAREADMIN = 0x00000008,
			RESOURCEDISPLAYTYPE_DIRECTORY = 0x00000009,
			RESOURCEDISPLAYTYPE_TREE = 0x0000000A,
			RESOURCEDISPLAYTYPE_NDSCONTAINER = 0x0000000B
		}


		public struct NETRESOURCE
		{
			public RESOURCE_SCOPE dwScope;
			public RESOURCE_TYPE dwType;
			public RESOURCE_DISPLAYTYPE dwDisplayType;
			public RESOURCE_USAGE dwUsage;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)]
			public string lpLocalName;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)]
			public string lpRemoteName;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)]
			public string lpComment;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)]
			public string lpProvider;
		}

		 /* 
		//here's some possible error codes
		public enum NERR
		{
			NERR_Success = 0, // Success 
			ERROR_MORE_DATA = 234, // dderror
			ERROR_NO_BROWSER_SERVERS_FOUND = 6118,
			ERROR_INVALID_LEVEL = 124,
			ERROR_ACCESS_DENIED = 5,
			ERROR_INVALID_PARAMETER = 87,
			ERROR_NOT_ENOUGH_MEMORY = 8,
			ERROR_NETWORK_BUSY = 54,
			ERROR_BAD_NETPATH = 53,
			ERROR_NO_NETWORK = 1222,
			ERROR_INVALID_HANDLE_STATE = 1609,
			ERROR_EXTENDED_ERROR = 1208
		}
	*/

		/*
		[StructLayout(LayoutKind.Sequential)]
		public class NETRESOURCE
		{
			public int dwScope;
			public int dwType;
			public int dwDisplayType;
			public int dwUsage;
			public string LocalName;
			public string RemoteName;
			public string Comment;
			public string Provider;
		}
		*/


		// Maps the WNetOpenEnum method defined in winnetwk.h and exposed in mpr.dll.
		/*
		[DllImport("Mpr.dll", EntryPoint = "WNetOpenEnumA", CallingConvention = CallingConvention.Winapi)]
		public static extern int WNetOpenEnum(uint dwScope, uint dwType, uint dwUsage, NETRESOURCE netResource, out IntPtr lphEnum);
		 */ 

		/*
		[DllImport("mpr.dll", CharSet = CharSet.Auto)]
		public static extern int WNetOpenEnum(RESOURCE_SCOPE dwScope, RESOURCE_TYPE dwType, RESOURCE_USAGE dwUsage,
					[MarshalAs(UnmanagedType.AsAny)][In] Object lpNetResource, out IntPtr lphEnum);
		 */ 

		/*
				[DllImport("MPR.dll", CharSet = CharSet.Auto)]
				public static extern int WNetOpenEnum(RESOURCE_SCOPE dwScope, RESOURCE_TYPE dwType, RESOURCE_USAGE dwUsage,
						[MarshalAs(UnmanagedType.AsAny)][In] object lpNetResource, out IntPtr lphEnum);
		 
				*/

		[DllImport("mpr.dll", CharSet = CharSet.Ansi)]
		public static extern int WNetOpenEnum(
			RESOURCE_SCOPE dwScope,
			RESOURCE_TYPE dwType,
			RESOURCE_USAGE dwUsage,
			ref NetResource netResource,
			out IntPtr lphEnum);

		/*
		[DllImport("MPR.dll", CharSet = CharSet.Ansi)]
		public static extern int WNetOpenEnum(RESOURCE_SCOPE dwScope, RESOURCE_TYPE dwType, RESOURCE_USAGE dwUsage,
				ref NetResource netResource, ref Int32 lphEnum);
		*/

		/* LIke UNC.cs*/
		/*
		  [DllImport("mpr.dll")]
			public static extern Int32 WNetOpenEnum(Int32 dwScope, Int32 dwType, Int32 dwUsage,
      ref NetResource lpNetResource, ref Int32 lphEnum);
		*/

		/* http://stackoverflow.com/questions/1898195/mapped-network-drives-cannot-be-listed-in-c-sharp */

		// Maps the WNetEnumResource method defined in winnetwk.h and exposed in mpr.dll.
		/*
		[DllImport("Mpr.dll", EntryPoint = "WNetEnumResourceA", CallingConvention = CallingConvention.Winapi)]
		public static extern int WNetEnumResource(IntPtr hEnum, ref uint lpcCount, IntPtr buffer, ref uint lpBufferSize);
		 */ 

		[DllImport("MPR.dll", CharSet = CharSet.Ansi)]
		public static extern Int32 WNetEnumResource(Int64 hEnum, ref Int32 lpcCount, IntPtr lpBuffer, ref Int32 lpBufferSize);

/*  declare the DLL import functions  using object https://www.planet-source-code.com/vb/scripts/ShowCode.asp?txtCodeId=741&lngWId=10
		[DllImport("mpr.dll", CharSet=CharSet.Auto)]
		public static extern int WNetEnumResource(IntPtr hEnum, ref int lpcCount,	IntPtr lpBuffer, ref int lpBufferSize );
		
 */

		// Maps the WNetAddConnection2A method defined in winnetwk.h and exposed in mpr.dll.
		/*
    [DllImport("mpr.dll")]
    public static extern uint WNetAddConnection2A(ref NetResource lpNetResource, String lpPassword, String lpUsername, uint dwFlags);

		[DllImport("mpr.dll", EntryPoint = "WNetAddConnection2", CharSet = System.Runtime.InteropServices.CharSet.Unicode, SetLastError = true)]  //CharSet.AUto
		public static extern int WNetAddConnection2(ref NetResource netResource, string password, string username, int flags);
		 */ 

		[DllImport("mpr.dll")]
		public static extern int WNetAddConnection2(ref NetResource lpNetResource, 
																								[In, MarshalAs(UnmanagedType.LPTStr)] string password, 
																								[In, MarshalAs(UnmanagedType.LPTStr)] string username, 
																								uint flags);
		
		/*
			[DllImport("mpr.dll", CharSet = CharSet.Ansi)]
			public static extern int WNetAddConnection2([MarshalAs(UnmanagedType.LPArray)] NetResource[] lpNetResource,
																									[MarshalAs(UnmanagedType.LPStr)] string lpPassword,
																									[MarshalAs(UnmanagedType.LPStr)] string lpUsername,
																									uint flags);
		*/


		// Maps the WNetCloseEnum method defined in winnetwk.h and exposed in mpr.dll.
		/*
    [DllImport("mpr.dll")]
    public static extern Int32 WNetCloseEnum(Int32 hEnum);
		 */ 

		/*
		[DllImport("Mpr.dll", EntryPoint = "WNetCloseEnum", CallingConvention = CallingConvention.Winapi)]
		public static extern int WNetCloseEnum(IntPtr hEnum);
		*/

		[DllImport("mpr.dll", CharSet = CharSet.Ansi)]
		public static extern int WNetCloseEnum(IntPtr hEnum);


		public enum RESOURCE_SCOPE : uint
		{
			RESOURCE_CONNECTED = 0x00000001,
			RESOURCE_GLOBALNET = 0x00000002,
			RESOURCE_REMEMBERED = 0x00000003,
			RESOURCE_RECENT = 0x00000004,
			RESOURCE_CONTEXT = 0x00000005,
		}
		public enum RESOURCE_TYPE : uint
		{
			RESOURCETYPE_ANY = 0x00000000,
			RESOURCETYPE_DISK = 0x00000001,
			RESOURCETYPE_PRINT = 0x00000002,
			RESOURCETYPE_RESERVED = 0x00000008,
		}
		public enum RESOURCE_USAGE : uint
		{
			RESOURCEUSAGE_CONNECTABLE = 0x00000001,
			RESOURCEUSAGE_CONTAINER = 0x00000002,
			RESOURCEUSAGE_NOLOCALDEVICE = 0x00000004,
			RESOURCEUSAGE_SIBLING = 0x00000008,
			RESOURCEUSAGE_ATTACHED = 0x00000010,
			RESOURCEUSAGE_ALL = (RESOURCEUSAGE_CONNECTABLE | RESOURCEUSAGE_CONTAINER | RESOURCEUSAGE_ATTACHED),
		}
		public enum RESOURCE_DISPLAYTYPE : uint
		{
			RESOURCEDISPLAYTYPE_GENERIC = 0x00000000,
			RESOURCEDISPLAYTYPE_DOMAIN = 0x00000001,
			RESOURCEDISPLAYTYPE_SERVER = 0x00000002,
			RESOURCEDISPLAYTYPE_SHARE = 0x00000003,
			RESOURCEDISPLAYTYPE_FILE = 0x00000004,
			RESOURCEDISPLAYTYPE_GROUP = 0x00000005,
			RESOURCEDISPLAYTYPE_NETWORK = 0x00000006,
			RESOURCEDISPLAYTYPE_ROOT = 0x00000007,
			RESOURCEDISPLAYTYPE_SHAREADMIN = 0x00000008,
			RESOURCEDISPLAYTYPE_DIRECTORY = 0x00000009,
			RESOURCEDISPLAYTYPE_TREE = 0x0000000A,
			RESOURCEDISPLAYTYPE_NDSCONTAINER = 0x0000000B
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct NetResource
		{
			public RESOURCE_SCOPE dwScope;
			public RESOURCE_TYPE dwType;
			public RESOURCE_DISPLAYTYPE dwDisplayType;
			public RESOURCE_USAGE dwUsage;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]
			public string lpLocalName;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]  //Marshal here works for WNetEnumOpenEnum and WNetEnumResource but not WNetAddConnection2
			public String lpRemoteName;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]
			public string lpComment;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]
			public string lpProvider;
		}

		/*
		[StructLayout(LayoutKind.Sequential)]
		public struct NetResourceForAdd
		{
			public RESOURCE_SCOPE dwScope;
			public RESOURCE_TYPE dwType;
			public RESOURCE_DISPLAYTYPE dwDisplayType;
			public RESOURCE_USAGE dwUsage;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)]
			public string lpLocalName;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)]  //Marshal here works for WNetEnumOpenEnum and WNetEnumResource but not WNetAddConnection2
			public string lpRemoteName;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)]
			public string lpComment;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)]
			public string lpProvider;
		}
		*/

	}
}
