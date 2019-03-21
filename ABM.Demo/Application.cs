using ABM.Demo.App_Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ABM.Demo
{
    class Application
    {
        public object ConfigurationManager { get; private set; }

        internal void run()
        {
            //question 02
           

            var ediREsultList = EdiParser.loadFromString(util._edifactString);
            string[][] result = ediREsultList.Select(list => list.DataElements.Split(new char[] { '&' })).ToArray();
            Console.WriteLine("---------------------------------------------------------- ");
            Console.WriteLine("Question 1  ");
            Console.WriteLine("---------------------------------------------------------- ");
            foreach (var item in result)
            {
                Console.WriteLine("{"+item[0].ToString()+","+ item[1].ToString()+"}"); // Assumes a console application
            }


            Console.WriteLine(" ");
            Console.WriteLine("---------------------------------------------------------- ");
            List<string> itensToBeListed = new List<string> { "MWB", "TRV", "CAR" };
        
            Console.WriteLine("Question 2 ");
            Console.WriteLine("---------------------------------------------------------- ");

            string path = Path.GetFullPath("../../../ABM/XML/Question2.xml");

            var resultQuestion2 = ExtractXML.LoadFromString(path, "Reference", "RefCode", itensToBeListed);

            foreach (var it in resultQuestion2)
            {
                Console.WriteLine("{" + it.Identifier + "," + it.value + "}"); 
            }
            

            Console.WriteLine(" ");
            Console.WriteLine("Question 3 ");
            Console.WriteLine("---------------------------------------------------------- ");

            string path3 = Path.GetFullPath("../../../ABM/XML/Question3.xml");
            string pathxsd = Path.GetFullPath("../../../ABM/XML/Question3.xsd");
            //     var b = XmlValidatorToXSD.load(path3);
            ServiceReference1.IService1 obj = new ServiceReference1.Service1Client();
            int resultQuestion3 = obj.ValidationXml(path3, pathxsd);

             Console.WriteLine("{" + resultQuestion3 + "}"); // Assumes a console application

            Console.ReadLine();

        }
    }
}
