using System;
using System.IO;


namespace VIRTUAL_DRIVE_FOR_WINDOWS
{
    // using this folder we can create virtual drive 

    public class CreateDirectory
    {

        // to create folder for Mapping as a virtual Drive

        public string createDirForVirtualDrive(string Dirname)
        {
            string root = @"C:\Users\RUPAM\Desktop\" + Dirname;

            // If directory does not exist, create it. 
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
                Console.WriteLine("New Directory " + Dirname + " created !");
            }

            else if (Directory.Exists(root))
            {
                Console.WriteLine("Provided directory already exist in this loaction");
            }

            return root;
        }
    }
}
