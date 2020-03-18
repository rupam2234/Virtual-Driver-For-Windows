using System;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32.SafeHandles;

namespace VIRTUAL_DRIVE_FOR_WINDOWS
{

    public class ConfigureFiles
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        public static extern SafeFileHandle CreateFile(

           string configureFileName,
           [MarshalAs(UnmanagedType.U4)] FileAccess fileAccess,
           [MarshalAs(UnmanagedType.U4)] FileShare FileShare,
           IntPtr securityAttribute,
           [MarshalAs(UnmanagedType.U4)] FileMode fileMode,
           [MarshalAs(UnmanagedType.U4)] FileAttributes FlagsAndAttribute,
           IntPtr templateFile);
    }

    public class CreateNewFile : ConfigureFiles
    {

        // this method can help us to create any kind of file inside the drive (fileExtension Should Be Provide With Name)

        public void CreateNewFileMethod(string FilenameWithExtension)
        {
            SafeFileHandle handle = CreateFile("Z:\\FolderB\\ChildB\\" + FilenameWithExtension, FileAccess.Write, FileShare.ReadWrite, IntPtr.Zero, FileMode.Create, 0, IntPtr.Zero);
            SafeFileHandle handle2  = CreateFile("Z:\\FolderA\\ChildA\\" + FilenameWithExtension, FileAccess.Write, FileShare.ReadWrite, IntPtr.Zero, FileMode.Create, 0, IntPtr.Zero);

            if ((handle.IsInvalid) && (handle2.IsInvalid))
            {
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            }
        }

    }
}
  
