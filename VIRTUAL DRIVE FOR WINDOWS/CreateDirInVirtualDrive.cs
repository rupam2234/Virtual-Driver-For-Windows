
using System.IO;


namespace VIRTUAL_DRIVE_FOR_WINDOWS
{
    // to create Directory and sub-directory inside the virtual Drive

    public class CreateDirInVirtualDrive : CreateDirectory
    {
        public void CreateDirInVirtualD(string DirName, string SubDirName)
        {

            // for creating directory in the virtual drive
            string VirtualDir = @"Z:\" + DirName;

            // for creating sub-Directory in the virtual drive 
            string VIrtualSubDir = @"z:\" + DirName + "\\" + SubDirName;

            // if directory not exist create one
            if (!Directory.Exists(VirtualDir))
            {
                Directory.CreateDirectory(VirtualDir);
            }

            // Create a sub directory
            if (!Directory.Exists(VIrtualSubDir))
            {
                Directory.CreateDirectory(VIrtualSubDir);
            }
        }
    }
}
