using System;
using System.IO;
using System.Xml.Serialization;

namespace Serializer
{
    public class Program
    {
        //method
        static void readFile(string path)
        {
            Console.WriteLine("Reading from file...");

            if(File.Exists(path))
            {
                string[] readText = File.ReadAllLines(path);
                foreach(string s in readText)
                {
                    Console.WriteLine(s);
                }
            }
            else
            {
                Console.WriteLine("File Not Found");
            }
        }
        static void writeFile(Person p, string path)
        {
            Console.WriteLine("Person "+ p.name + " is writing to file...");
            string[] text = {p.ToString()};

            if(File.Exists(path))
            {
                File.AppendAllLines(path,text);
            }
            else
            {
                File.WriteAllLines(path,text); 
            }
        }
        static void serialize2XML(Person p, string path)
        {
            Console.WriteLine("Serializing "+ p.name +" to XML at "+ path);
            Console.WriteLine(p.SerializeXML());

            // save the serialized object to a file
            string[] text1 = {p.SerializeXML()};
            File.WriteAllLines(path, text1);

        }
        static Person DeserializeXML(string path)
        {
            Console.WriteLine("DeSerializing XML at "+ path);
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            Person P = new Person();
            if(!File.Exists(path))
            {
                Console.WriteLine("File Not Found");
                return null;
            }
            else
            {
                using StreamReader reader = new StreamReader(path);
                //(Expected type)
                var record = (Person)serializer.Deserialize(reader);
                if (record is null)
                {
                    throw new InvalidDataException();
                    return null;
                }
                else
                {
                    P = record;
                }
                return P;
            }
        }
        static void displayMenu()
        {
            string path = @".\TextFile.txt";
            Person p1 = new Person("Lawrence",72,28);
            bool flag = false;
            //Greeting user and tell them whats the function of this program
            //prompt from the user
            //execute what kind of function that they want.
            while(!flag)
            {
                Console.WriteLine($"\t\tMenu\t\t\n1. Read from the file.\n2. Write to the file.\n3. Serialize to the XML and write to the file.\n4. Read XML from the file, and deserialize to an object.\n5. Exit the program.");
                Console.WriteLine("Enter your selection: ");
                string? option = Console.ReadLine();

                switch(option)
                {
                    case "1":
                        readFile(path);
                        break;

                    case "2":
                        writeFile(p1,path);
                        break;

                    case "3":
                        serialize2XML(p1,path);
                        break;

                    case "4":
                        Person newPerson = DeserializeXML(path);
                        break;

                    case "5":
                        flag = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice! Please try again.\n");
                        break;

                }
            }
            


        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, This is a Serialization Program.\n");
            displayMenu();
            Console.WriteLine("Exit sucessfully. Application closing...");
          
        }       
    }
}