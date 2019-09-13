using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMRTGenerator.Xml
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xsd.baden.varian.com/MLCConfiguration.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://xsd.baden.varian.com/MLCConfiguration.xsd", IsNullable = false)]
    public partial class MLC
    {

        private string mLCIdV2Field;

        private string manufacturerNameField;

        private object mLCSerialNoField;

        private string mLCModelField;

        private decimal mLCRotationField;

        private bool arcDynamicEnabledField;

        private bool doseDynamicEnabledField;

        private decimal parallelJawSetbackField;

        private decimal perpendicularJawSetbackField;

        private decimal nominalLeafLengthField;

        private MLCBankV2[] bankV2Field;

        private MLCAddOnValidation[] addOnValidationField;

        private string supportedFilesField;

        private decimal minDoseDynamicLeafGapField;

        private decimal minArcDynamicLeafGapField;

        private decimal minStaticLeafGapField;

        private byte maxLeafSpeedField;

        private byte doseDynamicLeafToleranceField;

        private byte arcDynamicLeafToleranceField;

        private decimal minSegmentThresholdField;

        private ushort maxControlPointsField;

        private byte versionField;

        /// <remarks/>
        public string MLCIdV2
        {
            get
            {
                return this.mLCIdV2Field;
            }
            set
            {
                this.mLCIdV2Field = value;
            }
        }

        /// <remarks/>
        public string ManufacturerName
        {
            get
            {
                return this.manufacturerNameField;
            }
            set
            {
                this.manufacturerNameField = value;
            }
        }

        /// <remarks/>
        public object MLCSerialNo
        {
            get
            {
                return this.mLCSerialNoField;
            }
            set
            {
                this.mLCSerialNoField = value;
            }
        }

        /// <remarks/>
        public string MLCModel
        {
            get
            {
                return this.mLCModelField;
            }
            set
            {
                this.mLCModelField = value;
            }
        }

        /// <remarks/>
        public decimal MLCRotation
        {
            get
            {
                return this.mLCRotationField;
            }
            set
            {
                this.mLCRotationField = value;
            }
        }

        /// <remarks/>
        public bool ArcDynamicEnabled
        {
            get
            {
                return this.arcDynamicEnabledField;
            }
            set
            {
                this.arcDynamicEnabledField = value;
            }
        }

        /// <remarks/>
        public bool DoseDynamicEnabled
        {
            get
            {
                return this.doseDynamicEnabledField;
            }
            set
            {
                this.doseDynamicEnabledField = value;
            }
        }

        /// <remarks/>
        public decimal ParallelJawSetback
        {
            get
            {
                return this.parallelJawSetbackField;
            }
            set
            {
                this.parallelJawSetbackField = value;
            }
        }

        /// <remarks/>
        public decimal PerpendicularJawSetback
        {
            get
            {
                return this.perpendicularJawSetbackField;
            }
            set
            {
                this.perpendicularJawSetbackField = value;
            }
        }

        /// <remarks/>
        public decimal NominalLeafLength
        {
            get
            {
                return this.nominalLeafLengthField;
            }
            set
            {
                this.nominalLeafLengthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BankV2")]
        public MLCBankV2[] BankV2
        {
            get
            {
                return this.bankV2Field;
            }
            set
            {
                this.bankV2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AddOnValidation")]
        public MLCAddOnValidation[] AddOnValidation
        {
            get
            {
                return this.addOnValidationField;
            }
            set
            {
                this.addOnValidationField = value;
            }
        }

        /// <remarks/>
        public string SupportedFiles
        {
            get
            {
                return this.supportedFilesField;
            }
            set
            {
                this.supportedFilesField = value;
            }
        }

        /// <remarks/>
        public decimal MinDoseDynamicLeafGap
        {
            get
            {
                return this.minDoseDynamicLeafGapField;
            }
            set
            {
                this.minDoseDynamicLeafGapField = value;
            }
        }

        /// <remarks/>
        public decimal MinArcDynamicLeafGap
        {
            get
            {
                return this.minArcDynamicLeafGapField;
            }
            set
            {
                this.minArcDynamicLeafGapField = value;
            }
        }

        /// <remarks/>
        public decimal MinStaticLeafGap
        {
            get
            {
                return this.minStaticLeafGapField;
            }
            set
            {
                this.minStaticLeafGapField = value;
            }
        }

        /// <remarks/>
        public byte MaxLeafSpeed
        {
            get
            {
                return this.maxLeafSpeedField;
            }
            set
            {
                this.maxLeafSpeedField = value;
            }
        }

        /// <remarks/>
        public byte DoseDynamicLeafTolerance
        {
            get
            {
                return this.doseDynamicLeafToleranceField;
            }
            set
            {
                this.doseDynamicLeafToleranceField = value;
            }
        }

        /// <remarks/>
        public byte ArcDynamicLeafTolerance
        {
            get
            {
                return this.arcDynamicLeafToleranceField;
            }
            set
            {
                this.arcDynamicLeafToleranceField = value;
            }
        }

        /// <remarks/>
        public decimal MinSegmentThreshold
        {
            get
            {
                return this.minSegmentThresholdField;
            }
            set
            {
                this.minSegmentThresholdField = value;
            }
        }

        /// <remarks/>
        public ushort MaxControlPoints
        {
            get
            {
                return this.maxControlPointsField;
            }
            set
            {
                this.maxControlPointsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xsd.baden.varian.com/MLCConfiguration.xsd")]
    public partial class MLCBankV2
    {

        private MLCBankV2LeafV2[] leafV2Field;

        private string bankIdField;

        private decimal maxLeafExposureField;

        private decimal maxLeafSpanField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LeafV2")]
        public MLCBankV2LeafV2[] LeafV2
        {
            get
            {
                return this.leafV2Field;
            }
            set
            {
                this.leafV2Field = value;
            }
        }

        /// <remarks/>
        public string BankId
        {
            get
            {
                return this.bankIdField;
            }
            set
            {
                this.bankIdField = value;
            }
        }

        /// <remarks/>
        public decimal MaxLeafExposure
        {
            get
            {
                return this.maxLeafExposureField;
            }
            set
            {
                this.maxLeafExposureField = value;
            }
        }

        /// <remarks/>
        public decimal MaxLeafSpan
        {
            get
            {
                return this.maxLeafSpanField;
            }
            set
            {
                this.maxLeafSpanField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xsd.baden.varian.com/MLCConfiguration.xsd")]
    public partial class MLCBankV2LeafV2
    {

        private decimal widthField;

        private decimal offsetYField;

        private decimal maxPlanPositionField;

        private decimal minPlanPositionField;

        private string leafIdField;

        private byte leafNumberField;

        /// <remarks/>
        public decimal Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }

        /// <remarks/>
        public decimal OffsetY
        {
            get
            {
                return this.offsetYField;
            }
            set
            {
                this.offsetYField = value;
            }
        }

        /// <remarks/>
        public decimal MaxPlanPosition
        {
            get
            {
                return this.maxPlanPositionField;
            }
            set
            {
                this.maxPlanPositionField = value;
            }
        }

        /// <remarks/>
        public decimal MinPlanPosition
        {
            get
            {
                return this.minPlanPositionField;
            }
            set
            {
                this.minPlanPositionField = value;
            }
        }

        /// <remarks/>
        public string LeafId
        {
            get
            {
                return this.leafIdField;
            }
            set
            {
                this.leafIdField = value;
            }
        }

        /// <remarks/>
        public byte LeafNumber
        {
            get
            {
                return this.leafNumberField;
            }
            set
            {
                this.leafNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xsd.baden.varian.com/MLCConfiguration.xsd")]
    public partial class MLCAddOnValidation
    {

        private string techniqueIdField;

        private string radiationTypeField;

        /// <remarks/>
        public string TechniqueId
        {
            get
            {
                return this.techniqueIdField;
            }
            set
            {
                this.techniqueIdField = value;
            }
        }

        /// <remarks/>
        public string RadiationType
        {
            get
            {
                return this.radiationTypeField;
            }
            set
            {
                this.radiationTypeField = value;
            }
        }
    }
}
