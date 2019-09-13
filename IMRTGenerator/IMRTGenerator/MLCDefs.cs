using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IMRTGenerator
{
   internal class MLCDefinitions
    {

        private static string mlcPath = @"C:\VMSOS\Config2\local\Products\RTM\Data\AD\MachineWizard\MLC";
        private static string[] fileList = { @"VarianHD120.xml", @"Millennium120.xml"};

        public Dictionary<String, MLC> MLCs;

        public static MLCDefinitions instance = null;

        public static MLCDefinitions GetInstance()
        {
            if(instance == null)
            {
                instance = new MLCDefinitions();
            }
            return instance;
        }

        private MLCDefinitions()
        {
            MLCs = new Dictionary<string, MLC>(fileList.Length);
            foreach (var fName in fileList)
            {
                var tmpMlc = new MLC(Path.Combine(mlcPath, fName));
                MLCs.Add(tmpMlc.mlcXml.MLCIdV2, tmpMlc);
            }
        }
    }
}
