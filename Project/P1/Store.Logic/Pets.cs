using System;


namespace Store.Logic
{
    public abstract class Pets
    {
        //Field
        public int petId{get;set;}
        public static int idSeed = 1;
        public static int RIDSeed = 1000;
        public int petRID{get;set;}
        public string? name{get;set;}
        public string? type{get;set;}
        public string? sex{get;set;}
        public string? dateOfBirth{get;set;}
        public double? weight{get;set;}
        public string? color{get;set;}
        public double? price{get;set;}
        //method
        public string ToString()
        {
            var result = new System.Text.StringBuilder();
            result.AppendLine($"Pet: {this.petId}\nRegistrationID: {this.petRID}\nName: {this.name}\nType: {this.type}\nSex: {this.sex}\nDOB: {this.dateOfBirth}\nWeight(lbs): {this.weight}\nColor: {this.color}\nPrice: {this.price}");
            return result.ToString();
        }
        public void updatePetId()
        {
            this.petId--;
        }
        public void updateIdSeed()
        {
            idSeed--;
        }
        public abstract string SerializeXML();
    }
}