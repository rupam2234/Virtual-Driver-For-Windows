using System;

namespace VIRTUAL_DRIVE_FOR_WINDOWS
{
    class MainPrograme 
    {
        static void Main(string[] args)
        {
            // to creata a new dir from which we will create virtual drive
            CreateDirectory createDirectory = new CreateDirectory();
            //createDirectory.createDirForVirtualDrive("OStoreTest");

            // to mount virtual drive and unmount it
            ConfigureVirtualDrive configureDrive = new ConfigureVirtualDrive();
            configureDrive.MapNewDrive('z', createDirectory.createDirForVirtualDrive("OStoreTest"));
            Console.WriteLine(configureDrive.GetDriveMapping('z'));

            // to unmount apply this
            //configureDrive.UnmapDrive('z');

            // to create sub directory in the virtual drive
            CreateDirInVirtualDrive createDir = new CreateDirInVirtualDrive();
            createDir.CreateDirInVirtualD("FolderA", "ChildA");
            createDir.CreateDirInVirtualD("FolderB", "ChildB");

            // to create a file in the child folder inside virtual drive
            CreateNewFile newFile = new CreateNewFile();
            newFile.CreateNewFileMethod("TestFile.csv");

        }
    }
}



/*@"C:\Users\RUPAM\Desktop\Ostore*/
