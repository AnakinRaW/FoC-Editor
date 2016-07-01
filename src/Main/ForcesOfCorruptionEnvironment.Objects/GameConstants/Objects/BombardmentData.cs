using System.Diagnostics.CodeAnalysis;
using System.Xml;
using AlomoEngine.Core.Interfaces;
using AlomoEngine.Xml;
using AlomoEngine.Xml.DataTypes;
using AlomoEngine.Xml.DataTypes.Enums;
using AlomoEngine.Xml.Layout;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants.Objects
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class BombardmentData : AbstractXmlTagCategory
    {
        public BombardmentData(IAlomoXmlFile file) : base(file) {}

        public int Max_Bombing_Run_Interval_Seconds { get; set; }
        public int Min_Bombing_Run_Interval_Seconds { get; set; }
        public int Bombing_Run_Reduction_Per_Squadron_Percent { get; set; }
        public int Max_Bombard_Interval_Seconds { get; set; }
        public int Min_Bombard_Interval_Seconds { get; set; }
        public EngineIntegerTupel Bombardment_Offset { get; set; }
        public EngineIntegerTupel Bombardment_Distribution { get; set; }

        public override XmlElement Serialize()
        {
            var node = File.RootNode;

            node.SetValueOfLastTagOfName(nameof(Max_Bombing_Run_Interval_Seconds), Max_Bombing_Run_Interval_Seconds.ToString());
            node.SetValueOfLastTagOfName(nameof(Min_Bombing_Run_Interval_Seconds), Min_Bombing_Run_Interval_Seconds.ToString());
            node.SetValueOfLastTagOfName(nameof(Bombing_Run_Reduction_Per_Squadron_Percent), Bombing_Run_Reduction_Per_Squadron_Percent.ToString());
            node.SetValueOfLastTagOfName(nameof(Max_Bombard_Interval_Seconds), Max_Bombard_Interval_Seconds.ToString());
            node.SetValueOfLastTagOfName(nameof(Min_Bombard_Interval_Seconds), Min_Bombard_Interval_Seconds.ToString());
            node.SetValueOfLastTagOfName(nameof(Bombardment_Offset), Bombardment_Offset.ToString(EngineSparators.Space));
            node.SetValueOfLastTagOfName(nameof(Bombardment_Distribution), Bombardment_Distribution.ToString());
            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Max_Bombing_Run_Interval_Seconds =
                node.GetValueOfLastTagOfName(nameof(Max_Bombing_Run_Interval_Seconds)).ToInteger();
            Min_Bombing_Run_Interval_Seconds =
                node.GetValueOfLastTagOfName(nameof(Min_Bombing_Run_Interval_Seconds)).ToInteger();
            Bombing_Run_Reduction_Per_Squadron_Percent =
                node.GetValueOfLastTagOfName(nameof(Bombing_Run_Reduction_Per_Squadron_Percent)).ToInteger();
            Max_Bombard_Interval_Seconds =
                node.GetValueOfLastTagOfName(nameof(Max_Bombard_Interval_Seconds)).ToInteger();
            Min_Bombard_Interval_Seconds =
                node.GetValueOfLastTagOfName(nameof(Min_Bombard_Interval_Seconds)).ToInteger();
            Bombardment_Offset = EngineIntegerTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Bombardment_Offset)));
            Bombardment_Distribution = EngineIntegerTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Bombardment_Distribution)));
        }
    }
}
