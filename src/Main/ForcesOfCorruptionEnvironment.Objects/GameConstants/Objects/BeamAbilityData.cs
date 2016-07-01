using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Xml;
using AlomoEngine.Core.Interfaces;
using AlomoEngine.Xml;
using AlomoEngine.Xml.DataTypes;
using AlomoEngine.Xml.DataTypes.Enums;
using AlomoEngine.Xml.Layout;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants.Objects
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class BeamAbilityData : AbstractXmlTagCategory
    {
        public BeamAbilityData(IAlomoXmlFile file) : base(file) {}

        public double Tractor_Beam_Width { get; set; }
        public int Tractor_Beam_Frames { get; set; }
        public string Tractor_Beam_Texture { get; set; }
        public EngineColor Tractor_Beam_Color { get; set; }

        public double Energy_Beam_Width { get; set; }
        public int Energy_Beam_Frames { get; set; }
        public string Energy_Beam_Texture { get; set; }
        public EngineColor Energy_Beam_Color { get; set; }

        public override XmlElement Serialize()
        {
            var node = File.RootNode;
            node.SetValueOfLastTagOfName(nameof(Tractor_Beam_Width), Tractor_Beam_Width.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Tractor_Beam_Frames), Tractor_Beam_Frames.ToString());
            node.SetValueOfLastTagOfName(nameof(Tractor_Beam_Texture), Tractor_Beam_Texture);
            node.SetValueOfLastTagOfName(nameof(Tractor_Beam_Color), Tractor_Beam_Color.ToString(EngineSparators.Comma, false));

            node.SetValueOfLastTagOfName(nameof(Energy_Beam_Width), Energy_Beam_Width.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Energy_Beam_Frames), Energy_Beam_Frames.ToString());
            node.SetValueOfLastTagOfName(nameof(Energy_Beam_Texture), Energy_Beam_Texture);
            node.SetValueOfLastTagOfName(nameof(Energy_Beam_Color), Energy_Beam_Color.ToString(EngineSparators.Comma, false));
            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Tractor_Beam_Width = node.GetValueOfLastTagOfName(nameof(Tractor_Beam_Width)).ToEngineFloat();
            Tractor_Beam_Frames = node.GetValueOfLastTagOfName(nameof(Tractor_Beam_Frames)).ToInteger();
            Tractor_Beam_Texture = node.GetValueOfLastTagOfName(nameof(Tractor_Beam_Texture));
            Tractor_Beam_Color = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(Tractor_Beam_Color)));

            Energy_Beam_Width = node.GetValueOfLastTagOfName(nameof(Energy_Beam_Width)).ToEngineFloat();
            Energy_Beam_Frames = node.GetValueOfLastTagOfName(nameof(Energy_Beam_Frames)).ToInteger();
            Energy_Beam_Texture = node.GetValueOfLastTagOfName(nameof(Energy_Beam_Texture));
            Energy_Beam_Color = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(Energy_Beam_Color)));
        }
    }
}
