using System;
using System.Xml.Serialization;

namespace Store.Logic
{
    public class Services
    {
        public string? name{get;set;}
        public string? info{get;set;}
        public int serviceId{get;set;}
        public static int idSeed = 1;

        private XmlSerializer Serializer = new XmlSerializer(typeof(Services));
        public Services(){}
        public Services(string? name,string? info)
        {
            this.serviceId = idSeed;
            this.info = info;
            this.name = name;
            idSeed++;
        }
        public string ToString()
        {
            var result = new System.Text.StringBuilder();
            result.AppendLine($"ServiceID: {this.serviceId}\nName: {this.name}\nInfo: {this.info}");
            return result.ToString();
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