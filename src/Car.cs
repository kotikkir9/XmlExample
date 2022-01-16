using System.Xml.Serialization;

namespace XML.src
{
    public class Car
    {
        [XmlAttribute("name")]
        public string? Name { get; set; }
        [XmlElement("cylinders")]
        public int? Cylinders { get; set; }
        [XmlElement("country")]
        public string? Country { get; set; }

        public override string ToString()
        {
            return $"Name: {Name, -25} Cylinders: {Cylinders, -10} Country: {Country}";
        }
    }   

    [XmlRootAttribute("cars")]
    public class CarCollection
    {
        [XmlElement("car")]
        public List<Car> Cars { get; set; } = new List<Car>();
    }
}