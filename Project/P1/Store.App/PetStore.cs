using System;
using System.IO;
using System.Xml.Serialization;
using Store.Logic;
using Store.Data;

namespace Store.App
{
    public class PetStore : Store
    {
        //Field
        private List<Pets> _displaypetsList;
        private List<Foods> _displayfoodsList;
        private List<Services> _displayservicesList;
        private List<Dogs> _dogsList;
        private List<Cats> _catsList;
        private List<Foods> _foodsList;
        private List<Services> _servicesList;
        private string cartPath = @".\cartPath.txt";
        private string petPath = @".\petPath.txt";
        private string foodPath = @".\foodPath.txt";
        private string servicePath = @".\servicePath.txt";
        private string dogPath = @".\dogPath.txt";
        private string catPath = @".\catPath.txt";

        

        // Construtor
        public PetStore(string name,string storeType,string location, string email, string phone)
        {
            this.name = name;
            this.storeType = storeType;
            this.location = location;
            this.email = email;
            this.phone = phone;
            this._displaypetsList = new List<Pets>();
            this._displayfoodsList = new List<Foods>();
            this._displayservicesList = new List<Services>();
            this._catsList = new List<Cats>();
            this._dogsList = new List<Dogs>();
            this._foodsList = new List<Foods>();
            this._servicesList = new List<Services>();

        }
        //Method
        public void onlineService()
        {
            //read all data we need from the path
            _dogsList.Add(new Dogs("Cami","Dog - French Bulldog","Felmale","November 07,2023",7.2,"Chocolate",3730));
            _dogsList.Add(new Dogs("River","Dog - Cocker Spaniel","Male","December 03, 2023",8.5,"Merle",2270));
            _dogsList.Add(new Dogs("Moon"));
            _catsList.Add(new Cats("Mimi","Cat - Domestic HairShort","Male","December 25, 2023",5.0,"White",2000));
            _catsList.Add(new Cats("Coco","Cat - Domestic HairShort","Felmale","December 26, 2023",4.8,"Dark",2000));
            _foodsList.Add(new Foods("Apple food","Dog food",20.50,10));
            _foodsList.Add(new Foods("Orange food","Cat food",10.50,1));
            _servicesList.Add(new Services("Training","Train your pet to be uber driver."));
            _servicesList.Add(new Services("Pet grooming","Styling and bathing"));
            displayMenu();
        }

        public override void displayMenu()
        {
            //Display menu
                //1. Pet Deals
                //2. Food Deals
                //3. Check Current cart
                //4. Service Appointment
                //5. Contact us
                //0. Exit.
            //prompt from users
            string? choice;
            bool loop = true;
            GreetingMessage();
            while(loop)
            {
                Console.WriteLine("\n1: Pet Deals\n2: Food Deals\n3: Services Appointment\n4: Check Current Cart\n5: Contact us\n0: Exit");
                Console.Write("Please Enter your choice: ");
                choice = Console.ReadLine();
                Console.WriteLine();

                switch(choice)
                {
                    case "1":
                        petDeals( _petsList);
                        break;
                    case "2":
                        foodDeals(_foodsList);
                        break;
                    case "3":
                        //Sevices Appointment method
                        serviceAppointment(_servicesList);
                        break;
                    case "4":
                        //read from file
                        ReadFile(cartPath);
                        break;
                    case "5":
                        //Contact us method
                        Console.WriteLine(ToString());
                        break;
                    case "0":
                        loop = false;
                        //call serialize file here.
                        Console.WriteLine("\n--Serialize--\n");
                        SerializePet(_petsList2,petPath);
                        SerializeFood(_foodsList2 ,foodPath);
                        SerializeService(_servicesList2 ,servicePath);
                        _petsList.Clear();
                        //_petsList = DeserializeXMLPet(petPath);
                        // foreach(Pets p in _petsList)
                        // {
                        //     Console.WriteLine(p.ToString());
                        // }
                        Console.WriteLine("\n--End of Serialize--\n");
                        _petsList.Clear();
                        _foodsList.Clear();
                        _servicesList.Clear();
                        File.Create(cartPath).Close();
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;

                }
            }
        }
        public override string ToString()
        {
            return $"\n--Contact Us--\n\nStore name: {this.name}\nStoreType: {this.storeType}\nLocation: {this.location}\nEmail:{this.email}\nPhone:{this.phone}\n\n--End of Contact Us--";
        }
        public override void GreetingMessage()
        {
            Console.WriteLine("Welcome to " + this.name + " " + this.storeType + " online service.");
        }
        //pet deal
        public void petDeals(List<Pets> _petsList)
        {
            //print all pets in curret List
            displayAllPets(_petsList);
            bool loop = true;
            while(loop)
            {
                Console.Write("Would you want to add some more cuties in current cart?(Y/N): ");
                string countinue = Console.ReadLine();
                switch(countinue)
                {
                    case "Y":
                        //wrtie to file
                        //remove from list
                        updatePetsList(_petsList);
                        break;
                    case "N":
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, input is case sensitive.");
                        break;
                }
            }

        }
        public void displayAllPets(List<Pets> _petsList)
        {
            Console.WriteLine("--Pet Deals--\n");
            foreach(Pets p in _petsList)
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine("--End of Pet Deals--");
        }
        public void removeFromPetsList(List<Pets> _petsList)
        {
            int choice = -1;
            //validate the data
            while(choice < 0||choice>_petsList.Count)
            {
                Console.Write("Please Enter an ID to add or 0 to exit: ");
                choice = Int32.Parse(Console.ReadLine());
            }
            //get the get info from List
            if(choice!=0)
            {
                string s;
                foreach(Pets p in _petsList)
                {
                    if(p.petId==choice)
                    {
                        s = p.ToString();
                        //wrtie to file
                        writeFile(s,cartPath);
                        //try to seperate dogs and cats from the pet List
                        // if(p is Dogs)
                        // {
                        //     Dogs tmp = new Dogs(p.name,p.type,p.sex,p.dateOfBirth,p.weight,p.color,p.price);
                        //     _dogsList.Add(tmp);
                        // }
                        // else if(p is Cats)
                        // {
                        //     Cats tmp = new Cats(p.name,p.type,p.sex,p.dateOfBirth,p.weight,p.color,p.price);
                        //     _catsList.Add(tmp);
                        // }
                        _petsList2.Add(p);       
                        Console.WriteLine("Add sucessful.");
                    }
                    else if(p.petId>choice)
                    {
                        //update all petId in List
                        p.updatePetId();
                    }
                    else if(p.petId==_petsList.Count-1)
                    {
                        //update pet id seed
                        p.updateIdSeed();
                    }
                }          
                //remove from List
                _petsList.RemoveAt(choice-1);
            }
        }
        public void updatePetsList(List<Pets> _petsList)
        {
            removeFromPetsList(_petsList);
        }
        //food deal
        public void foodDeals(List<Foods> _foodsList)
        {
            displayAllFoods(_foodsList);
            bool loop = true;
            while(loop)
            {
                Console.Write("Would you want to some more in current cart?(Y/N): ");
                string countinue = Console.ReadLine();
                switch(countinue)
                {
                    case "Y":
                        //wrtie to file
                        //remove from list
                        updateFoodsList(_foodsList);
                        break;
                    case "N":
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, input is case sensitive.");
                        break;
                }
            }
        }
        public void displayAllFoods(List<Foods> _foodsList)
        {
            Console.WriteLine("--Food Deals--\n");
            foreach(Foods f in _foodsList)
            {
                Console.WriteLine(f.ToString());
            }
            Console.WriteLine("--End of Food Deals--");
        }
        public void removeFromFoodsList(List<Foods> _foodsList)
        {
            int choice = -1;
            int quan = -1;
            int curQuan = 0;
            //validate the data
            while(choice < 0||choice>_foodsList.Count)
            {
                Console.Write("Please Enter an ID to add or 0 to exit: ");
                choice = Int32.Parse(Console.ReadLine());
            }
            if(_foodsList.Count!=0)
            {
                curQuan = _foodsList.Find(x=>x.foodId==choice).quantity;
                while(quan<1||quan>curQuan)
                {
                    Console.Write("Please Enter quantity of items or 0 to exit: ");
                    quan = Int32.Parse(Console.ReadLine());               
                }
            }
            //get the quantity of the desired items

            //get the get info from List
            if(choice!=0)
            {
                string s;
                foreach(Foods f in _foodsList)
                {
                    if(f.foodId==choice&&f.quantity>0)
                    {
                        s = f.ToString(quan);
                        //wrtie to file
                        writeFile(s,cartPath);
                        Foods tmp = new Foods(f.name,f.type,f.price,quan);
                        tmp.foodId = f.foodId;
                        _foodsList2.Add(tmp);
                        Console.WriteLine("Add sucessful.");
                        f.updateQuantity(quan);
                        
                    }
                    else if(f.foodId>choice)
                    {
                        //update all FoodId in List
                        f.updateFoodId();
                    }
                    else if(f.foodId==_foodsList.Count-1)
                    {
                        //update foodId seed
                        f.updateIdSeed();
                    }
                }
                if(curQuan-quan==0)
                {
                    _foodsList.RemoveAt(choice-1);  
                }
            }
        }
        public void updateFoodsList(List<Foods> _foodsList)
        {
            removeFromFoodsList(_foodsList);
        }
        //Service Appointment
        public void serviceAppointment(List<Services> _servicesList)
        {
            displayAllServices(_servicesList);
            bool loop = true;
            while(loop)
            {
                Console.Write("Would you want to some more in current cart?(Y/N): ");
                string countinue = Console.ReadLine();
                switch(countinue)
                {
                    case "Y":
                        //wrtie to file
                        appointment(_servicesList);
                        break;
                    case "N":
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, input is case sensitive.");
                        break;
                }
            }
        }
        public void displayAllServices(List<Services> _servicesList)
        {
            Console.WriteLine("--Service Appointment--\n");
            foreach(Services s in _servicesList)
            {
                Console.WriteLine(s.ToString());
            }
            Console.WriteLine("--End of Service Appointment--");
        }
        public void appointment(List<Services> _servicesList)
        {
            int choice = -1;
            //validate the data
            while(choice < 0||choice>_servicesList.Count)
            {
                Console.Write("Please Enter ServiceID to add or 0 to exit: ");
                choice = Int32.Parse(Console.ReadLine());
            }
            //get the get info from List
            if(choice!=0)
            {
                string s = _servicesList.Find(x=>x.serviceId==choice).ToString();
                writeFile(s,cartPath);
                _servicesList2.Add(_servicesList.Find(x=>x.serviceId==choice));

            }
        }
        //File IO
        public void writeFile(string s, string path)
        {
            // save to a file as text
            string[] text = {s};

            if( File.Exists(path))
            {
                File.AppendAllLines(path,text);
            }
            else
            {
                File.WriteAllLines(path, text); // WriteAllLines requires an IEnumerable (a collection) of strings
            // File.WriteLine(path, <string>); // WriteLine will operate on a single string
            }
        }
        public void ReadFile(string path)
        {
            Console.WriteLine("\n--Current Cart!--\n");
            // read from the file
            if(File.Exists(path))
            {
                string[] readText = File.ReadAllLines(path);
                foreach (string s in readText)
                {
                    Console.WriteLine(s);
                }
            }
            else
            {
                Console.WriteLine("File Not Found");
            }
            Console.WriteLine("--End of Current Cart!--");
        }
        //Serialize
        public void SerializePet(List<Pets> _petsList2 , string path)
        {
            foreach(Pets p in _petsList2)
            {
                Console.WriteLine(p.ToString());
                string[] text1 = {p.SerializeXML()};
                if( File.Exists(path))
                {
                    File.AppendAllLines(path,text1);
                }
                else
                {
                    File.WriteAllLines(path, text1);
                }
            }
        }
        public void SerializeDog(List<Dogs> _dogsList2 , string path)
        {
            foreach(Dogs d in _dogsList2)
            {
                Console.WriteLine(d.ToString());
                string[] text1 = {d.SerializeXML()};
                if( File.Exists(path))
                {
                    File.AppendAllLines(path,text1);
                }
                else
                {
                    File.WriteAllLines(path, text1);
                }
            }
        }
        public void SerializeCat(List<Cats> _catsList2 , string path)
        {
            foreach(Cats c in _catsList2)
            {
                Console.WriteLine(c.ToString());
                string[] text1 = {c.SerializeXML()};
                if( File.Exists(path))
                {
                    File.AppendAllLines(path,text1);
                }
                else
                {
                    File.WriteAllLines(path, text1);
                }
            }
        }
        public void SerializeFood(List<Foods> _foodsList2, string path)
        {
            foreach(Foods f in _foodsList2)
            {
                Console.WriteLine(f.ToString());
                string[] text1 = {f.SerializeXML()};
                if( File.Exists(path))
                {
                    File.AppendAllLines(path,text1);
                }
                else
                {
                    File.WriteAllLines(path, text1);
                }
            }

        }
        public void SerializeService(List<Services> _servicesList2 , string path)
        {
            foreach(Services s in _servicesList2)
            {
                Console.WriteLine(s.ToString());
                string[] text1 = {s.SerializeXML()};
                if( File.Exists(path))
                {
                    File.AppendAllLines(path,text1);
                }
                else
                {
                    File.WriteAllLines(path, text1);
                }
            }
        }
        public List<Pets> DeserializeXMLPet(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Pets));
            List<Pets> _dogsList = new List<Pets>();
            Dogs P = new Dogs();
            if (!File.Exists(path))
            {
                Console.WriteLine("File Not Found");
                return null;
            }
            else
            {
                using StreamReader reader = new StreamReader(path);
                var record = (Dogs)serializer.Deserialize(reader);
                if (record is null)
                {
                    throw new InvalidDataException();
                    return null;
                }
                else
                {
                    P = record;
                    _dogsList.Add(P);
                }
            }
            return _dogsList;
        }
        public Cats DeserializeXMLCat(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Cats));
            Cats P = new Cats();
            if (!File.Exists(path))
            {
                Console.WriteLine("File Not Found");
                return null;
            }
            else
            {
                using StreamReader reader = new StreamReader(path);
                var record = (Cats)serializer.Deserialize(reader);
                if (record is null)
                {
                    throw new InvalidDataException();
                    return null;
                }
                else
                {
                    P = record;
                }
            }
            return P;
        }
        public Foods DeserializeXMLFood(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Foods));
            Foods P = new Foods();
            if (!File.Exists(path))
            {
                Console.WriteLine("File Not Found");
                return null;
            }
            else
            {
                using StreamReader reader = new StreamReader(path);
                var record = (Foods)serializer.Deserialize(reader);
                if (record is null)
                {
                    throw new InvalidDataException();
                    return null;
                }
                else
                {
                    P = record;
                }
            }
            return P;
        }
        public Services DeserializeXMLService(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Services));
            Services P = new Services();
            if (!File.Exists(path))
            {
                Console.WriteLine("File Not Found");
                return null;
            }
            else
            {
                using StreamReader reader = new StreamReader(path);
                var record = (Services)serializer.Deserialize(reader);
                if (record is null)
                {
                    throw new InvalidDataException();
                    return null;
                }
                else
                {
                    P = record;
                }
            }
            return P;
        }    
    }
}