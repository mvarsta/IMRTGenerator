using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;
[assembly: ESAPIScript(IsWriteable = true)]
namespace IMRTGenerator
{
    class GeneratorMain
    {
        [STAThread]
        static void Main(string[] args)
        {
            var loc = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var sname = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            loc = loc.Substring(0, loc.Length - sname.Length - 4);
            var fileName = @"InputData.json";

            var mlcs = MLCDefinitions.GetInstance();

            using (var app = VMS.TPS.Common.Model.API.Application.CreateApplication())
            {
                JSON.InputData inputData;

             
                using (var inputFile = new StreamReader(Path.Combine(loc, fileName))) {
                    inputData = JSON.InputData.FromJson(inputFile.ReadToEnd());
                }
                var beamPars = new ExternalBeamMachineParameters(
                   inputData.Machine.MachineId,
                   inputData.Machine.EnergyMode,
                   (int) inputData.Machine.DoseRate,
                   "STATIC",
                   null
                   );


                foreach (var patInfo in inputData.Patients)
                {
                    Generator.GeneratePlan(app,
                        mlcs,
                        beamPars,
                        patInfo, 
                        inputData.Beams);
                }                
            }
         }
    }
}
