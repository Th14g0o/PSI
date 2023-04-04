using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
namespace m32hmpv
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mortadela");
            WebRequest req = WebRequest.Create("http://localhost:53155/App/Joao");
            WebResponse resp = req.GetResponse();
            StreamReader reader = new StreamReader(resp.GetResponseStream(), Encoding.ASCII);
            Console.WriteLine(reader.ReadToEnd());
            Console.ReadLine();
        }
    }
}
