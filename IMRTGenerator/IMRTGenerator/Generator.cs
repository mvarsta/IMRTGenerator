using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

namespace IMRTGenerator
{
    class Generator
    {
        static string calcModel = null; 
        private class ModelNameComparer:IComparer<String>
        {
            //
            // Model name assumed of the form <label> NN.nn.xx (e.g. AAA 15.6.01.20)
            // 
            static string pattern = @"(\w+)\s+(?<version>(?:\d+\.{0,1})+)";
            static Regex regex = new Regex(pattern);

            public int Compare(string a, string b)
            {
                var av = regex.IsMatch(a) ? regex.Match(a).Groups["version"]?.Value.Split('.').Select(v => Convert.ToInt32(v)).ToArray() : null;
                var bv = regex.IsMatch(b) ? regex.Match(b).Groups["version"]?.Value.Split('.').Select(v => Convert.ToInt32(v)).ToArray() : null;
                if(null == av || null == bv)
                {
                    return 0; //cant order
                }
                for(var l = 0; l < Math.Min(av.Length, bv.Length); l++)
                { 
                    if (av[l] == bv[l]) continue;
                    return av[l] - bv[l];
                }
                return av.Length - bv.Length;
            }
        }

        private static void adjustJaws(Beam beam, double beamletSizeX, double[] leafWidths)
        {
            var half = leafWidths.Sum() * .5;
            var beamPars = beam.GetEditableParameters();
            var jaws = beam.ControlPoints.First().JawPositions;

            var x1 = jaws.X1;
            x1 += (Math.Floor(x1 / beamletSizeX) - x1 / beamletSizeX) * beamletSizeX;

            var x2 = jaws.X2;
            x2 += (Math.Ceiling(x2 / beamletSizeX) - x2 / beamletSizeX) * beamletSizeX;


            var y1 = jaws.Y1;
            var y1n = half;
            for (var index = leafWidths.Length - 1; index >= 0 && y1n > y1; index--, y1n -= leafWidths[index]) ;

            var y2 = jaws.Y2;
            var y2n = -half;
            for (var index = 0; index < leafWidths.Length && y2n < y2; index++, y2n += leafWidths[index]) ;

            beamPars.SetJawPositions(new VRect<double>(x1, y1n, x2, y2n));
            beam.ApplyParameters(beamPars);
        }

   
        public static void TestComp()
        {
            String[] d = { "AAA 15.6.01.10", "BBB 15.6.01", "CCC 13.6.3", "DDD 134.7", "POO" , "LOO 155"};
            var foo = new ModelNameComparer();
            foo.Compare(d[0], d[1]);
            foo.Compare(d[2], d[1]);
            var tmp = d.OrderByDescending(v => v, foo);
            return;
        }

        public static void GeneratePlan(VMS.TPS.Common.Model.API.Application app,
                MLCDefinitions mlcs,
                ExternalBeamMachineParameters beamPars,
                IMRTGenerator.JSON.Patient patient,
                IEnumerable<IMRTGenerator.JSON.Beam> beams
                )
        {

            var pat = app.OpenPatientById(patient.PatientId);
            var sSet = pat.StructureSets.Single(ss => ss.Id == patient.StructureSet);

            pat.BeginModifications();

            var cr = pat.Courses.SingleOrDefault(cr_ => cr_.Id == "DTPCOURSE");
            if (null == cr)
            {
                cr = pat.AddCourse();
                cr.Id = "DTPCOURSE";
            }
            var plan = cr.AddExternalPlanSetup(sSet);
            //
            // Cannot use target structure
            //
            var targetStructure = sSet.Structures.Single(s => s.Id == plan.TargetVolumeID);
            var isoCenter = targetStructure.CenterPoint;

            foreach (var bm in beams)
            {
                var beam = plan.AddMLCBeam(beamPars, null, default(VRect<double>), 0.0, bm.GantryAngleInDeg, bm.PatientSupportAngleInDeg, isoCenter);
                beam.FitMLCToStructure(new FitToStructureMargins(bm.MlcMarginInmm),
                    targetStructure,
                    true,
                    JawFitting.FitToRecommended,
                    OpenLeavesMeetingPoint.OpenLeavesMeetingPoint_Middle,
                    ClosedLeavesMeetingPoint.ClosedLeavesMeetingPoint_Center);
                adjustJaws(beam, bm.BeamletSizeXInmm, mlcs.MLCs[beam.MLC.Id].LeafWidths());
            }
            if (null == calcModel)
            {
                calcModel = plan.GetModelsForCalculationType(CalculationType.PhotonInfluenceMatrix)?.OrderByDescending(cm => cm, new ModelNameComparer()).First();
                calcModel = calcModel == null ? "" : calcModel;
            }
            plan.SetCalculationModel(CalculationType.PhotonInfluenceMatrix, calcModel);
            app.SaveModifications();
        }
    }
}
