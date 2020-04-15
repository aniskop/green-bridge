using System;
using System.Runtime.InteropServices;

namespace GreenBridge.Core
{
    public class PlsqlDeveloperFacade
    {
        public PlsqlDeveloperFacade()
        {

        }
        /// <summary>
        /// Registers callback only if its index is in <paramref name="match"/>.
        /// </summary>
        /// <param name="callbackIndex"></param>
        /// <param name="func"></param>
        /// <param name="match"></param>
        public void RegisterCallback(int callbackIndex, IntPtr func, int[] match)
        {
            if (match != null && match.Length > 0)
            {
                for (int i = 0; i < match.Length; i++)
                {
                    if (match[i] == callbackIndex)
                    {
                        RegisterCallback(callbackIndex, func);
                        break;
                    }
                }
            }
        }
        public void RegisterCallback(int callbackIndex, IntPtr func)
        {
            switch (callbackIndex)
            {
                case Callback.SYS_VERSION:
                    sysVersion = Marshal.GetDelegateForFunctionPointer<SysVersionCallback>(func);
                    break;

                case Callback.SYS_REGISTRY:
                    sysRegistry = Marshal.GetDelegateForFunctionPointer<SysRegistryCallback>(func);
                    break;

                case Callback.SYS_ROOT_DIR:
                    sysRootDir = Marshal.GetDelegateForFunctionPointer<SysRootDirCallback>(func);
                    break;

                case Callback.SYS_ORACLE_HOME:
                    sysOracleHome = Marshal.GetDelegateForFunctionPointer<SysOracleHomeCallback>(func);
                    break;

                case Callback.SYS_OCI_DLL:
                    sysOciDll = Marshal.GetDelegateForFunctionPointer<SysOciDllCallback>(func);
                    break;

                default:
                    break;
            }
        }

        private SysVersionCallback sysVersion;
        public int SYS_Version()
        {
            if (sysVersion == null)
            {
                throw NotRegistered(typeof(SysVersionCallback));
            }
            return sysVersion();
        }

        private SysRegistryCallback sysRegistry;
        public string SYS_Registry()
        {
            if (sysRegistry == null)
            {
                throw NotRegistered(typeof(SysRegistryCallback));
            }
            return Marshal.PtrToStringAnsi(sysRegistry());
        }

        private SysRootDirCallback sysRootDir;
        public string SYS_RootDir()
        {
            if (sysRootDir == null)
            {
                throw NotRegistered(typeof(SysRootDirCallback));
            }
            return Marshal.PtrToStringAnsi(sysRootDir());
        }

        private SysOracleHomeCallback sysOracleHome;
        public string SYS_OracleHome()
        {
            if (sysOracleHome == null)
            {
                throw NotRegistered(typeof(SysOracleHomeCallback));
            }
            return Marshal.PtrToStringAnsi(sysOracleHome());
        }

        private SysOciDllCallback sysOciDll;
        public string SYS_OCIDLL()
        {
            if (sysOciDll == null)
            {
                throw NotRegistered(typeof(SysOciDllCallback));
            }
            return Marshal.PtrToStringAnsi(sysOciDll());
        }

        private SysOci8ModeCallback sysOci8Mode;
        public bool SYS_OCI8Mode()
        {
            if (sysOci8Mode == null)
            {
                throw NotRegistered(typeof(SysOci8ModeCallback));
            }
            return sysOci8Mode();
        }

        private NullReferenceException NotRegistered(Type t)
        {
            return new NullReferenceException("Callback " + t.Name + " is not registered thus cannot be called.");
        }


    }
}
