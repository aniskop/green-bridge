using System;
using System.Runtime.InteropServices;

namespace GreenBridge.Core
{
    #region SYS callbacks
    public delegate int SysVersionCallback();

    public delegate IntPtr SysRegistryCallback();

    public delegate IntPtr SysRootDirCallback();

    public delegate IntPtr SysOracleHomeCallback();

    public delegate IntPtr SysOciDllCallback();

    [return: MarshalAs(UnmanagedType.Bool)]
    public delegate bool SysOci8ModeCallback();

    public delegate IntPtr SysXPStyleCallback();

    public delegate IntPtr SysTnsNamesCallback(string alias);

    public delegate IntPtr SysDelphiVersionCallback();
    #endregion

    #region IDE callbacks

    #endregion

    #region SQL callbacks
    #endregion

    public class Callback
    {
        private Callback()
        {

        }

        #region SYS callbacks indexes
        public const int SYS_VERSION = 1;
        public const int SYS_REGISTRY = 2;
        public const int SYS_ROOT_DIR = 3;
        public const int SYS_ORACLE_HOME = 4;
        public const int SYS_OCI_DLL = 5;
        public const int SYS_OCI8_MODE = 6;
        public const int SYS_XP_STYLE = 7;
        public const int SYS_TNS_NAMES = 8;
        public const int SYS_DELPHI_VERSION = 9;
        #endregion

        #region IDE callbacks indexes

        #endregion

        #region SQL callbacks indexes
        #endregion
    }
}
