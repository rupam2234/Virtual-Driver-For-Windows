
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace VIRTUAL_DRIVE_FOR_WINDOWS
{
    // method to setup the virtual drive
    // we will also use the created directory to generate a virtual drive

    public class ConfigureVirtualDrive : CreateDirectory
    {

        public void MapNewDrive(char letter, string path)
        {
            if (!DefineDosDevice(0, SetDriveLatter(letter), path))
                throw new Win32Exception();
        }

        public string GetDriveMapping(char letter)
        {
            var newDrive = new StringBuilder(259);
            if (QueryDosDevice(SetDriveLatter(letter), newDrive, newDrive.Capacity) == 0)
            {
                // Return empty string if the drive is not mapped
                int error = Marshal.GetLastWin32Error();
                if (error == 2) return " ";
                throw new Win32Exception();
            }
            return newDrive.ToString().Substring(4);
        }

        private string SetDriveLatter(char letter)
        {
            // we can change this to name the drive as Ostore (Now set to Uppercase Character)
            return new string(char.ToUpper(letter), 1) + ":";
        }

        // to unmount the virtual drive
        public void UnmapDrive(char letter)
        {
            if (!DefineDosDevice(2, SetDriveLatter(letter), null))
                throw new Win32Exception();
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool DefineDosDevice(int flags, string driveName, string folderPath);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int QueryDosDevice(string driveName, StringBuilder buffer, int bufferSize);

    }
}
