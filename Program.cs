using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace xmlOutput
{
    class Program
    {
        static void Main()
            
        {
            //This is what retrieves and reads the file. Copy the path of where you saved the file and replace "C:\VS Projects\test.csv" with the actual path
            string[] lines = File.ReadAllLines(@"C:\VS Projects\Sample.csv");

            //This is what 'parses' the csv to XML. you name and nest indexed fields from your csv here to match the .dtd file formatting
            XElement xml = new XElement("MODEL",
                from str in lines
                let columns = str.Split(',')
                select new XElement("SUBMODULE",
                    new XElement("BatteryE135", columns[0]),
                    new XElement("E140", columns[1]),
                    new XElement("E142", columns[2]),
                    new XElement("E161", columns[3]),
                    new XElement("E165", columns[4]),
                    new XElement("E167", columns[5])
                )
            );
            
            //This is what saves the file. You can put it in any folder you want on your computer, just name it "something.xml" when you do so it saves as an XML
            xml.Save(@"C:\VS Projects\SampleOut.xml");
        }

    }
}
