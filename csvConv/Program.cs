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

            
            switch (extn)
            {
                case ".csv":
                    {
                        fromCSV(FilePath);
                        break;
                    }
                case ".json":
                    {
                        fromJSON(FilePath);
                        break;
                    }
                case ".xml":
                    {
                        fromXML(FilePath);
                        break;
                    }
            }
        }

        private static void fromCSV(string filePath)
        {
            Console.WriteLine("Please enter the extension you want to convert to:" +
        "\n1.JSON" +
        "\n2.XML");
            string Selection = Convert.ToString(Console.ReadLine());
            var contents = File.ReadAllText(filePath);

            switch (Selection)
            {
                case "1":
                    Console.WriteLine("To JSON");
                    //Filename: C:\Users\rossh\Desktop\sample.csv
                    //C:\Users\rossh\source\repos\csvConv\csvConv\bin\Debug\netcoreapp3.1\new_file3.json
                    //Attempt 1: Success

                    /**
                    var rootIn = CSVin.ReadFromString(contents);

                    var rootOut = JSONout.WriteToString(rootIn);
                    File.WriteAllText("new_file.json", rootOut);**/

                    //Attempt 2
                    var JSONString = JSONout.WriteToString(CSVin.ReadFromString(contents));
                    File.WriteAllText("new_file3.json", JSONString);
                    break;
                case "2":
                    Console.WriteLine("To XML");
                    var XMLString = XMLOut.WriteToString(CSVin.ReadFromString(contents));
                    File.WriteAllText("new_file3.xml", XMLString);
                    break;
                default:
                    Console.WriteLine("Not a vowel");
                    break;
            }
        }

        private static void fromJSON(string filePath)
        {
            Console.WriteLine("Please enter the extension you want to convert to:" +
        "\n1.CSV" +
        "\n2.XML");
            string Selection = Convert.ToString(Console.ReadLine());
            var contents = File.ReadAllText(filePath);

            switch (Selection)
            {
                case "1":
                    Console.WriteLine("To CSV");
                    var CSVString = CSVOut.WriteToString(JSONIn.ReadFromString(contents));
                    File.WriteAllText("new_file3.csv", CSVString);
                    break;
                case "2":
                    Console.WriteLine("To XML");
                    var XMLString = XMLOut.WriteToString(JSONIn.ReadFromString(contents));
                    File.WriteAllText("new_file3.xml", XMLString);
                    break;
                default:
                    Console.WriteLine("Not a vowel");
                    break;
            }
        }

        private static void fromXML(string filePath)
        {
            Console.WriteLine("Please enter the extension you want to convert to:" +
        "\n1.CSV" +
        "\n2.JSON");
            string Selection = Convert.ToString(Console.ReadLine());
            var contents = File.ReadAllText(filePath);

            switch (Selection)
            {
                case "1":
                    Console.WriteLine("To CSV");
                    var CSVString = CSVOut.WriteToString(XMLIn.ReadFromString(contents));
                    File.WriteAllText("new_file3.csv", CSVString);
                    break;
                case "2":
                    Console.WriteLine("To JSON");
                    var JSONString = JSONout.WriteToString(XMLIn.ReadFromString(contents));
                    File.WriteAllText("new_file3.json", JSONString);
                    break;
                default:
                    Console.WriteLine("Not a number");
                    break;
            }
        }
    }
}
