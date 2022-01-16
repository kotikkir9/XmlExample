using System.Xml.Serialization;
using System.Xml;
using System.Text;

namespace XML.src
{
    public class XmlReadHandler
    {
        public List<Car> GetCarListFromXml(string file)
        {
            var list = new List<Car>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(file);
            XmlNodeList cars = xmlDoc.GetElementsByTagName("car");
            
            foreach(XmlElement element in cars)
            {
                Car car = new Car();

                car.Name = element.GetAttribute("name");
                car.Cylinders = int.Parse(element.GetElementsByTagName("cylinders")[0]?.InnerText ?? "0");
                car.Country = element.GetElementsByTagName("country")[0]?.InnerText;
 
                list.Add(car);
            }
            
            return list;
        }

        public List<Car> FlemmingsMetodeForAtParseXml(string file)
        {
            var list = new List<Car>();
            XmlReader reader = XmlReader.Create(file);

            while(reader.ReadToFollowing("car"))
            {
                var car = new Car();
                car.Name = reader.GetAttribute("name"); 

                reader.ReadToFollowing("cylinders");
                car.Cylinders = int.Parse(reader.ReadElementContentAsString() ?? "0");
  
                reader.ReadToFollowing("country");
                car.Country = reader.ReadElementContentAsString();
   
                list.Add(car);
            }

            reader.Close();
            return list;
        }

        public List<Car> DenDanskeMetode(string file) 
        {
            CarCollection cars;

            using (XmlReader reader = XmlReader.Create(file))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(CarCollection));
                cars = serializer.Deserialize(reader) as CarCollection;
            }

            return cars?.Cars ?? new List<Car>();
        }
    }
}