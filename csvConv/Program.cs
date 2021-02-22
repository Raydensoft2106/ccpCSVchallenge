using System;
using System.IO;
using System.Text;

namespace csvConv
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your file location ");

            string FilePath = Convert.ToString(Console.ReadLine());

            FileInfo fi = new FileInfo(FilePath);
            // Get File Name      
            string justFileName = fi.Name; Console.WriteLine("File Name: {0}", justFileName);
            // Get file name with full path      
            string fullFileName = fi.FullName; Console.WriteLine("File Name: {0}", fullFileName);
            // Get file extension      
            string extn = fi.Extension; Console.WriteLine("File Extension: {0}", extn);
            // Get directory name      
            string directoryName = fi.DirectoryName; Console.WriteLine("Directory Name: {0}", directoryName);
            // File Exists ?      
            bool exists = fi.Exists;
            Console.WriteLine("File Exists: {0}", exists);
            if (fi.Exists)
            {
                // Get file size      
                long size = fi.Length;
                Console.WriteLine("File Size in Bytes: {0}", size);
                // File ReadOnly ?      
                bool IsReadOnly = fi.IsReadOnly; Console.WriteLine("Is ReadOnly: {0}", IsReadOnly);
                // Creation, last access, and last write time      
                DateTime creationTime = fi.CreationTime;
                Console.WriteLine("Creation time: {0}", creationTime);
                DateTime accessTime = fi.LastAccessTime;
                Console.WriteLine("Last access time: {0}", accessTime);
                DateTime updatedTime = fi.LastWriteTime;
                Console.WriteLine("Last write time: {0}", updatedTime);
            }

            Console.WriteLine("Please enter the extension you want to convert to:" +
                "\n1.JSON" +
                "\n2.XML");
            string Selection = Convert.ToString(Console.ReadLine());

            switch (Selection)
            {
                case "1":
                    Console.WriteLine("To CSV");

                    string[] lines = System.IO.File.ReadAllLines(FilePath);
                    String csvFileStr = string.Join("", lines);
                    Console.WriteLine(csvFileStr);

                    var input = CSVReader.ReadFromString(csvFileStr);// C:\Users\rossh\Desktop\sample.csv
                    
                    break;
                case "2":
                    Console.WriteLine("To XML");
                    //writeToXML();
                    break;
                default:
                    Console.WriteLine("Not a vowel");
                    break;
            }
        }
    }
}
