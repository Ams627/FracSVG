using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace FracSVG
{
    class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                if (!args.Any())
                {
                    throw new Exception($"You must specify a denominator.");
                }
                var filename = "output.html";
                var doc = new XDocument(new XElement("svg",
                        new XAttribute("viewbox", "0,0,420,420"),
                        new XAttribute("width", "300"),
                        new XAttribute("height", "300"),
                    new XElement("circle",
                    new XAttribute("class", "circle1"),
                    new XAttribute("shape-rendering", "geometricPrecision"),
                    new XAttribute("fill", "none"),
                    new XAttribute("stroke", "black"),
                    new XAttribute("stroke-width", "2"),
                    new XAttribute("cx", "200"),
                    new XAttribute("cy", "200"),
                    new XAttribute("r", "180")
                    )));


                using (var sw = new StreamWriter(filename))
                {
                    sw.WriteLine(@"<html><head><title=""fractions""></head></html><body>");
                    sw.WriteLine(doc);
                    sw.WriteLine(@"</body></html>");
                }
            }
            catch (Exception ex)
            {
                var fullname = System.Reflection.Assembly.GetEntryAssembly().Location;
                var progname = Path.GetFileNameWithoutExtension(fullname);
                Console.Error.WriteLine($"{progname} Error: {ex.Message}");
            }

        }
    }
}
