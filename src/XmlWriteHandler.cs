using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace XML.src
{
    public class XmlWriteHandler
    {
         public void CreateXmlDocument(List<Car> list, string fileName)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.Encoding = Encoding.UTF8;

            var stringWriter = new UTF8StringWriter();
            XmlWriter writer = XmlWriter.Create(stringWriter, settings);

            writer.WriteStartDocument();
            writer.WriteStartElement("cars");

            foreach(Car car in list)
            {
                writer.WriteStartElement("car");
                writer.WriteAttributeString("name", car.Name);
                writer.WriteElementString("cylinders", car.Cylinders.ToString());
                writer.WriteElementString("country", car.Country);
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
            
            writer.Close();
            File.WriteAllTextAsync($"{fileName}.xml", stringWriter.ToString()); 
        }

        public void CreateXmlDocumentAlternative(List<Car> carList, string fileName)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";

            using(var stringWriter = new UTF8StringWriter())
            using(var xmlWriter = XmlWriter.Create(stringWriter, settings))
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                XmlSerializer serializer = new XmlSerializer(typeof(CarCollection));
                serializer.Serialize(xmlWriter, new CarCollection { Cars = carList }, ns);
                
                File.WriteAllTextAsync($"{fileName}.xml", stringWriter.ToString());
            }   
        }
    }
}