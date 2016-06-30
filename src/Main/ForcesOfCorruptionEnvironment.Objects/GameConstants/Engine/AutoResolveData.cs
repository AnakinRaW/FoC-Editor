using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Xml;
using AlomoEngine;
using AlomoEngine.Core.Interfaces;
using AlomoEngine.Xml;
using AlomoEngine.Xml.DataTypes;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants.Engine
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class AutoResolveData : EngineObject
    {
        public AutoResolveData(IAlomoXmlFile parent) : base(parent) {}

        public double Space_Auto_Resolve_Delay_Seconds { get; set; }

        public double Land_Auto_Resolve_Delay_Seconds { get; set; }

        [Description("Default is NO. Set to YES to always engage in tactical battles and skip auto-resolve battles (even instant overrrun ones).")]
        public bool AlwaysBypassAutoResolve { get; set; }

        public bool AutomaticAutoResolve { get; set; }

        public double AutoResolveAttritionAllowanceFactor { get; set; }

        public double AutoResolveTransportLosses { get; set; }

        public double AutoResolveDisplayTime { get; set; }

        public bool AutoResolveVoteDefaultToTactical { get; set; }

        public int AutoResolveVoteDefaultTimeOut { get; set; }

        public double RetreatAutoResolveLoserAttrition { get; set; }

        public double RetreatAutoResolveWinnerAttrition { get; set; }

        public double AutoResolveLoserAttrition { get; set; }

        public double AutoResolveWinnerAttrition { get; set; }

        public double Auto_Resolve_Tactical_Multiplier { get; set; }

        
        public override XmlElement Serialize()
        {
            var node = Parent.RootNode;

            node.SetValueOfLastTagOfName(nameof(Space_Auto_Resolve_Delay_Seconds), Space_Auto_Resolve_Delay_Seconds.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Land_Auto_Resolve_Delay_Seconds), Land_Auto_Resolve_Delay_Seconds.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(AlwaysBypassAutoResolve), AlwaysBypassAutoResolve.ToString());
            node.SetValueOfLastTagOfName(nameof(AutomaticAutoResolve), AutomaticAutoResolve.ToString());
            node.SetValueOfLastTagOfName(nameof(AutoResolveAttritionAllowanceFactor), Space_Auto_Resolve_Delay_Seconds.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(AutoResolveTransportLosses), Land_Auto_Resolve_Delay_Seconds.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(AutoResolveDisplayTime), Land_Auto_Resolve_Delay_Seconds.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(AutoResolveVoteDefaultToTactical), AutoResolveVoteDefaultToTactical.ToString());
            node.SetValueOfLastTagOfName(nameof(AutoResolveVoteDefaultTimeOut), AutoResolveVoteDefaultTimeOut.ToString());
            node.SetValueOfLastTagOfName(nameof(RetreatAutoResolveLoserAttrition), RetreatAutoResolveLoserAttrition.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(RetreatAutoResolveWinnerAttrition), RetreatAutoResolveWinnerAttrition.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(AutoResolveLoserAttrition), AutoResolveLoserAttrition.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(AutoResolveWinnerAttrition), AutoResolveWinnerAttrition.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Auto_Resolve_Tactical_Multiplier), Auto_Resolve_Tactical_Multiplier.ToString(CultureInfo.InvariantCulture));

            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Space_Auto_Resolve_Delay_Seconds =
                node.GetValueOfLastTagOfName(nameof(Space_Auto_Resolve_Delay_Seconds)).ToEngineFloat();

            Land_Auto_Resolve_Delay_Seconds =
                node.GetValueOfLastTagOfName(nameof(Land_Auto_Resolve_Delay_Seconds)).ToEngineFloat();

            AlwaysBypassAutoResolve = node.GetValueOfLastTagOfName(nameof(AlwaysBypassAutoResolve)).ToEngineBoolean();
            AutomaticAutoResolve = node.GetValueOfLastTagOfName(nameof(AutomaticAutoResolve)).ToEngineBoolean();
            AutoResolveAttritionAllowanceFactor = node.GetValueOfLastTagOfName(nameof(AutoResolveAttritionAllowanceFactor)).ToEngineFloat();
            AutoResolveTransportLosses = node.GetValueOfLastTagOfName(nameof(AutoResolveTransportLosses)).ToEngineFloat();
            AutoResolveDisplayTime = node.GetValueOfLastTagOfName(nameof(AutoResolveDisplayTime)).ToEngineFloat();
            AutoResolveVoteDefaultToTactical = node.GetValueOfLastTagOfName(nameof(AutoResolveVoteDefaultToTactical)).ToEngineBoolean();
            AutoResolveVoteDefaultTimeOut = node.GetValueOfLastTagOfName(nameof(AutoResolveVoteDefaultTimeOut)).ToInteger();
            RetreatAutoResolveLoserAttrition = node.GetValueOfLastTagOfName(nameof(RetreatAutoResolveLoserAttrition)).ToEngineFloat();
            RetreatAutoResolveWinnerAttrition = node.GetValueOfLastTagOfName(nameof(RetreatAutoResolveWinnerAttrition)).ToEngineFloat();
            AutoResolveLoserAttrition = node.GetValueOfLastTagOfName(nameof(AutoResolveLoserAttrition)).ToEngineFloat();
            AutoResolveWinnerAttrition = node.GetValueOfLastTagOfName(nameof(AutoResolveWinnerAttrition)).ToEngineFloat();
            Auto_Resolve_Tactical_Multiplier = node.GetValueOfLastTagOfName(nameof(Auto_Resolve_Tactical_Multiplier)).ToEngineFloat();
        }
    }
}
