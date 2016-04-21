using System;
using Microsoft.Win32;

namespace ForcesOfCorruptionModdingTool.EditorCore.RegistryHelper
{
    public static class RegistryHelper
    {
        public static object GetValueFromKey(RegistryRootTypes types, string path, string key)
        {
            try
            {
                switch (types)
                {
                    case RegistryRootTypes.HkClassesRoot:
                        return
                            Registry.ClassesRoot.OpenSubKey(path, RegistryKeyPermissionCheck.ReadSubTree)?
                                    .GetValue(key, null);
                    case RegistryRootTypes.HkCurrentUser:
                        return
                            Registry.CurrentUser.OpenSubKey(path, RegistryKeyPermissionCheck.ReadSubTree)?
                                    .GetValue(key, null);
                    case RegistryRootTypes.HkLocalMachine:
                        return
                            Registry.LocalMachine.OpenSubKey(path, RegistryKeyPermissionCheck.ReadSubTree)?
                                    .GetValue(key, null);
                    case RegistryRootTypes.HkUsers:
                        return
                            Registry.Users.OpenSubKey(path, RegistryKeyPermissionCheck.ReadSubTree)?
                                    .GetValue(key, null);
                    case RegistryRootTypes.KhCurrentConfig:
                        return
                            Registry.CurrentConfig.OpenSubKey(path, RegistryKeyPermissionCheck.ReadSubTree)?
                                    .GetValue(key, null);
                    default:
                        throw new ArgumentOutOfRangeException(nameof(types), types, null);
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
