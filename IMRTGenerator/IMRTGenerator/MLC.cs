using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IMRTGenerator
{
    class MLC
    {
        public Xml.MLC mlcXml { get; private set; }
        public MLC(string fName)
        {
            using (var st = new FileStream(fName, FileMode.Open, FileAccess.Read))
            {
                mlcXml = new XmlSerializer(typeof(Xml.MLC)).Deserialize(st) as Xml.MLC;
            }
        }

        public double [] LeafWidths()
        {
            return mlcXml.BankV2.First().LeafV2.Select(lf => Decimal.ToDouble(lf.Width)).ToArray();
        }
    }
}
