using System;
using System.Xml.Serialization;

namespace Store.Logic
{
    public class Cats: Pets
    {
        //Field
        private XmlSerializer Serializer = new XmlSerializer(typeof(Cats));
        //Constructor
        public Cats(){}
        public Cats(string name="",string type="",string sex="",string dateOfBirth="",double? weight=0.0,string color="",double? price=0.0)
        {
            this.petId = idSeed;
            this.name = name;
            this.type = type;
            this.sex = sex;
            this.dateOfBirth = dateOfBirth;
            this.weight = weight;
            this.color = color;
            this.price = price;
            this.petRID = RIDSeed;
            RIDSeed++;
            idSeed++;
        }
        //method
        public override string SerializeXML()
        {
            var stringWriter = new StringWriter();
            Serializer.Serialize(stringWriter, this);
            stringWriter.Close();
            return stringWriter.ToString();
        }

    }
}