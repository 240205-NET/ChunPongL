using System;
using System.Xml.Serialization;

namespace Store.Logic
{
    public class Foods
    {
        //Fields
        public static int idSeed = 1;
        public int PID{get;set;}
        public static int PIDSeed = 100;
        public int foodId{get;set;}
        public string name{get;set;}
        public string type{get;set;}
        public double price{get;set;}
        public int quantity{get;set;}
        private XmlSerializer Serializer = new XmlSerializer(typeof(Foods));
        public Foods(){}
        public Foods(string name,string type,double price,int quantity)
        {
            this.foodId = idSeed;
            this.name = name;
            this.type = type;
            this.price = price;
            this.quantity = quantity;
            this.PID = PIDSeed;
            PIDSeed++;
            idSeed++;
        }
        //method
        public string ToString()
        {
            var result = new System.Text.StringBuilder();
            result.AppendLine($"ID: {this.foodId}\nRegistrationID: {this.PID}\nName: {this.name}\nType: {this.type}\nPrice: {this.price}\nQuantity: {this.quantity}");
            return result.ToString();
        }
        public string ToString(int n)
        {
            var result = new System.Text.StringBuilder();
            result.AppendLine($"ID: {this.foodId}\nRegistrationID: {this.PID}\nName: {this.name}\nType: {this.type}\nPrice: {this.price}\nQuantity: {n}");
            return result.ToString();
        }
        public void updateFoodId()
        {
            this.foodId--;
        }
        public void updateIdSeed()
        {
            idSeed--;
        }
        public void updateQuantity(int n)
        {
            for(int i=0;i<n;i++)
            {
                this.quantity--;
            }
        }
        public string SerializeXML()
        {
            var stringWriter = new StringWriter();
            Serializer.Serialize(stringWriter, this);
            stringWriter.Close();
            return stringWriter.ToString();
        }
    }
}