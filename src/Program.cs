// See https://aka.ms/new-console-template for more information

using XML.src;

string xmlFile = "http://www.fkj.dk/cars.xml";

var xmlReader = new XmlReadHandler();
var xmlWriter = new XmlWriteHandler();

var cars = xmlReader.GetCarListFromXml(xmlFile);
var cars2 = xmlReader.FlemmingsMetodeForAtParseXml(xmlFile);
var cars3 = xmlReader.DenDanskeMetode(xmlFile);

xmlWriter.CreateXmlDocument(cars, "Metode-1");
xmlWriter.CreateXmlDocumentAlternative(cars3, "Metode-2");

System.Console.WriteLine("Metode 1:\n--------");
PrintCars(cars);

System.Console.WriteLine("\nMetode 2:\n--------");
PrintCars(cars2);

System.Console.WriteLine("\nMetode 3:\n--------");
PrintCars(cars3);


// SERVICE METHOD
void PrintCars(List<Car> list)
{
    foreach(var element in list)
    {
        System.Console.WriteLine(element);
    }
}