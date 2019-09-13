// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var inputData = InputData.FromJson(jsonString);

namespace IMRTGenerator.JSON
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class InputData
    {
        [JsonProperty("Machine")]
        public Machine Machine { get; set; }

        [JsonProperty("Patients")]
        public Patient[] Patients { get; set; }

        [JsonProperty("Beams")]
        public Beam[] Beams { get; set; }
    }

    public partial class Beam
    {
        [JsonProperty("GantryAngleInDeg")]
        public double GantryAngleInDeg { get; set; }

        [JsonProperty("PatientSupportAngleInDeg")]
        public double PatientSupportAngleInDeg { get; set; }

        [JsonProperty("MLCMarginInmm")]
        public double MlcMarginInmm { get; set; } = 5.0;

        [JsonProperty("JawMarginInmm")]
        public double JawMarginInmm { get; set; } = 0.0;

        [JsonProperty("BeamletSizeXInmm")]
        public double BeamletSizeXInmm { get; set; } = 2.5;

        [JsonProperty("BeamletSizeYInmm")]
        public double BeamletSizeYInmm { get; set; } = 2.5;
    }

    public partial class Machine
    {
        [JsonProperty("MachineId")]
        public string MachineId { get; set; }

        [JsonProperty("EnergyMode")]
        public string EnergyMode { get; set; }

        [JsonProperty("DoseRate")]
        public long DoseRate { get; set; }
    }

    public partial class Patient
    {
        [JsonProperty("PatientId")]
        public string PatientId { get; set; }

        [JsonProperty("StructureSet")]
        public string StructureSet { get; set; }

        [JsonProperty("Target")]
        public string Target { get; set; }

        [JsonProperty("IsoCenter")]
        public double[] IsoCenter { get; set; }
    }

    public partial class InputData
    {
        public static InputData FromJson(string json) => JsonConvert.DeserializeObject<InputData>(json, JSON.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this InputData self) => JsonConvert.SerializeObject(self, JSON.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
