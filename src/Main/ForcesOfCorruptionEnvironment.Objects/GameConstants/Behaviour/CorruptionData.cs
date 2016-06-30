using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Xml;
using AlomoEngine;
using AlomoEngine.Core.Interfaces;
using AlomoEngine.Xml;
using AlomoEngine.Xml.DataTypes;
using AlomoEngine.Xml.DataTypes.Enums;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants.Behaviour
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class CorruptionData : EngineObject
    {
        public CorruptionData(IAlomoXmlFile parent) : base(parent) {}

        public double Corruption_Hyperspace_Bonus { get; set; }

        public EngineStringTupel Corruption_Choice_Icon_Name { get; set; }
        public EngineStringTupel Corruption_Choice_Name { get; set; }
        public EngineStringTupel Corruption_Choice_Benefit { get; set; }
        public EngineStringTupel Corruption_Mission_Requirement_Icon_Name { get; set; }
        public EngineStringTupel Corruption_Choice_Encyclopedia { get; set; }
        public EngineFloatTupel Corruption_Choice_Income_Percentage { get; set; }
        public double Bribery_Fleet_Reveal_Range { get; set; }

        public EngineStringTupel Corruption_Planet_Icon { get; set; }
        public EngineStringTupel Corruption_Planet_Icon_Encyclopedia_Name { get; set; }
        public EngineStringTupel Corruption_Planet_Icon_Encyclopedia_Desc { get; set; }
        public string Corruption_Encyclopedia_Backdrop { get; set; }
        public string Corruption_Encyclopedia_Header { get; set; }
        public string Corruption_Encyclopedia_Complete { get; set; }
        public string Corruption_Encyclopedia_Incomplete { get; set; }
        public string Corruption_Encyclopedia_Money_Icon { get; set; }
        public int Corruption_Encyclopedia_Left_Edge { get; set; }
        public int Corruption_Encyclopedia_Spacing { get; set; }

        public override XmlElement Serialize()
        {
            var node = Parent.RootNode;
            node.SetValueOfLastTagOfName(nameof(Corruption_Hyperspace_Bonus), Corruption_Hyperspace_Bonus.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Corruption_Choice_Icon_Name), Corruption_Choice_Icon_Name.ToString(EngineSparators.Space, true));
            node.SetValueOfLastTagOfName(nameof(Corruption_Choice_Name), Corruption_Choice_Name.ToString(EngineSparators.Space, true));
            node.SetValueOfLastTagOfName(nameof(Corruption_Choice_Benefit), Corruption_Choice_Benefit.ToString(EngineSparators.Space, true));
            node.SetValueOfLastTagOfName(nameof(Corruption_Mission_Requirement_Icon_Name), Corruption_Mission_Requirement_Icon_Name.ToString(EngineSparators.Space, true));
            node.SetValueOfLastTagOfName(nameof(Corruption_Choice_Encyclopedia), Corruption_Choice_Encyclopedia.ToString(EngineSparators.Space, true));
            node.SetValueOfLastTagOfName(nameof(Corruption_Choice_Income_Percentage), Corruption_Choice_Income_Percentage.ToString());
            node.SetValueOfLastTagOfName(nameof(Bribery_Fleet_Reveal_Range), Bribery_Fleet_Reveal_Range.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Corruption_Planet_Icon), Corruption_Planet_Icon.ToString(EngineSparators.Space, true));
            node.SetValueOfLastTagOfName(nameof(Corruption_Planet_Icon_Encyclopedia_Name), Corruption_Planet_Icon_Encyclopedia_Name.ToString(EngineSparators.Space, true));
            node.SetValueOfLastTagOfName(nameof(Corruption_Planet_Icon_Encyclopedia_Desc), Corruption_Planet_Icon_Encyclopedia_Desc.ToString(EngineSparators.Space, true));
            node.SetValueOfLastTagOfName(nameof(Corruption_Encyclopedia_Backdrop), Corruption_Encyclopedia_Backdrop);
            node.SetValueOfLastTagOfName(nameof(Corruption_Encyclopedia_Header), Corruption_Encyclopedia_Header);
            node.SetValueOfLastTagOfName(nameof(Corruption_Encyclopedia_Complete), Corruption_Encyclopedia_Complete);
            node.SetValueOfLastTagOfName(nameof(Corruption_Encyclopedia_Incomplete), Corruption_Encyclopedia_Incomplete);
            node.SetValueOfLastTagOfName(nameof(Corruption_Encyclopedia_Money_Icon), Corruption_Encyclopedia_Money_Icon);
            node.SetValueOfLastTagOfName(nameof(Corruption_Encyclopedia_Left_Edge), Corruption_Encyclopedia_Left_Edge.ToString());
            node.SetValueOfLastTagOfName(nameof(Corruption_Encyclopedia_Spacing), Corruption_Encyclopedia_Spacing.ToString());
            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Corruption_Hyperspace_Bonus = node.GetValueOfLastTagOfName(nameof(Corruption_Hyperspace_Bonus)).ToEngineFloat();
            Corruption_Choice_Icon_Name = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Corruption_Choice_Icon_Name)));
            Corruption_Choice_Name = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Corruption_Choice_Name)));
            Corruption_Choice_Benefit = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Corruption_Choice_Benefit)));
            Corruption_Mission_Requirement_Icon_Name = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Corruption_Mission_Requirement_Icon_Name)));
            Corruption_Choice_Encyclopedia = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Corruption_Choice_Encyclopedia)));
            Corruption_Choice_Income_Percentage = EngineFloatTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Corruption_Choice_Income_Percentage)));
            Bribery_Fleet_Reveal_Range =
                node.GetValueOfLastTagOfName(nameof(Bribery_Fleet_Reveal_Range)).ToEngineFloat();
            Corruption_Planet_Icon = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Corruption_Planet_Icon)));
            Corruption_Planet_Icon_Encyclopedia_Name = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Corruption_Planet_Icon_Encyclopedia_Name)));
            Corruption_Planet_Icon_Encyclopedia_Desc = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Corruption_Planet_Icon_Encyclopedia_Desc)));
            Corruption_Encyclopedia_Backdrop = node.GetValueOfLastTagOfName(nameof(Corruption_Encyclopedia_Backdrop));
            Corruption_Encyclopedia_Header = node.GetValueOfLastTagOfName(nameof(Corruption_Encyclopedia_Header));
            Corruption_Encyclopedia_Complete = node.GetValueOfLastTagOfName(nameof(Corruption_Encyclopedia_Complete));
            Corruption_Encyclopedia_Incomplete = node.GetValueOfLastTagOfName(nameof(Corruption_Encyclopedia_Incomplete));
            Corruption_Encyclopedia_Money_Icon = node.GetValueOfLastTagOfName(nameof(Corruption_Encyclopedia_Money_Icon));
            Corruption_Encyclopedia_Left_Edge = node.GetValueOfLastTagOfName(nameof(Corruption_Encyclopedia_Left_Edge)).ToInteger();
            Corruption_Encyclopedia_Spacing = node.GetValueOfLastTagOfName(nameof(Corruption_Encyclopedia_Spacing)).ToInteger();
        }
    }
}
